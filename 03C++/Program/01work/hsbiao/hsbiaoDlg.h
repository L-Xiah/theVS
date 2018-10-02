
#if !defined(AFX_HSBIAODLG_H__96A41349_9BCA_11D2_8C07_444553540000__INCLUDED_)
#define AFX_HSBIAODLG_H__96A41349_9BCA_11D2_8C07_444553540000__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif 

/////////////////////////////////////////////////////////////////////////////
// CHsbiaoDlg dialog

#include "IfcHSB.h"

class CHsbiaoDlg : public CDialog
{
// Construction
public:
	CHsbiaoDlg(CWnd* pParent = NULL);	

void hp_f_ClickedEdit( int ii );
void hp_f_Input_CheckBox( int ii );
void hp_f_Unit( int ii );
void hp_f_ClearEditBox( void );
void hp_f_SetEditFocus( int ii );
void hp_f_Calculate( int ii );
void hp_f_MenuChecked( int ii );
void hp_f_setParameterMenuChecked( void );

int hp_i_SetFocus_YL;
int hp_i_SetFocus_WD;
int hp_i_SetFocus_BRONG;
int hp_i_SetFocus_HAN;
int hp_i_SetFocus_SH;
int hp_i_SetFocus_GD;
int hp_i_SetFocus_BRE;
int hp_i_SetFocus_DR;
int hp_i_SetFocus_ND;

CIfcHSB IfcHSB;

	//{{AFX_DATA(CHsbiaoDlg)
	enum { IDD = IDD_HSBIAO_DIALOG };
	CButton	m_BUTTON_OK;
	BOOL	m_CHECK_BAOHE;
	BOOL	m_CHECK_WD;
	BOOL	m_CHECK_SH;
	BOOL	m_CHECK_HAN;
	BOOL	m_CHECK_GD;
	BOOL	m_CHECK_BRONG;
	int		m_RADIO_ZHQI;
	int		m_RADIO_GUOJI;
	BOOL	m_CHECK_YL;
	CString	m_EDIT_YL;
	CString	m_EDIT_BRE;
	CString	m_EDIT_BRONG;
	CString	m_EDIT_DR;
	CString	m_EDIT_GD;
	CString	m_EDIT_HAN;
	CString	m_EDIT_ND;
	CString	m_EDIT_SH;
	CString	m_EDIT_WD;
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CHsbiaoDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);	
	//}}AFX_VIRTUAL

// Implementation
protected:
	HICON m_hIcon;

	// Generated message map functions
	//{{AFX_MSG(CHsbiaoDlg)
	virtual BOOL OnInitDialog();
	afx_msg void OnSysCommand(UINT nID, LPARAM lParam);
	afx_msg void OnPaint();
	afx_msg HCURSOR OnQueryDragIcon();
	afx_msg void OnCheckYl();
	afx_msg void OnCheckBaohe();
	afx_msg void OnButtonCancel();
	afx_msg void OnButtonOk();
	afx_msg void OnSetfocusEditYL();
	afx_msg void OnSetfocusEditWd();
	afx_msg void OnSetfocusEditSh();
	afx_msg void OnSetfocusEditHan();
	afx_msg void OnSetfocusEditGd();
	afx_msg void OnSetfocusEditBrong();
	afx_msg void OnSetfocusEditBre();
	afx_msg void OnSetfocusEditDr();
	afx_msg void OnSetfocusEditNd();
	afx_msg void OnCheckWd();
	afx_msg void OnCheckSh();
	afx_msg void OnCheckHan();
	afx_msg void OnCheckGd();
	afx_msg void OnCheckBrong();
	afx_msg void OnRadioGongcheng();
	afx_msg void OnRadioGuoji();
	afx_msg void OnRadioYingzhi();
	afx_msg void OnRadioZhqi();
	afx_msg void OnRadioShui();
	afx_msg void OnKillfocusEditBrong();
	afx_msg void OnKillfocusEditGd();
	afx_msg void OnKillfocusEditHan();
	afx_msg void OnKillfocusEditSh();
	afx_msg void OnKillfocusEditWd();
	afx_msg void OnKillfocusEditYl();
	afx_msg void OnMenuExit();
	afx_msg void OnMenuBaohe();
	afx_msg void OnMenuShui();
	afx_msg void OnMenuZhqi();
	afx_msg void OnMenuGuoji();
	afx_msg void OnMenuGongcheng();
	afx_msg void OnMenuYingzhi();
	afx_msg void OnMenuPt();
	afx_msg void OnMenuPh();
	afx_msg void OnMenuPs();
	afx_msg void OnMenuPv();
	afx_msg void OnMenuPx();
	afx_msg void OnMenuTh();
	afx_msg void OnMenuTs();
	afx_msg void OnMenuTv();
	afx_msg void OnMenuTx();
	afx_msg void OnMenuHs();
	afx_msg void OnMenuPZhqi();
	afx_msg void OnMenuPShui();
	afx_msg void OnMenuTZhqi();
	afx_msg void OnMenuTShui();
	afx_msg void OnMenuBrongZhqi();
	afx_msg void OnMenuBrongShui();
	afx_msg void OnMenuHZhqi();
	afx_msg void OnMenuHShui();
	afx_msg void OnMenuShuoming();
	afx_msg void OnMenuGuanyu();
	afx_msg void OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags);
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif 
