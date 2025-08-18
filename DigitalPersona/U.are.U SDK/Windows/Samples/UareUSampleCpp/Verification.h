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
// Verification dialog
//
//////////////////////////////////////////////////////////////////////////////

#pragma once

#define WM_FINGERMSG (WM_USER + 8136)

class CVerifyDlg: public CDialogImpl<CVerifyDlg>
{
protected:
	char       m_szReaderName[MAX_PATH];
	HANDLE     m_hVerificationThread;
	DPFPDD_DEV m_hReader;

	unsigned char* m_pFeatures1;
	unsigned int   m_nFeatures1Size;

public:
	enum { IDD = IDD_DLG_LIST };

	CVerifyDlg(const char* szReaderName): m_hVerificationThread(NULL), m_hReader(NULL)
	{
		strncpy_s(m_szReaderName, _countof(m_szReaderName), szReaderName, _TRUNCATE);
	}

	BEGIN_MSG_MAP(CVerifyDlg)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		MESSAGE_HANDLER(WM_FINGERMSG, OnFinger)
		COMMAND_RANGE_HANDLER(IDOK, IDNO, OnClose)
	END_MSG_MAP()

	const char* GetSelectedName() const {
		return m_szReaderName;
	}
	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled){
		CenterWindow();
		SetWindowText(_T("Verification"));

		CEdit wndPrompt = GetDlgItem(IDC_EDIT_PROMPT);
		int dpi;

		m_pFeatures1 = NULL;
		m_nFeatures1Size = 0;

		//open reader
		//we want to control LEDs, so we need to open reader in exclusive mode
		int result = dpfpdd_open_ext(m_szReaderName, DPFPDD_PRIORITY_EXCLUSIVE, &m_hReader);
		if(DPFPDD_SUCCESS != result){
			ErrorMsg(_T("error when calling dpfpdd_open_ext()"), result);
		}
		else if(0 !=(dpi = GetFirstDPI(m_hReader))){
			//set green and red LEDs to client-controlled mode
			result = dpfpdd_led_config(m_hReader, DPFPDD_LED_ACCEPT | DPFPDD_LED_REJECT, DPFPDD_LED_CLIENT, NULL);
			if(DPFPDD_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfpdd_led_config()"), result);
			}

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
				wndPrompt.AppendText(_T("Verification started\r\n\r\n"));
				wndPrompt.AppendText(_T("Put any finger on the reader...\r\n"));
			}
		}

		bHandled = TRUE;
		return 0;
	};

	LRESULT OnFinger(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM lParam, BOOL& bHandled){
		DPFPDD_CAPTURE_CALLBACK_DATA_0* pCaptureData = reinterpret_cast<DPFPDD_CAPTURE_CALLBACK_DATA_0*>(lParam);
		if(NULL != pCaptureData){
			CEdit wndPrompt = GetDlgItem(IDC_EDIT_PROMPT);

			if(DPFPDD_SUCCESS == pCaptureData->error){
				if(pCaptureData->capture_result.success){
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
						//extract features
						int result = dpfj_create_fmd_from_fid(pCaptureData->capture_parm.image_fmt, pCaptureData->image_data, pCaptureData->image_size, DPFJ_FMD_ISO_19794_2_2005, pFeatures, &nFeaturesSize);
						if(DPFJ_SUCCESS == result){
							wndPrompt.AppendText(_T("    features extracted.\r\n\r\n"));

							//was it first image or second?
							if(NULL == m_pFeatures1){
								//first image, store it
								m_pFeatures1 = pFeatures;
								m_nFeatures1Size = nFeaturesSize;

								wndPrompt.AppendText(_T("Put the same or any other finger on the reader...\r\n"));
							}
							else{
								//second image, run comparison
								unsigned int falsematch_rate = 0;
								result = dpfj_compare(DPFJ_FMD_ISO_19794_2_2005, m_pFeatures1, m_nFeatures1Size, 0, 
									DPFJ_FMD_ISO_19794_2_2005, pFeatures, nFeaturesSize, 0, &falsematch_rate);

								if(DPFJ_SUCCESS == result){
									//check if it's time to clean listbox
									if(100 < wndPrompt.GetLineCount()){
										wndPrompt.SetWindowText(_T(""));
									}

									const unsigned int target_falsematch_rate = DPFJ_PROBABILITY_ONE / 100000; //target rate is 0.00001
									if(falsematch_rate < target_falsematch_rate){
										//turn green LED on for 500ms
										dpfpdd_led_ctrl(m_hReader, DPFPDD_LED_ACCEPT, DPFPDD_LED_CMD_ON);
										Sleep(500);
										dpfpdd_led_ctrl(m_hReader, DPFPDD_LED_ACCEPT, DPFPDD_LED_CMD_OFF);

										//print out the results
										wndPrompt.AppendText(_T("Fingerprints matched.\r\n\r\n\r\n"));
										TCHAR tszText[100];
										_stprintf_s(tszText, _countof(tszText), _T("dissimilarity score: 0x%x.\r\n"), falsematch_rate);
										wndPrompt.AppendText(tszText);
										_stprintf_s(tszText, _countof(tszText), _T("false match rate: %e.\r\n\r\n\r\n"), (double)(falsematch_rate / DPFJ_PROBABILITY_ONE));
										wndPrompt.AppendText(tszText);
									}
									else{
										//turn red LED on for 500ms
										dpfpdd_led_ctrl(m_hReader, DPFPDD_LED_REJECT, DPFPDD_LED_CMD_ON);
										Sleep(500);
										dpfpdd_led_ctrl(m_hReader, DPFPDD_LED_REJECT, DPFPDD_LED_CMD_OFF);

										//print out the results
										wndPrompt.AppendText(_T("Fingerprints did not match.\r\n\r\n\r\n"));
									}

									//prompt for the next round
									wndPrompt.AppendText(_T("Verification started\r\n\r\n"));
									wndPrompt.AppendText(_T("Put any finger on the reader...\r\n"));
								}
								else{
									ErrorMsg(_T("dpfjmx_compare() returned error"), result);
								}

								//free all features
								delete [] m_pFeatures1;
								m_pFeatures1 = NULL;
								m_nFeatures1Size = 0;
								delete [] pFeatures;
							}
						}
						else{
							ErrorMsg(_T("dpfj_create_fmd_from_fid() returned error"), result);
						}
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
		}

		bHandled = TRUE; 
		return 0;
	}
		 
	LRESULT OnClose(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		if(NULL != m_hReader){
			//cancel capture
			int result = dpfpdd_cancel(m_hReader);
			if(DPFPDD_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfpdd_cancel()"), result);
			}
			// invalidate the selected device by name
			if(DPFPDD_E_DEVICE_FAILURE == result)
				m_szReaderName[0] = 0;
			result = dpfpdd_close(m_hReader);
			if(DPFPDD_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfpdd_close()"), result);
			}
			// invalidate the selected device by name
			if(DPFPDD_E_INVALID_DEVICE == result)
				m_szReaderName[0] = 0;
		}

		//release memory
		if(NULL != m_pFeatures1) delete [] m_pFeatures1;
		m_pFeatures1 = NULL;
		m_nFeatures1Size = 0;

		bHandled = TRUE; 
		EndDialog(wID);
		return 0;
	};

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
			CVerifyDlg* pThis = reinterpret_cast<CVerifyDlg*>(pContext);
			pThis->PostMessage(WM_FINGERMSG, 0, reinterpret_cast<LPARAM>(pBuffer));
		}
	}
};
