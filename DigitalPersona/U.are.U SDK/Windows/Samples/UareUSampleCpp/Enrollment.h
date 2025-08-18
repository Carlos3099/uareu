//////////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2016 DigitalPersona, Inc.
//
// U.are.U SDK 2.x
//
//////////////////////////////////////////////////////////////////////////////
//
// Sample code
//
// Enrollment dialog
//
//////////////////////////////////////////////////////////////////////////////

#pragma once

#define WM_FINGERMSG (WM_USER + 8136)

class CEnrollDlg: public CDialogImpl<CEnrollDlg>
{
protected:
	char       m_szReaderName[MAX_PATH];
	HANDLE     m_hEnrollmentThread;
	DPFPDD_DEV m_hReader;

	//enrollment template
	DPFJ_FMD_FORMAT m_nEnrollmentFormat;
	unsigned char*  m_pEnrollmentFmd;
	unsigned int    m_nEnrollmentFmdSize;

public:
	enum { IDD = IDD_DLG_LIST };

	CEnrollDlg(const char* szReaderName): m_hEnrollmentThread(NULL), m_hReader(NULL), m_pEnrollmentFmd(NULL), m_nEnrollmentFmdSize(0)
	{
		strncpy_s(m_szReaderName, _countof(m_szReaderName), szReaderName, _TRUNCATE);
	}

	BEGIN_MSG_MAP(CEnrollDlg)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		MESSAGE_HANDLER(WM_FINGERMSG, OnFinger)
		COMMAND_RANGE_HANDLER(IDOK, IDNO, OnClose)
	END_MSG_MAP()

	const char* GetSelectedName() const {
		return m_szReaderName;
	}

	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled){
		CenterWindow();
		SetWindowText(_T("Enrollment"));

		CEdit wndPrompt = GetDlgItem(IDC_EDIT_PROMPT);
		int dpi;

		m_nEnrollmentFormat = DPFJ_FMD_DP_REG_FEATURES; //create DigitalPersona registration template
		m_pEnrollmentFmd = NULL;
		m_nEnrollmentFmdSize = 0;

		//open reader
		int result = dpfpdd_open_ext(m_szReaderName, DPFPDD_PRIORITY_COOPERATIVE, &m_hReader);
		if(DPFPDD_SUCCESS != result){
			ErrorMsg(_T("error when calling dpfpdd_open_ext()"), result);
		}
		else if(0 !=(dpi = GetFirstDPI(m_hReader))){
			//start erollment, pass the required FMD format
			result = dpfj_start_enrollment(m_nEnrollmentFormat);

			if(DPFJ_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfj_start_enrollment()"), result);
			}
			else{
				//prepare capture parameters and result
				DPFPDD_CAPTURE_PARAM cparam = {0};
				cparam.size = sizeof(cparam);
				cparam.image_fmt = DPFPDD_IMG_FMT_ISOIEC19794;
				cparam.image_proc = DPFPDD_IMG_PROC_NONE;
				cparam.image_res = dpi;

				//start asyncronous capture
				result = dpfpdd_capture_async(m_hReader, &cparam, this, CaptureCallback);
				if(DPFPDD_SUCCESS != result){
					ErrorMsg(_T("error when calling dpfpdd_capture_async()"), result);
				}
				else{
					wndPrompt.AppendText(_T("Enrollment started\r\n\r\n"));
					wndPrompt.AppendText(_T("Put any finger on the reader...\r\n"));
				}
			}
		}

		bHandled = TRUE;
		return 0;
	};
	 
	LRESULT OnClose(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		//done with enrollment
		int result = dpfj_finish_enrollment();
		if(DPFJ_SUCCESS != result){
			ErrorMsg(_T("error when calling dpfj_finish_enrollment()"), result);
		}

		//cancel capture
		if(NULL != m_hReader){
			int result = dpfpdd_cancel(m_hReader);
			if(DPFPDD_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfpdd_cancel()"), result);
			}
			// invalidate the selected device by name
			if(DPFPDD_E_DEVICE_FAILURE == result)
				m_szReaderName[0] = 0;
			//close reader
			result = dpfpdd_close(m_hReader);
			if(DPFPDD_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfpdd_close()"), result);
			}
			// invalidate the selected device by name
			if(DPFPDD_E_INVALID_DEVICE == result)
				m_szReaderName[0] = 0;
		}

		//release enrollment memory
		if(NULL != m_pEnrollmentFmd){
			delete [] m_pEnrollmentFmd;
			m_pEnrollmentFmd = NULL;
		}

		bHandled = TRUE; 
		EndDialog(wID);
		return 0;
	};

	LRESULT OnFinger(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM lParam, BOOL& bHandled){
		DPFPDD_CAPTURE_CALLBACK_DATA_0* pCaptureData = reinterpret_cast<DPFPDD_CAPTURE_CALLBACK_DATA_0*>(lParam);

		bHandled = true;
		if(NULL == pCaptureData) return 0;

		CEdit wndPrompt = GetDlgItem(IDC_EDIT_PROMPT);

		if(DPFPDD_SUCCESS == pCaptureData->error){
			if(pCaptureData->capture_result.success){
				bool bRestartEnrollment = false;

				//captured
				wndPrompt.AppendText(_T("    fingerprint captured,\r\n"));

				//get max size for the feature template
				unsigned char* pFeatures = NULL;
				unsigned int nFeaturesSize = MAX_FMD_SIZE;
				pFeatures = new unsigned char[nFeaturesSize];
				if(NULL == pFeatures){
					ErrorMsg(_T("insufficient memory for the feature template"), 0);
				}
				else{
					//is enrollment template ready?
					if(NULL != m_pEnrollmentFmd){
						//extract features
						int result = dpfj_create_fmd_from_fid(pCaptureData->capture_parm.image_fmt, pCaptureData->image_data, pCaptureData->image_size, DPFJ_FMD_DP_VER_FEATURES, pFeatures, &nFeaturesSize);

						if(result != DPFJ_SUCCESS){
							ErrorMsg(_T("dpfj_create_fmd_from_fid() returned error"), result);
						}
						else{
							wndPrompt.AppendText(_T("    features extracted.\r\n\r\n"));

							//enrollmet already created, let's match this fingerprint with it
							unsigned int falsematch_rate = 0;
							result = dpfj_compare(DPFJ_FMD_DP_VER_FEATURES, pFeatures, nFeaturesSize, 0, m_nEnrollmentFormat, m_pEnrollmentFmd, m_nEnrollmentFmdSize, 0, &falsematch_rate);

							if(DPFJ_SUCCESS == result){
								//print out the results
								const unsigned int target_falsematch_rate = DPFJ_PROBABILITY_ONE / 100000; //target rate is 0.00001
								if(falsematch_rate < target_falsematch_rate){
									wndPrompt.AppendText(_T("Fingerprints matched.\r\n\r\n"));
									TCHAR tszText[100];
									_stprintf_s(tszText, _countof(tszText), _T("dissimilarity score: 0x%x.\r\n"), falsematch_rate);
									wndPrompt.AppendText(tszText);
									_stprintf_s(tszText, _countof(tszText), _T("false match rate: %e.\r\n\r\n\r\n"), (double)(falsematch_rate / DPFJ_PROBABILITY_ONE));
									wndPrompt.AppendText(tszText);
								}
								else{
									wndPrompt.AppendText(_T("Fingerprints did not match.\r\n\r\n\r\n"));
								}
							}
							else{
								ErrorMsg(_T("dpfjmx_compare() returned error"), result);
							}
						}

						//restart enrollment
						bRestartEnrollment = true;
					}
					else{
						//what fmd format for pre-enrollment features to use?
						DPFJ_FMD_FORMAT nFeaturesFormat = (DPFJ_FMD_DP_REG_FEATURES == m_nEnrollmentFormat) ? DPFJ_FMD_DP_PRE_REG_FEATURES : m_nEnrollmentFormat;

						//extract features
						int result = dpfj_create_fmd_from_fid(pCaptureData->capture_parm.image_fmt, pCaptureData->image_data, pCaptureData->image_size, nFeaturesFormat, pFeatures, &nFeaturesSize);
						if(result != DPFJ_SUCCESS){
							ErrorMsg(_T("dpfj_create_fmd_from_fid() returned error"), result);
						}
						else{
							wndPrompt.AppendText(_T("    features extracted.\r\n\r\n"));
							//add template to enrollment
							result = dpfj_add_to_enrollment(nFeaturesFormat, pFeatures, nFeaturesSize, 0);

							if(DPFJ_E_MORE_DATA == result){
								//need to add another template
								wndPrompt.AppendText(_T("Put the same finger on the reader...\r\n"));
							}
							else if(DPFJ_SUCCESS == result){
								//check if it's time to clean listbox
								if(100 < wndPrompt.GetLineCount()){
									wndPrompt.SetWindowText(_T(""));
								}

								//enrollment is ready, determine size
								result = dpfj_create_enrollment_fmd(NULL, &m_nEnrollmentFmdSize);

								if(DPFJ_E_MORE_DATA == result){
									m_pEnrollmentFmd = new unsigned char[m_nEnrollmentFmdSize];
									if(NULL == m_pEnrollmentFmd){
										ErrorMsg(_T("insufficient memory for the enrollment template"), 0);
									}
									else{
										result = dpfj_create_enrollment_fmd(m_pEnrollmentFmd, &m_nEnrollmentFmdSize);
										if(DPFJ_SUCCESS != result){
											ErrorMsg(_T("error when calling dpfj_create_enrollment_fmd()"), result);
											//restart enrollment
											bRestartEnrollment = true;
										}
										else{
											TCHAR tszText[100];
											_stprintf_s(tszText, _countof(tszText), _T("Enrollment template created, size: %d\r\n\r\n"), m_nEnrollmentFmdSize);
											wndPrompt.AppendText(tszText);
											wndPrompt.AppendText(_T("Put the same finger on the reader, \r\nto match it with the enrollment template...\r\n"));

											//now enrollment template can be stored in the database
										}
									}
								}
								else if(DPFJ_SUCCESS != result){
									ErrorMsg(_T("error when calling dpfj_create_enrollment_fmd()"), result);
									//restart enrollment
									bRestartEnrollment = true;
								}
							}
							else{
								ErrorMsg(_T("error when calling dpfj_add_to_enrollment()"), result);
								//restart enrollment
								bRestartEnrollment = true;
							}
						}
					}
				}

				//template is not needed anymore
				delete [] pFeatures;

				//do we need to restart enrollment?
				if(bRestartEnrollment){
					int result = dpfj_finish_enrollment();
					if(DPFJ_SUCCESS != result){
						ErrorMsg(_T("error when calling dpfj_finish_enrollment()"), result);
					}
					else{
						result = dpfj_start_enrollment(m_nEnrollmentFormat);
						if(DPFJ_SUCCESS != result){
							ErrorMsg(_T("error when calling dpfj_start_enrollment()"), result);
						}
						else{
							wndPrompt.AppendText(_T("Enrollment started\r\n\r\n"));
							wndPrompt.AppendText(_T("Put any finger on the reader...\r\n"));
						}
					}
					//release enrollment memory
					delete [] m_pEnrollmentFmd;
					m_pEnrollmentFmd = NULL;
					m_nEnrollmentFmdSize = 0;
				}
			}
			else if(DPFPDD_QUALITY_CANCELED == pCaptureData->capture_result.quality){
				//capture canceled
			}
			else{
				//bad capture
				TCHAR tszText[MAX_PATH];
				FormatQualityMsg(pCaptureData->capture_result.quality, _countof(tszText), tszText);
				wndPrompt.AppendText(_T("    "));
				wndPrompt.AppendText(tszText);
				wndPrompt.AppendText(_T("\r\n"));
			}
		}
		else{
			ErrorMsg(_T("error during asynchronous capture"), pCaptureData->error);
		}

		//free memory
		delete [] reinterpret_cast<char*>(pCaptureData);

		return 0;
	}

	static void DPAPICALL CaptureCallback(void* pContext, unsigned int reserved, unsigned int nDataSize, void* pData){
		//sanity checks
		if(NULL == pContext) return;
		if(NULL == pData) return;

		//allocate memory for capture data and the image in one chunk
		DPFPDD_CAPTURE_CALLBACK_DATA_0* pCaptureData = reinterpret_cast<DPFPDD_CAPTURE_CALLBACK_DATA_0*>(pData);
		unsigned char* pBuffer = new unsigned char[sizeof(DPFPDD_CAPTURE_CALLBACK_DATA_0) + pCaptureData->image_size];
		if(NULL != pBuffer){
			//copy capture data
			DPFPDD_CAPTURE_CALLBACK_DATA_0* pcd = reinterpret_cast<DPFPDD_CAPTURE_CALLBACK_DATA_0*>(pBuffer);
			memcpy(pcd, pCaptureData, sizeof(DPFPDD_CAPTURE_CALLBACK_DATA_0));
			//copy image
			pcd->image_data = pBuffer + sizeof(DPFPDD_CAPTURE_CALLBACK_DATA_0); //image directly after capture data header
			memcpy(pcd->image_data, pCaptureData->image_data, pCaptureData->image_size);

			//post message, memory will be freed by the message handler
			CIdentifyDlg* pThis = reinterpret_cast<CIdentifyDlg*>(pContext);
			pThis->PostMessage(WM_FINGERMSG, 0, reinterpret_cast<LPARAM>(pBuffer));
		}
	}
};
