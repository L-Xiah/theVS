
#if !defined(AFX_HSBIAO_H__96A41347_9BCA_11D2_8C07_444553540000__INCLUDED_)
#define AFX_HSBIAO_H__96A41347_9BCA_11D2_8C07_444553540000__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif 

#ifndef __AFXWIN_H__
	#error include 'stdafx.h' before including this file for PCH
#endif

#include "resource.h"		

/////////////////////////////////////////////////////////////////////////////
// CHsbiaoApp:
// See hsbiao.cpp for the implementation of this class

class CHsbiaoApp : public CWinApp
{
public:
	CHsbiaoApp();

// Overrides
	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CHsbiaoApp)
	public:
	virtual BOOL InitInstance();
	//}}AFX_VIRTUAL

// Implementation

	//{{AFX_MSG(CHsbiaoApp)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

/////////////////////////////////////////////////////////////////////////////

//{{AFX_INSERT_LOCATION}}
// Microsoft Developer Studio will insert additional declarations immediately before the previous line.

#endif 
