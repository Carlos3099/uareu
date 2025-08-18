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
// Reader enumeration dialog
//
//////////////////////////////////////////////////////////////////////////////

#pragma once

#include "Helpers.h"

////////////////////////////////////////////////////////////////////////////////////
// displays capabilities of the reader

class CReaderCaps: public CDialogImpl<CReaderCaps>
{
protected:
	const DPFPDD_DEV_INFO* m_pDevInfo;
	const DPFPDD_DEV_CAPS* m_pDevCaps;

public:
	enum { IDD = IDD_DLG_READER_CAPS };

	BEGIN_MSG_MAP(CReaderCaps)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		COMMAND_RANGE_HANDLER(IDOK, IDNO, OnClose)
	END_MSG_MAP()

	CReaderCaps(const DPFPDD_DEV_INFO* pDevInfo, const DPFPDD_DEV_CAPS* pDevCaps):
		m_pDevInfo(pDevInfo), m_pDevCaps(pDevCaps)
	{}

	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled){
		CenterWindow();
		CListBox lstCaps = GetDlgItem(IDC_LST_CAPS);
		INT nTabStop = 100;
		lstCaps.SetTabStops(1, &nTabStop);

		//name
		TCHAR tszText[MAX_PATH];
		StringToLPTSTR(m_pDevInfo->name, tszText, _countof(tszText));
		GetDlgItem(IDC_EDIT_NAME).SetWindowText(tszText);
		//serial
		StringToLPTSTR(m_pDevInfo->descr.serial_num, tszText, _countof(tszText));
		GetDlgItem(IDC_EDIT_SERIAL).SetWindowText(tszText);

		//capabilities
		_stprintf_s(tszText, _countof(tszText), _T("can capture image: \t %d"), m_pDevCaps->can_capture_image);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("can stream image: \t %d"), m_pDevCaps->can_stream_image);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("can extract features: \t %d"), m_pDevCaps->can_extract_features);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("can match: \t %d"), m_pDevCaps->can_match);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("can identify:\t %d"), m_pDevCaps->can_identify);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("has fingerprint storage: \t %d"), m_pDevCaps->has_fp_storage);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("indicator type: \t 0x%x"), m_pDevCaps->indicator_type);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("has power management: \t %d"), m_pDevCaps->has_pwr_mgmt);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("has calibration: \t %d"), m_pDevCaps->has_calibration);
		lstCaps.AddString(tszText);
		_stprintf_s(tszText, _countof(tszText), _T("PIV compliant: \t %d"), m_pDevCaps->piv_compliant);
		lstCaps.AddString(tszText);
		for(unsigned int i = 0; i < m_pDevCaps->resolution_cnt; i++){
			_stprintf_s(tszText, _countof(tszText), _T("resolution: \t %d dpi"), m_pDevCaps->resolutions[i]);
			lstCaps.AddString(tszText);
		}

		bHandled = TRUE;
		return 0;
    };

	LRESULT OnClose(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		bHandled = TRUE; 
		EndDialog(wID);
		return 0;
    };
};

////////////////////////////////////////////////////////////////////////////////////
// reader enumeration and selection

class CReaderDlg: public CDialogImpl<CReaderDlg>
{
protected:
	unsigned int     m_nReadersCnt;
	DPFPDD_DEV_INFO* m_pReaders;
	int              m_nSelected;
	DPFPDD_DEV_CAPS* m_pSelectedCaps;

public:
	enum { IDD = IDD_DLG_READER };

	BEGIN_MSG_MAP(CReaderDlg)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		COMMAND_ID_HANDLER(IDC_BTN_CAPS, OnCapabilities)
		COMMAND_ID_HANDLER(IDC_BTN_REFRESH, OnRefresh)
		COMMAND_ID_HANDLER(IDC_LST_READERS, OnList)
		COMMAND_RANGE_HANDLER(IDOK, IDNO, OnClose)
	END_MSG_MAP()

	CReaderDlg(){
		m_nReadersCnt = 0;
		m_pReaders = NULL;
		m_nSelected = -1;
		m_pSelectedCaps = NULL;
	}

	~CReaderDlg(){
		ClearSelection();
	}

	const char* GetSelectedName() const {
		if(0 > m_nSelected) return NULL;
		else return m_pReaders[m_nSelected].name;
	}

	void ClearSelection(){
		if(m_pReaders) delete [] m_pReaders;
		m_nReadersCnt = 0;
		m_pReaders = NULL;
		if(m_pSelectedCaps) delete m_pSelectedCaps;
		m_nSelected = -1;
		m_pSelectedCaps = NULL;
	}

	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled){
		CenterWindow();
		OnRefresh(0, 0, NULL, bHandled);
		return 0;
    };

	LRESULT OnClose(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		bHandled = TRUE; 
		EndDialog(wID);
		return 0;
    };

    LRESULT OnCapabilities(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		CListBox lstReaders = GetDlgItem(IDC_LST_READERS);
		int nSelected = lstReaders.GetCurSel();
		if(-1 != nSelected && nSelected < static_cast<int>(m_nReadersCnt) && NULL != m_pReaders){
			//open reader
			DPFPDD_DEV dev = NULL;
			int result = dpfpdd_open_ext(m_pReaders[nSelected].name, DPFPDD_PRIORITY_COOPERATIVE, &dev);
			if(DPFPDD_SUCCESS != result){
				ErrorMsg(_T("error when calling dpfpdd_open_ext()"), result);
			}
			else{
				//get required size for the capabilities structure
				int size = sizeof(unsigned int);
				DPFPDD_DEV_CAPS* pCaps = new DPFPDD_DEV_CAPS;
				if(pCaps){
					pCaps->size = sizeof(DPFPDD_DEV_CAPS);
					int result = dpfpdd_get_device_capabilities(dev, pCaps);
					if(DPFPDD_E_MORE_DATA == result){
						//allocate new memory and acquire capabilities one more time
						int needed_size = pCaps->size;
						delete pCaps;
						pCaps = (DPFPDD_DEV_CAPS*)new char[needed_size];
						if(pCaps){
							pCaps->size = needed_size;
							result = dpfpdd_get_device_capabilities(dev, pCaps);
						}
					}

					if(DPFPDD_SUCCESS == result){
						//display capabilities
						CReaderCaps dlg(&m_pReaders[nSelected], pCaps);
						dlg.DoModal();
					}

					delete pCaps;
				}

				//close reader
				result = dpfpdd_close(dev);
				if(DPFPDD_SUCCESS != result) ErrorMsg(_T("error when calling dpfpdd_close()"), result);

			}
		}

		bHandled = TRUE;
		return 0;
    };

    LRESULT OnRefresh(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		CListBox lstReaders = GetDlgItem(IDC_LST_READERS);
		lstReaders.ResetContent();
		GetDlgItem(IDC_BTN_CAPS).EnableWindow(FALSE);

		ClearSelection();

		//enumerate readers
		while(DPFPDD_E_MORE_DATA == dpfpdd_query_devices(&m_nReadersCnt, m_pReaders)){
			if(NULL != m_pReaders) delete [] m_pReaders;
			m_pReaders = new DPFPDD_DEV_INFO[m_nReadersCnt];
			if(NULL == m_pReaders){
				m_nReadersCnt = 0;
				break;
			}
			else m_pReaders[0].size = sizeof(DPFPDD_DEV_INFO);
		}

		if(NULL != m_pReaders){
			for(unsigned int i = 0; i < m_nReadersCnt; i++){
				TCHAR tszName[_countof(m_pReaders[i].name)];
				StringToLPTSTR(m_pReaders[i].name, tszName, _countof(tszName));
				lstReaders.AddString(tszName);
			}
		}

		bHandled = TRUE;
		return 0;
    };

	LRESULT OnList(WORD wNotifyCode, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		if(LBN_SELCHANGE == wNotifyCode){
			CListBox lstReaders = GetDlgItem(IDC_LST_READERS);
			CButton btnCaps = GetDlgItem(IDC_BTN_CAPS);

			m_nSelected = lstReaders.GetCurSel();
			if(-1 == m_nSelected){
				btnCaps.EnableWindow(FALSE);
				ClearSelection();
			}
			else{
				btnCaps.EnableWindow(TRUE);
			}
		}

		bHandled = TRUE;
		return 0;
    };
};

