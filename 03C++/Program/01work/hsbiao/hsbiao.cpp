
#include "stdafx.h"
#include "hsbiao.h"
#include "hsbiaoDlg.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

/////////////////////////////////////////////////////////////////////////////
// CHsbiaoApp

BEGIN_MESSAGE_MAP(CHsbiaoApp, CWinApp)
	//{{AFX_MSG_MAP(CHsbiaoApp)
	//}}AFX_MSG_MAP
	ON_COMMAND(ID_HELP, CWinApp::OnHelp)
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CHsbiaoApp construction

CHsbiaoApp::CHsbiaoApp()
{
	// TODO: add construction code here,

}

/////////////////////////////////////////////////////////////////////////////

CHsbiaoApp theApp;

/////////////////////////////////////////////////////////////////////////////
// CHsbiaoApp initialization

BOOL CHsbiaoApp::InitInstance()
{
	AfxEnableControlContainer();

#ifdef _AFXDLL
	Enable3dControls();			// Call this when using MFC in a shared DLL
#else
	Enable3dControlsStatic();	// Call this when linking to MFC statically
#endif

	CHsbiaoDlg dlg;
	m_pMainWnd = &dlg;
	int nResponse = dlg.DoModal();
	if (nResponse == IDOK)
	{
		// TODO: Place code here to handle when the dialog is

	}
	else if (nResponse == IDCANCEL)
	{
		// TODO: Place code here to handle when the dialog is

	}

	return FALSE;
}
