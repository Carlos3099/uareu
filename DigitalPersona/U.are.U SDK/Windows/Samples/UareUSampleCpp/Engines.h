//////////////////////////////////////////////////////////////////////////////
//
// Copyright (c) 2016 Crossmatch Tech., Inc.
//
// U.are.U SDK 3.x
//
//////////////////////////////////////////////////////////////////////////////
//
// Sample code
//
// Engine selection dialog
//
//////////////////////////////////////////////////////////////////////////////

#pragma once

#include "Helpers.h"


////////////////////////////////////////////////////////////////////////////////////
// engine selection

class CEngineDlg: public CDialogImpl<CEngineDlg>
{
protected:
	unsigned int     m_nEnginesCnt;

public:
	int              m_nSelected;
	enum { IDD = IDD_DLG_ENGINE };

	BEGIN_MSG_MAP(CEngineDlg)
		MESSAGE_HANDLER(WM_INITDIALOG, OnInitDialog)
		COMMAND_ID_HANDLER(IDC_LST_ENGINES, OnList)
		COMMAND_RANGE_HANDLER(IDOK, IDNO, OnClose)
	END_MSG_MAP()

	CEngineDlg(){
		m_nEnginesCnt = 2;
	
	}

	~CEngineDlg(){
	}



	LRESULT OnInitDialog(UINT /*uMsg*/, WPARAM /*wParam*/, LPARAM /*lParam*/, BOOL& bHandled){
		CenterWindow();
		CListBox lstEngines = GetDlgItem(IDC_LST_ENGINES);

		lstEngines.AddString(_T("Select DPFR Engine 6"));
		lstEngines.AddString(_T("Select DPFR Engine 7"));

		lstEngines.SetCurSel(m_nSelected);
		return 0;
    };

	LRESULT OnClose(WORD /*wNotifyCode*/, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){ 
		bHandled = TRUE; 
		EndDialog(wID);
		return 0;
    };

  
	LRESULT OnList(WORD wNotifyCode, WORD wID, HWND /*hWndCtl*/, BOOL& bHandled){
		if(LBN_SELCHANGE == wNotifyCode){
			CListBox lstEngines = GetDlgItem(IDC_LST_ENGINES);

			m_nSelected = lstEngines.GetCurSel();
			if( m_nSelected == 1)
				dpfj_select_engine(NULL, DPFJ_ENGINE_DPFJ7);
			else
				dpfj_select_engine(NULL, DPFJ_ENGINE_DPFJ);		

		}

		bHandled = TRUE;
		return 0;
    };
};

