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
// Capture dialog
//
//////////////////////////////////////////////////////////////////////////////

#pragma once

#define WM_FINGERMSG (WM_USER + 8136)

class CCaptureDlg: public CDialogImpl<CCaptureDlg>
{
protected:
	char       m_szReaderName[MAX_PATH];
	HANDLE     m_hStreamingThread;
	DPFPDD_DEV m_hReader;
	bool       m_bStreamingMode;
	bool       m_bStopStreaming;
	DPFPDD_PRIORITY   m_prioMode;
	DPFPDD_IMAGE_PROC m_imgProc;
	unsigned int      m_dpi;

public:
	enum { IDD = IDD_DLG_CAPTURE };

	CCaptureDlg(const char* szReaderName): m_hStreamingThread(NULL), m_hReader(NULL), m_bStreamingMode(false)
	{
		strncpy_s(m_szReaderName, _countof(m_szReaderName), szReaderName, _TRUNCATE);
	}

	BEGIN_MSG_MAP(CCaptureDlg)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		MESSAGE_HANDLER(WM_FINGERMSG, OnFinger)
		COMMAND_ID_HANDLER(IDC_RD_COOP, OnOpenMode)
		COMMAND_ID_HANDLER(IDC_RD_EXCL, OnOpenMode)
		COMMAND_ID_HANDLER(IDC_RD_IMG_PROC_DEFAULT, OnImageProc)
		COMMAND_ID_HANDLER(IDC_RD_IMG_PROC_PIV, OnImageProc)
		COMMAND_ID_HANDLER(IDC_RD_IMG_PROC_ENH, OnImageProc)
		COMMAND_ID_HANDLER(IDC_RD_IMG_PROC_ENH2, OnImageProc)
		COMMAND_ID_HANDLER(IDC_CHECK_PAD, OnPad)
		COMMAND_RANGE_HANDLER(IDOK, IDNO, OnClose)
	END_MSG_MAP()

	void SetStreamingMode(bool bOn){
		m_bStreamingMode = bOn;
	}

	const char* GetSelectedName() const {
		return m_szReaderName;
	}

	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled){
		CenterWindow();

		//initial state: exclusive, img proc: default
		CButton btn = GetDlgItem(IDC_RD_EXCL);
		btn.SetCheck(1);
		btn = GetDlgItem(IDC_RD_IMG_PROC_DEFAULT);
		btn.SetCheck(1);
		m_prioMode = DPFPDD_PRIORITY_EXCLUSIVE;
		m_imgProc = DPFPDD_IMG_PROC_DEFAULT;
		Refresh();

		if(m_bStreamingMode){
			SetWindowText(_T("Streaming"));
			m_hStreamingThread = CreateThread(NULL, 0, StreamingThread, this, 0, NULL);

			GetDlgItem(IDC_RD_EXCL).EnableWindow(FALSE);
			GetDlgItem(IDC_RD_COOP).EnableWindow(FALSE);

			CButton btn = GetDlgItem(IDC_CHECK_PAD);
			btn.SetCheck(0);
			btn.EnableWindow(FALSE);
		}
		else{
			int dpi;
			SetWindowText(_T("Capture"));

			StartCapture();

			GetDlgItem(IDC_RD_EXCL).EnableWindow(TRUE);
			GetDlgItem(IDC_RD_COOP).EnableWindow(TRUE);

			CButton btn = GetDlgItem(IDC_CHECK_PAD);
			btn.SetCheck(0);
			btn.EnableWindow(TRUE);
		}

		bHandled = TRUE;
		return 0;
	}
	 
	LRESULT OnClose(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		if(m_bStreamingMode){
			m_bStopStreaming = true;

			//stop streaming
			if(NULL != m_hStreamingThread){
				DWORD dwObj = WaitForSingleObject(m_hStreamingThread, 5000); // Waiting for m_hStreamingThread close
				if(WAIT_OBJECT_0 != dwObj){
					DWORD err = GetLastError();
					ErrorMsg(_T("cannot stop capture thread"), err);
				}
				CloseHandle(m_hStreamingThread);
				m_hStreamingThread = NULL;
			}
		}
		else{
			//cancel capture
			StopCapture();
		}

		bHandled = TRUE; 
		EndDialog(wID);
		return 0;
	}

	LRESULT OnOpenMode(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled) {
		if (!m_bStreamingMode) {
			StopCapture();

			CButton btn = GetDlgItem(IDC_RD_COOP);
			if (0 != btn.GetCheck()) {
				//cooperative mode
				m_prioMode = DPFPDD_PRIORITY_COOPERATIVE;
			}
			else {
				//exclusive mode
				m_prioMode = DPFPDD_PRIORITY_EXCLUSIVE;
			}

			Refresh();
			StartCapture();
		}

		bHandled = TRUE;
		return 0;
	};

	LRESULT OnImageProc(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled) {
		if (!m_bStreamingMode) {
			StopCapture();
		}

		m_imgProc = DPFPDD_IMG_PROC_DEFAULT;
		CButton btn = GetDlgItem(IDC_RD_IMG_PROC_PIV);
		if (0 != btn.GetCheck()) {
			m_imgProc = DPFPDD_IMG_PROC_PIV;
		}
		btn = GetDlgItem(IDC_RD_IMG_PROC_ENH);
		if (0 != btn.GetCheck()) {
			m_imgProc = DPFPDD_IMG_PROC_ENHANCED;
		}
		btn = GetDlgItem(IDC_RD_IMG_PROC_ENH2);
		if (0 != btn.GetCheck()) {
			m_imgProc = DPFPDD_IMG_PROC_ENHANCED_2;
		}

		if (!m_bStreamingMode) {
			Refresh();
			StartCapture();
		}

		bHandled = TRUE;
		return 0;
	};

	void StartCapture() {
		int result = dpfpdd_open_ext(m_szReaderName, m_prioMode, &m_hReader);
		if (DPFPDD_SUCCESS != result) {
			ErrorMsg(_T("error when calling dpfpdd_open_ext()"), result);
		}
		else{
			int dpi = GetFirstDPI(m_hReader);
			if (0 != dpi) {
				//prepare parameters and result
				DPFPDD_CAPTURE_PARAM cp = { 0 };
				cp.size = sizeof(cp);
				cp.image_fmt = DPFPDD_IMG_FMT_PIXEL_BUFFER;
				cp.image_proc = m_imgProc;
				cp.image_res = dpi;

				//PAD is off by default, check if need to turn it on
				CButton btn = GetDlgItem(IDC_CHECK_PAD);
				if (btn.GetCheck()) {
					unsigned char bEnable = 1;
					int result = dpfpdd_set_parameter(m_hReader, DPFPDD_PARMID_PAD_ENABLE, sizeof(bEnable), &bEnable);
					if (DPFPDD_SUCCESS != result) {
						btn.SetCheck(0);
						ErrorMsg(_T("error when enabling spoof detection"), result);
					}
				}

				//start asyncronous capture
				result = dpfpdd_capture_async(m_hReader, &cp, this, CaptureCallback);
				if (DPFPDD_SUCCESS != result) {
					ErrorMsg(_T("error when calling dpfpdd_capture_async()"), result);
				}
			}
		}
	}

	void StopCapture() {
		//cancel capture
		if (NULL != m_hReader) {
			int result = dpfpdd_cancel(m_hReader);
			if (DPFPDD_SUCCESS != result) {
				ErrorMsg(_T("error when calling dpfpdd_cancel()"), result);
			}
			// invalidate the selected device by name
			if (DPFPDD_E_DEVICE_FAILURE == result) {
				m_szReaderName[0] = 0;
			}

			result = dpfpdd_close(m_hReader);
			if (DPFPDD_SUCCESS != result) {
				ErrorMsg(_T("error when calling dpfpdd_close()"), result);
			}
			// invalidate the selected device by name
			if (DPFPDD_E_INVALID_DEVICE == result) {
				m_szReaderName[0] = 0;
			}
			m_hReader = NULL;
		}
	}

	void Refresh() {

		if (DPFPDD_PRIORITY_COOPERATIVE == m_prioMode) {
			//cooperative mode
			m_imgProc = DPFPDD_IMG_PROC_DEFAULT;

			CButton btn = GetDlgItem(IDC_RD_IMG_PROC_DEFAULT);
			btn.SetCheck(1);
			btn = GetDlgItem(IDC_RD_IMG_PROC_PIV);
			btn.SetCheck(0);
			btn = GetDlgItem(IDC_RD_IMG_PROC_ENH);
			btn.SetCheck(0);
			btn = GetDlgItem(IDC_RD_IMG_PROC_ENH2);
			btn.SetCheck(0);

			GetDlgItem(IDC_RD_IMG_PROC_DEFAULT).EnableWindow(FALSE);
			GetDlgItem(IDC_RD_IMG_PROC_PIV).EnableWindow(FALSE);
			GetDlgItem(IDC_RD_IMG_PROC_ENH).EnableWindow(FALSE);
			GetDlgItem(IDC_RD_IMG_PROC_ENH2).EnableWindow(FALSE);
		}
		else {
			//exclusive mode
			GetDlgItem(IDC_RD_IMG_PROC_DEFAULT).EnableWindow(TRUE);
			GetDlgItem(IDC_RD_IMG_PROC_PIV).EnableWindow(TRUE);
			GetDlgItem(IDC_RD_IMG_PROC_ENH).EnableWindow(TRUE);
			GetDlgItem(IDC_RD_IMG_PROC_ENH2).EnableWindow(TRUE);
		}
	}

	LRESULT OnPad(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled) {
		if (!m_bStreamingMode) {
			StopCapture();
			Refresh();
			StartCapture();
		}

		bHandled = TRUE;
		return 0;
	}

	LRESULT OnFinger(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM lParam, BOOL& bHandled){
		DPFPDD_CAPTURE_CALLBACK_DATA_0* pCaptureData = reinterpret_cast<DPFPDD_CAPTURE_CALLBACK_DATA_0*>(lParam);
		if(NULL != pCaptureData){
			if(DPFPDD_SUCCESS == pCaptureData->error){
				if(pCaptureData->capture_result.success){
					//captured
					DrawBitmap(&pCaptureData->capture_result.info, pCaptureData->image_data);
				}
				else if(DPFPDD_QUALITY_CANCELED == pCaptureData->capture_result.quality){
					//capture canceled
				}
				else{
					//bad quality
					QualityMsg(pCaptureData->capture_result.quality);
				}
			}
			else{
				ErrorMsg(_T("error during asyncronous capture"), pCaptureData->error);
			}

			//free memory
			delete [] reinterpret_cast<char*>(pCaptureData);
		}

		bHandled = TRUE; 
		return 0;
	}

	void DrawBitmap(const DPFPDD_IMAGE_INFO* pImageInfo, const unsigned char* pImageData){
		//we work only with 8bpp images
		if(8 != pImageInfo->bpp) return;

		size_t nPackedRowSize = (pImageInfo->width / sizeof(LONG)) + ( (pImageInfo->width % sizeof(LONG)) ? 1 : 0 );
		nPackedRowSize *= sizeof(LONG);
		size_t nOffsetToDIBits = sizeof(BITMAPINFO) + (256 - 1) * sizeof(RGBQUAD);
		unsigned char* pBuffer = new unsigned char[nOffsetToDIBits + nPackedRowSize * pImageInfo->height];
		if(NULL == pBuffer) return;

		unsigned char* pDIBits = pBuffer + nOffsetToDIBits;
		//header
		BITMAPINFO* pbmi = (BITMAPINFO*)pBuffer;
		pbmi->bmiHeader.biSize = sizeof(BITMAPINFOHEADER);
		pbmi->bmiHeader.biWidth = pImageInfo->width;
		pbmi->bmiHeader.biHeight = pImageInfo->height;
		pbmi->bmiHeader.biPlanes = 1;
		pbmi->bmiHeader.biBitCount = pImageInfo->bpp;
		pbmi->bmiHeader.biCompression = BI_RGB;
		pbmi->bmiHeader.biSizeImage = 0;
		pbmi->bmiHeader.biXPelsPerMeter = 0;
		pbmi->bmiHeader.biYPelsPerMeter = 0;
		pbmi->bmiHeader.biClrUsed = 0;
		pbmi->bmiHeader.biClrImportant = 0;
		//color table
		for(int i = 0; i < 256; i++){ 
			pbmi->bmiColors[i].rgbBlue = i;
			pbmi->bmiColors[i].rgbGreen = i;
			pbmi->bmiColors[i].rgbRed = i;
			pbmi->bmiColors[i].rgbReserved = 0;
		}
		//di bits
		for(unsigned int row = 0; row < pImageInfo->height; row++){
			unsigned char* pDest = pDIBits + (pImageInfo->height - 1 - row) * nPackedRowSize;
			const unsigned char* pSrc = pImageData + pImageInfo->width * row;
			memcpy(pDest, pSrc, pImageInfo->width);
		}

		//draw
		CWindow wndFprint = GetDlgItem(IDC_FPRINT);
		HDC hdc = wndFprint.GetDC();
		if(NULL != hdc){
			RECT rect;
			wndFprint.GetClientRect(&rect);

			int nDestW = rect.right - rect.left;
			int nDestH = rect.bottom - rect.top;
			int nDestX = rect.left;
			int nDestY = rect.top;
			int nSrcX = ((int)pImageInfo->width - nDestW) / 2;
			if(0 > nSrcX){
				nDestX = -1 * nSrcX;
				nDestW = pImageInfo->width;
				nSrcX = 0;
			}
			int nSrcY = ((int)pImageInfo->height - nDestH) / 2;
			if(0 > nSrcY){
				nDestY = -1 * nSrcY;
				nDestH = pImageInfo->height;
				nSrcY = 0;
			}
			StretchDIBits(hdc, nDestX, nDestY, nDestW, nDestH, nSrcX, nSrcY, nDestW, nDestH, pDIBits, pbmi, DIB_RGB_COLORS, SRCCOPY);

			wndFprint.ReleaseDC(hdc);
		}

		delete [] pBuffer;
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
			CCaptureDlg* pThis = reinterpret_cast<CCaptureDlg*>(pContext);
			pThis->PostMessage(WM_FINGERMSG, 0, reinterpret_cast<LPARAM>(pBuffer));
		}
	}

	static DWORD WINAPI StreamingThread(void* pargs){
		CCaptureDlg* pThis = (CCaptureDlg*)pargs;
		unsigned dpi;

		pThis->m_bStopStreaming = false;
		CoInitializeEx(NULL, 0);

		//open reader
		int result = dpfpdd_open(pThis->m_szReaderName, &pThis->m_hReader);
		if(DPFPDD_SUCCESS != result){
			ErrorMsg(_T("error when calling dpfpdd_open()"), result);
		}
		else if(0 !=(dpi = GetFirstDPI(pThis->m_hReader))){
			//set streaming mode
			result = dpfpdd_start_stream(pThis->m_hReader);
			if(DPFPDD_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfpdd_start_stream()"), result);
			}
			else{
				//prepare parameters and result
				DPFPDD_CAPTURE_PARAM cp = {0};
				cp.size = sizeof(cp);
				cp.image_fmt = DPFPDD_IMG_FMT_PIXEL_BUFFER;
				cp.image_proc = pThis->m_imgProc;
				cp.image_res = dpi;
				DPFPDD_CAPTURE_RESULT cr = {0};
				cr.size = sizeof(cr);
				cr.info.size = sizeof(cr.info);
				//get size of the image
				unsigned int nImageSize = 0;
				result = dpfpdd_get_stream_image(pThis->m_hReader, &cp, &cr, &nImageSize, NULL);
				if(DPFPDD_E_MORE_DATA != result){
					ErrorMsg(_T("error when calling dpfpdd_get_stream_image() to query image size"), result);
				}
				else{
					unsigned char* pImage = new unsigned char[nImageSize];
					if(NULL == pImage){
						ErrorMsg(_T("insufficient memory for the image"), 0);
					}
					else{
						while(1){
							if(pThis->m_bStopStreaming){
								//streaming canceled 
								break;
							}

							//check reader status
							DPFPDD_DEV_STATUS ds = {0};
							ds.size = sizeof(ds);
							result = dpfpdd_get_device_status(pThis->m_hReader, &ds);
							if(DPFPDD_SUCCESS != result){
								ErrorMsg(_T("error when calling dpfpdd_get_device_status()"), result, pThis->m_hWnd);
								break;
							}
							else if(DPFPDD_STATUS_FAILURE == ds.status){
								ErrorMsg(_T("reader failure, status: "), ds.status, pThis->m_hWnd);
								break;
							}

							//get image
							cp.image_proc = pThis->m_imgProc;
							result = dpfpdd_get_stream_image(pThis->m_hReader, &cp, &cr, &nImageSize, pImage);
							if(DPFPDD_SUCCESS != result){
								ErrorMsg(_T("error when calling dpfpdd_get_stream_image()"), result, pThis->m_hWnd);
								break;
							}
							if(cr.success){
								//captured
								pThis->DrawBitmap(&cr.info, pImage);
							}
						}
						//release memory
						delete [] pImage;
					}
				}

				//exit streaming mode
				result = dpfpdd_stop_stream(pThis->m_hReader);
				if(DPFPDD_SUCCESS != result){
					ErrorMsg(_T("error when calling dpfpdd_stop_stream()"), result, pThis->m_hWnd);
				}
			}
			//close reader
			result = dpfpdd_close(pThis->m_hReader);
			if(DPFPDD_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfpdd_close()"), result);
			}
		}

		pThis->m_hReader = NULL;
		pThis->PostMessage(WM_COMMAND, IDOK, 0);
	
		CoUninitialize();
		
		return 0;
	}

};

