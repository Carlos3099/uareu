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
// Entry point of the application
//
//////////////////////////////////////////////////////////////////////////////


#include "stdafx.h"
#include "resource.h"

#include <string.h>

// DigitalPersona API
#include <dpfpdd.h>
#include <dpfj.h>

#include "Helpers.h"
#include "Enumeration.h"
#include "Capture.h"
#include "Verification.h"
#include "Identification.h"
#include "Enrollment.h"
#include "Engines.h"

/////////////////////////////////////////////////////////////////////////////////////////////////////
// main window

class CMainDlg: public CDialogImpl<CMainDlg>
{
protected:
	char m_szReaderName[MAX_PATH];
	HICON m_hIcon;
	unsigned int m_nSelectedEngine;

public:
	enum { IDD = IDD_DLG_MAIN };

	BEGIN_MSG_MAP(CMainDlg)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		COMMAND_ID_HANDLER(IDC_BTN_READER, OnReader)
		COMMAND_ID_HANDLER(IDC_BTN_ENGINE, OnEngine)
		COMMAND_ID_HANDLER(IDC_BTN_CAPTURE, OnCapture)
		COMMAND_ID_HANDLER(IDC_BTN_STREAMING, OnStreaming)
		COMMAND_ID_HANDLER(IDC_BTN_VERIFY, OnVerify)
		COMMAND_ID_HANDLER(IDC_BTN_IDENTIFY, OnIdentify)
		COMMAND_ID_HANDLER(IDC_BTN_ENROLL, OnEnroll)
		COMMAND_ID_HANDLER(IDC_BTN_ABOUT, OnAbout)
		COMMAND_RANGE_HANDLER(IDOK, IDNO, OnClose)
	END_MSG_MAP()

	CMainDlg(){
		m_nSelectedEngine = 0;
		strncpy_s(m_szReaderName,  _countof(m_szReaderName), "", _TRUNCATE);
		m_hIcon = (HICON)LoadImage(GetModuleHandle(NULL), MAKEINTRESOURCE(IDI_ICON1), IMAGE_ICON, 0, 0, LR_DEFAULTSIZE);
	};

	~CMainDlg(){
		DestroyIcon(m_hIcon);
	};

	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled){
		SetIcon(m_hIcon);
		CenterWindow();
		Refresh();

		bHandled = TRUE;
		return 0;
    };

	LRESULT OnReader(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		CReaderDlg dlgReader;
		dlgReader.DoModal();

		const char* szReaderName = dlgReader.GetSelectedName();
		if(NULL != szReaderName) strncpy_s(m_szReaderName, _countof(m_szReaderName), szReaderName, _TRUNCATE);
		else strncpy_s(m_szReaderName, _countof(m_szReaderName), "", _TRUNCATE);

		Refresh();
		bHandled = TRUE; 
		return 0;
    };

	
	LRESULT OnEngine(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		CEngineDlg dlgEngine;	 
		dlgEngine.m_nSelected = m_nSelectedEngine;
		dlgEngine.DoModal();
		m_nSelectedEngine = dlgEngine.m_nSelected;

		bHandled = TRUE; 
		return 0;
    };

	LRESULT OnCapture(WORD wNotifyCode, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		CCaptureDlg dlgCapture(m_szReaderName);
		dlgCapture.SetStreamingMode(false);
		dlgCapture.DoModal();
		strncpy_s(m_szReaderName, _countof(m_szReaderName), dlgCapture.GetSelectedName(), _TRUNCATE);
		
		Refresh();
		bHandled = TRUE; 
		return 0;
    };

	LRESULT OnStreaming(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		CCaptureDlg dlgCapture(m_szReaderName);
		dlgCapture.SetStreamingMode(true);
		dlgCapture.DoModal();
		strncpy_s(m_szReaderName, _countof(m_szReaderName), dlgCapture.GetSelectedName(), _TRUNCATE);

		Refresh();
		bHandled = TRUE; 
		return 0;
    };

	LRESULT OnVerify(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		CVerifyDlg dlgVerify(m_szReaderName);
		dlgVerify.DoModal();
		strncpy_s(m_szReaderName, _countof(m_szReaderName), dlgVerify.GetSelectedName(), _TRUNCATE);

		Refresh();
		bHandled = TRUE; 
		return 0;
    };

	LRESULT OnIdentify(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		CIdentifyDlg dlgIdentify(m_szReaderName);
		dlgIdentify.DoModal();
		strncpy_s(m_szReaderName, _countof(m_szReaderName), dlgIdentify.GetSelectedName(), _TRUNCATE);

		Refresh();
		bHandled = TRUE; 
		return 0;
    };

	LRESULT OnEnroll(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		CEnrollDlg dlgEnroll(m_szReaderName);
		dlgEnroll.DoModal();
		strncpy_s(m_szReaderName, _countof(m_szReaderName), dlgEnroll.GetSelectedName(), _TRUNCATE);

		Refresh();
		bHandled = TRUE; 
		return 0;
    };

	LRESULT OnAbout(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		CSimpleDialog<IDD_ABOUTBOX> dlgAbout;
		dlgAbout.DoModal();
		bHandled = TRUE; 
		return 0;
    };

	LRESULT OnClose(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		bHandled = TRUE; 
		EndDialog(wID);
		return 0;
    };

	void Refresh(){
		if(0 == strlen(m_szReaderName)){
			GetDlgItem(IDC_BTN_CAPTURE).EnableWindow(FALSE);
			GetDlgItem(IDC_BTN_STREAMING).EnableWindow(FALSE);
			GetDlgItem(IDC_BTN_VERIFY).EnableWindow(FALSE);
			GetDlgItem(IDC_BTN_IDENTIFY).EnableWindow(FALSE);
			GetDlgItem(IDC_BTN_ENROLL).EnableWindow(FALSE);
			GetDlgItem(IDC_EDIT_NAME).SetWindowText(_T(""));
		}
		else{
			GetDlgItem(IDC_BTN_CAPTURE).EnableWindow(TRUE);
			GetDlgItem(IDC_BTN_STREAMING).EnableWindow(TRUE);
			GetDlgItem(IDC_BTN_VERIFY).EnableWindow(TRUE);
			GetDlgItem(IDC_BTN_IDENTIFY).EnableWindow(TRUE);
			GetDlgItem(IDC_BTN_ENROLL).EnableWindow(TRUE);
			TCHAR tszText[MAX_PATH];
			StringToLPTSTR(m_szReaderName, tszText, _countof(tszText));
			GetDlgItem(IDC_EDIT_NAME).SetWindowText(tszText);
		}
	}
};


////////////////////////////////////////////////////
// entry point

int WINAPI WinMain(HINSTANCE hInstance,
                   HINSTANCE hPrevInstance,
                   LPSTR     lpCmdLine,
                   int       nCmdShow)
{
	//initialize capture lib
	int result = dpfpdd_init();
	if(DPFPDD_SUCCESS != result){
		ErrorMsg(_T("error when calling dpfpdd_init()"), result);
	}
	else{
		CoInitializeEx(NULL, 0);

		CMainDlg dlg;
		dlg.DoModal();

		dpfpdd_exit();

		CoUninitialize();
	}

	return 0;
}
