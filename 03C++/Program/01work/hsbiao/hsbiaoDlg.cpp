
#include "stdafx.h"
#include "hsbiao.h"
#include "hsbiaoDlg.h"

#include <stdio.h>
#include <stdlib.h>
#include <io.h>
#include "sys\\stat.h"
#include <fcntl.h>
#include <string.h>
#include <time.h>
#include "math.h"
#include "direct.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#undef THIS_FILE
static char THIS_FILE[] = __FILE__;
#endif

#define MACRO_EXE_FILE_LENGTH ((long)102400 ) 

////////////////////////////////////////////////////////////////////////

double	g_dMyApplicationVersionNumber = 8.107; 
char	hp_s_version[64] = "MYAPPLICATION_VER  8.107"; 

char	g_szMyApplicationFileName[256] = "\\\\10.32.1.20\\01_部门共享\\02_技术部\\01_设计研究所\\08_共享\\软件\\应用软件\\hsbiao\\hsbiao.exe"; 
int		g_MyID1 = 0x78563412;
int		g_iSpecSingleFlag = 0; 
int		g_iMyClassID = 1628;
int		g_iEnglish = 0; 
WORD	g_wLangPID; 
int		g_MyID2 = 0x78563412;
//extern	int BanBenHao( );
//extern	int InitHSB( ); 

////////////////////////////////////////////////////////////////////////

#define DD0 (2)

#define DELTA (1E-8)
#define MIN_P 0.0001
#define MAX_P 100.0
#define MIN_T (1E-30)
#define MAX_T 800.0

int hp_i_old_unit;
int hp_i_old_focus;
int hp_i_new_focus;

long hp_l_clock;

char * hp_f_DoubleToStr( double dd );

// char * hp_f_strstr( char *ptr1, char *ptr2, unsigned ui ); // 2002.7.4

/////////////////////////////////////////////////////////////////////////////
// CAboutDlg dialog used for App About

class CAboutDlg : public CDialog
{
public:
	CAboutDlg();

	//{{AFX_DATA(CAboutDlg)
	enum { IDD = IDD_ABOUTBOX };
	//}}AFX_DATA

	// ClassWizard generated virtual function overrides
	//{{AFX_VIRTUAL(CAboutDlg)
	protected:
	virtual void DoDataExchange(CDataExchange* pDX);    
	//}}AFX_VIRTUAL

// Implementation
protected:
	//{{AFX_MSG(CAboutDlg)
	//}}AFX_MSG
	DECLARE_MESSAGE_MAP()
};

CAboutDlg::CAboutDlg() : CDialog(CAboutDlg::IDD)
{
	//{{AFX_DATA_INIT(CAboutDlg)
	//}}AFX_DATA_INIT
}

void CAboutDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CAboutDlg)
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CAboutDlg, CDialog)
	//{{AFX_MSG_MAP(CAboutDlg)

	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CHsbiaoDlg dialog

CHsbiaoDlg::CHsbiaoDlg(CWnd* pParent )
	: CDialog(CHsbiaoDlg::IDD, pParent)
{
	//{{AFX_DATA_INIT(CHsbiaoDlg)
	m_CHECK_BAOHE = FALSE;
	m_CHECK_WD = FALSE;
	m_CHECK_SH = FALSE;
	m_CHECK_HAN = FALSE;
	m_CHECK_GD = FALSE;
	m_CHECK_BRONG = FALSE;
	m_RADIO_ZHQI = -1;
	m_RADIO_GUOJI = -1;
	m_CHECK_YL = FALSE;
	m_EDIT_YL = _T("");
	m_EDIT_BRE = _T("");
	m_EDIT_BRONG = _T("");
	m_EDIT_DR = _T("");
	m_EDIT_GD = _T("");
	m_EDIT_HAN = _T("");
	m_EDIT_ND = _T("");
	m_EDIT_SH = _T("");
	m_EDIT_WD = _T("");
	//}}AFX_DATA_INIT

	m_hIcon = AfxGetApp()->LoadIcon(IDI_ICON1);
}

void CHsbiaoDlg::DoDataExchange(CDataExchange* pDX)
{
	CDialog::DoDataExchange(pDX);
	//{{AFX_DATA_MAP(CHsbiaoDlg)
	DDX_Control(pDX, IDC_BUTTON_OK, m_BUTTON_OK);
	DDX_Check(pDX, IDC_CHECK_BAOHE, m_CHECK_BAOHE);
	DDX_Check(pDX, IDC_CHECK_WD, m_CHECK_WD);
	DDX_Check(pDX, IDC_CHECK_SH, m_CHECK_SH);
	DDX_Check(pDX, IDC_CHECK_HAN, m_CHECK_HAN);
	DDX_Check(pDX, IDC_CHECK_GD, m_CHECK_GD);
	DDX_Check(pDX, IDC_CHECK_BRONG, m_CHECK_BRONG);
	DDX_Radio(pDX, IDC_RADIO_ZHQI, m_RADIO_ZHQI);
	DDX_Radio(pDX, IDC_RADIO_GUOJI, m_RADIO_GUOJI);
	DDX_Check(pDX, IDC_CHECK_YL, m_CHECK_YL);
	DDX_Text(pDX, IDC_EDIT_YL, m_EDIT_YL);
	DDX_Text(pDX, IDC_EDIT_BRE, m_EDIT_BRE);
	DDX_Text(pDX, IDC_EDIT_BRONG, m_EDIT_BRONG);
	DDX_Text(pDX, IDC_EDIT_DR, m_EDIT_DR);
	DDX_Text(pDX, IDC_EDIT_GD, m_EDIT_GD);
	DDX_Text(pDX, IDC_EDIT_HAN, m_EDIT_HAN);
	DDX_Text(pDX, IDC_EDIT_ND, m_EDIT_ND);
	DDX_Text(pDX, IDC_EDIT_SH, m_EDIT_SH);
	DDX_Text(pDX, IDC_EDIT_WD, m_EDIT_WD);
	//}}AFX_DATA_MAP
}

BEGIN_MESSAGE_MAP(CHsbiaoDlg, CDialog)
	//{{AFX_MSG_MAP(CHsbiaoDlg)
	ON_WM_SYSCOMMAND()
	ON_WM_PAINT()
	ON_WM_QUERYDRAGICON()
	ON_BN_CLICKED(IDC_CHECK_YL, OnCheckYl)
	ON_BN_CLICKED(IDC_CHECK_BAOHE, OnCheckBaohe)
	ON_BN_CLICKED(IDC_BUTTON_CANCEL, OnButtonCancel)
	ON_BN_CLICKED(IDC_BUTTON_OK, OnButtonOk)
	ON_EN_SETFOCUS(IDC_EDIT_YL, OnSetfocusEditYL)
	ON_EN_SETFOCUS(IDC_EDIT_WD, OnSetfocusEditWd)
	ON_EN_SETFOCUS(IDC_EDIT_SH, OnSetfocusEditSh)
	ON_EN_SETFOCUS(IDC_EDIT_HAN, OnSetfocusEditHan)
	ON_EN_SETFOCUS(IDC_EDIT_GD, OnSetfocusEditGd)
	ON_EN_SETFOCUS(IDC_EDIT_BRONG, OnSetfocusEditBrong)
	ON_EN_SETFOCUS(IDC_EDIT_BRE, OnSetfocusEditBre)
	ON_EN_SETFOCUS(IDC_EDIT_DR, OnSetfocusEditDr)
	ON_EN_SETFOCUS(IDC_EDIT_ND, OnSetfocusEditNd)
	ON_BN_CLICKED(IDC_CHECK_WD, OnCheckWd)
	ON_BN_CLICKED(IDC_CHECK_SH, OnCheckSh)
	ON_BN_CLICKED(IDC_CHECK_HAN, OnCheckHan)
	ON_BN_CLICKED(IDC_CHECK_GD, OnCheckGd)
	ON_BN_CLICKED(IDC_CHECK_BRONG, OnCheckBrong)
	ON_BN_CLICKED(IDC_RADIO_GONGCHENG, OnRadioGongcheng)
	ON_BN_CLICKED(IDC_RADIO_GUOJI, OnRadioGuoji)
	ON_BN_CLICKED(IDC_RADIO_YINGZHI, OnRadioYingzhi)
	ON_BN_CLICKED(IDC_RADIO_ZHQI, OnRadioZhqi)
	ON_BN_CLICKED(IDC_RADIO_SHUI, OnRadioShui)
	ON_EN_KILLFOCUS(IDC_EDIT_BRONG, OnKillfocusEditBrong)
	ON_EN_KILLFOCUS(IDC_EDIT_GD, OnKillfocusEditGd)
	ON_EN_KILLFOCUS(IDC_EDIT_HAN, OnKillfocusEditHan)
	ON_EN_KILLFOCUS(IDC_EDIT_SH, OnKillfocusEditSh)
	ON_EN_KILLFOCUS(IDC_EDIT_WD, OnKillfocusEditWd)
	ON_EN_KILLFOCUS(IDC_EDIT_YL, OnKillfocusEditYl)
	ON_COMMAND(ID_MENU_EXIT, OnMenuExit)
	ON_COMMAND(ID_MENU_BAOHE, OnMenuBaohe)
	ON_COMMAND(ID_MENU_SHUI, OnMenuShui)
	ON_COMMAND(ID_MENU_ZHQI, OnMenuZhqi)
	ON_COMMAND(ID_MENU_GUOJI, OnMenuGuoji)
	ON_COMMAND(ID_MENU_GONGCHENG, OnMenuGongcheng)
	ON_COMMAND(ID_MENU_YINGZHI, OnMenuYingzhi)
	ON_COMMAND(ID_MENU_PT, OnMenuPt)
	ON_COMMAND(ID_MENU_PH, OnMenuPh)
	ON_COMMAND(ID_MENU_PS, OnMenuPs)
	ON_COMMAND(ID_MENU_PV, OnMenuPv)
	ON_COMMAND(ID_MENU_PX, OnMenuPx)
	ON_COMMAND(ID_MENU_TH, OnMenuTh)
	ON_COMMAND(ID_MENU_TS, OnMenuTs)
	ON_COMMAND(ID_MENU_TV, OnMenuTv)
	ON_COMMAND(ID_MENU_TX, OnMenuTx)
	ON_COMMAND(ID_MENU_HS, OnMenuHs)
	ON_COMMAND(ID_MENU_P_ZHQI, OnMenuPZhqi)
	ON_COMMAND(ID_MENU_P_SHUI, OnMenuPShui)
	ON_COMMAND(ID_MENU_T_ZHQI, OnMenuTZhqi)
	ON_COMMAND(ID_MENU_T_SHUI, OnMenuTShui)
	ON_COMMAND(ID_MENU_BRONG_ZHQI, OnMenuBrongZhqi)
	ON_COMMAND(ID_MENU_BRONG_SHUI, OnMenuBrongShui)
	ON_COMMAND(ID_MENU_H_ZHQI, OnMenuHZhqi)
	ON_COMMAND(ID_MENU_H_SHUI, OnMenuHShui)
	ON_COMMAND(ID_MENU_SHUOMING, OnMenuShuoming)
	ON_COMMAND(ID_MENU_GUANYU, OnMenuGuanyu)
	ON_WM_KEYDOWN()
	//}}AFX_MSG_MAP
END_MESSAGE_MAP()

/////////////////////////////////////////////////////////////////////////////
// CHsbiaoDlg message handlers

BOOL CHsbiaoDlg::OnInitDialog()
{	CDialog::OnInitDialog();

	TCHAR exeFullPath[MAX_PATH]; 
	GetModuleFileName(NULL,exeFullPath,MAX_PATH); 
	{
		CString ssString;

		ssString.Format( "exeFullPath=%s", exeFullPath );

		CFileStatus rStatus;

		CFile::GetStatus( exeFullPath, rStatus );
		if ( rStatus.m_size != MACRO_EXE_FILE_LENGTH ) 
		{
			ssString.Format( "应用程序可能感染病毒, 请从共享目录中复制程序后再运行。\n" 
				"仍有问题, 请与管理员联系!" );
			MessageBox( ssString, "System", MB_ICONINFORMATION );

			exit( 0 );
		}
	}

	ASSERT((IDM_ABOUTBOX & 0xFFF0) == IDM_ABOUTBOX);
	ASSERT(IDM_ABOUTBOX < 0xF000);

	CMenu* pSysMenu = GetSystemMenu(FALSE);
	if (pSysMenu != NULL)
	{
		CString strAboutMenu;
		strAboutMenu.LoadString(IDS_ABOUTBOX);
		if (!strAboutMenu.IsEmpty())
		{
			pSysMenu->AppendMenu(MF_SEPARATOR);
			pSysMenu->AppendMenu(MF_STRING, IDM_ABOUTBOX, strAboutMenu);
		}
	}

	SetIcon(m_hIcon, TRUE);			
	SetIcon(m_hIcon, FALSE);		

	// TODO: Add extra initialization here

	int i=0;
	CString ss;

	g_wLangPID = PRIMARYLANGID(::GetSystemDefaultLangID());

	//i = InitHSB( );--Xiah
	if ( i != 0 )
	{

		exit( 0 );
	}

	if ( g_iEnglish == 0 && 
		 g_wLangPID == LANG_CHINESE ) 
	{
		if ( g_iSpecSingleFlag == 0 ) 
		{
			ss.Format( "水蒸汽焓熵表 网络版 %g", g_dMyApplicationVersionNumber );
		}
		else
		{
			ss.Format( "水蒸汽焓熵表 Version %g", g_dMyApplicationVersionNumber );
		}

		SetWindowText( ss ); 

		SetDlgItemText( IDC_CHECK_YL,    "压力" );
		SetDlgItemText( IDC_CHECK_WD,    "温度" );
		SetDlgItemText( IDC_CHECK_BRONG, "比容" );
		SetDlgItemText( IDC_CHECK_HAN,   "焓" );
		SetDlgItemText( IDC_CHECK_SH,    "熵" );
		SetDlgItemText( IDC_CHECK_GD,    "干度" );
	}
	else
	{
		CMenu *pMenu;
		CMenu * pMenu1;

		pMenu = GetMenu( ); 

		pMenu->ModifyMenu( 0, MF_BYPOSITION | MF_STRING, 0, "&File" );
		pMenu1 = pMenu->GetSubMenu( 0 );
		pMenu1->ModifyMenu( 0, MF_BYPOSITION | MF_STRING , ID_MENU_EXIT , "&Quit" );

		pMenu->ModifyMenu( 1, MF_BYPOSITION | MF_STRING, 0, "&Saturation" );
		pMenu1 = pMenu->GetSubMenu( 1 );
		pMenu1->ModifyMenu( 0, MF_BYPOSITION | MF_STRING, ID_MENU_BAOHE, "&Saturation" );
		pMenu1->ModifyMenu( 2, MF_BYPOSITION | MF_STRING, ID_MENU_ZHQI, "Saturation S&team" );
		pMenu1->ModifyMenu( 3, MF_BYPOSITION | MF_STRING, ID_MENU_SHUI, "Saturation &Water" );

		pMenu->ModifyMenu( 2, MF_BYPOSITION | MF_STRING, 0, "&Units" );
		pMenu1 = pMenu->GetSubMenu( 2 );
		pMenu1->ModifyMenu( 0, MF_BYPOSITION | MF_STRING, ID_MENU_GUOJI, "&International" );
		pMenu1->ModifyMenu( 1, MF_BYPOSITION | MF_STRING, ID_MENU_GONGCHENG, "&Engineering" );
		pMenu1->ModifyMenu( 2, MF_BYPOSITION | MF_STRING, ID_MENU_YINGZHI, "&British" );

		pMenu->ModifyMenu( 3, MF_BYPOSITION | MF_STRING, 0, "&Given" );
		pMenu1 = pMenu->GetSubMenu( 3 );
		pMenu1->ModifyMenu( 0, MF_BYPOSITION | MF_STRING, ID_MENU_P_ZHQI, "P @ Sat. Steam" );
		pMenu1->ModifyMenu( 1, MF_BYPOSITION | MF_STRING, ID_MENU_P_SHUI, "P @ Sat. Water" );
		pMenu1->ModifyMenu( 2, MF_BYPOSITION | MF_STRING, ID_MENU_T_ZHQI, "T @ Sat. Steam" );
		pMenu1->ModifyMenu( 3, MF_BYPOSITION | MF_STRING, ID_MENU_T_SHUI, "T @ Sat. Water" );

		pMenu1->ModifyMenu( 5, MF_BYPOSITION | MF_STRING, ID_MENU_PT, "P and T" );
		pMenu1->ModifyMenu( 6, MF_BYPOSITION | MF_STRING, ID_MENU_PH, "P and H" );
		pMenu1->ModifyMenu( 7, MF_BYPOSITION | MF_STRING, ID_MENU_PS, "P and S" );
		pMenu1->ModifyMenu( 8, MF_BYPOSITION | MF_STRING, ID_MENU_PV, "P and V" );
		pMenu1->ModifyMenu( 9, MF_BYPOSITION | MF_STRING, ID_MENU_PX, "P and D" );

		pMenu1->ModifyMenu( 11, MF_BYPOSITION | MF_STRING, ID_MENU_TH, "T and H" );
		pMenu1->ModifyMenu( 12, MF_BYPOSITION | MF_STRING, ID_MENU_TS, "T and S" );
		pMenu1->ModifyMenu( 13, MF_BYPOSITION | MF_STRING, ID_MENU_TV, "T and V" );
		pMenu1->ModifyMenu( 14, MF_BYPOSITION | MF_STRING, ID_MENU_TX, "T and D" );

		pMenu1->ModifyMenu( 16, MF_BYPOSITION | MF_STRING, ID_MENU_HS, "H and S" );

		pMenu1->ModifyMenu( 18, MF_BYPOSITION | MF_STRING, ID_MENU_BRONG_ZHQI, "V @ Sat. Steam" );
		pMenu1->ModifyMenu( 19, MF_BYPOSITION | MF_STRING, ID_MENU_BRONG_SHUI, "V @ Sat. Water" );
		pMenu1->ModifyMenu( 20, MF_BYPOSITION | MF_STRING, ID_MENU_H_ZHQI, "H @ Sat. Steam" );
		pMenu1->ModifyMenu( 21, MF_BYPOSITION | MF_STRING, ID_MENU_H_SHUI, "H @ Sat. Water" );

		pMenu->ModifyMenu( 4, MF_BYPOSITION | MF_STRING, 0, "&Help" );
		pMenu1 = pMenu->GetSubMenu( 4 );
		pMenu1->ModifyMenu( 0, MF_BYPOSITION | MF_STRING, ID_MENU_SHUOMING, "&Illustrate" );
		pMenu1->ModifyMenu( 1, MF_BYPOSITION | MF_STRING, ID_MENU_GUANYU, "&About..." );

		ss.Format( "Inquire about water and steam parameters version %g",
			g_dMyApplicationVersionNumber );
		SetWindowText( ss ); 

		SetDlgItemText( IDC_CHECK_YL,    "Pressure" );
		SetDlgItemText( IDC_CHECK_WD,    "Temp." );
		SetDlgItemText( IDC_CHECK_BRONG, "Sp. V" );
		SetDlgItemText( IDC_CHECK_HAN,   "Enthalpy" );
		SetDlgItemText( IDC_CHECK_SH,    "Entropy" );
		SetDlgItemText( IDC_CHECK_GD,    "Dryness" );
	}

	if ( g_iEnglish == 1 || 
		 g_wLangPID == LANG_ENGLISH ) 
	{
		CMenu *pMenu;
		CMenu * pMenu1;

		pMenu = GetMenu( );
		pMenu1 = pMenu->GetSubMenu( 3 );

		for ( int i = 17; i < 22; i++ )
		{
			pMenu1->RemoveMenu( 17, MF_BYPOSITION );
		}
	}

	if ( g_iEnglish == 0 && 
		 g_wLangPID == LANG_CHINESE ) 
	{
		SetDlgItemText( IDC_STATIC_BRE,  "比热" );
		SetDlgItemText( IDC_STATIC_DR,   "导热系数" );
		SetDlgItemText( IDC_STATIC_ND,   "粘度" );
	}
	else
	{
		GetDlgItem( IDC_STATIC_BRE ) -> ShowWindow( SW_HIDE ); 
		GetDlgItem( IDC_STATIC_DR ) -> ShowWindow( SW_HIDE );
		GetDlgItem( IDC_STATIC_ND ) -> ShowWindow( SW_HIDE );
		GetDlgItem( IDC_STATIC_U_BRE ) -> ShowWindow( SW_HIDE ); 
		GetDlgItem( IDC_STATIC_U_DR ) -> ShowWindow( SW_HIDE );
		GetDlgItem( IDC_STATIC_U_ND ) -> ShowWindow( SW_HIDE );
		GetDlgItem( IDC_EDIT_BRE ) -> ShowWindow( SW_HIDE ); 
		GetDlgItem( IDC_EDIT_DR ) -> ShowWindow( SW_HIDE );
		GetDlgItem( IDC_EDIT_ND ) -> ShowWindow( SW_HIDE );
	}

	m_CHECK_YL    = TRUE;
	m_CHECK_WD    = TRUE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	if ( g_iEnglish == 0 && 
		 g_wLangPID == LANG_CHINESE ) 
	{
		SetDlgItemText( IDC_CHECK_BAOHE, "饱和状态" ); 
		CheckDlgButton( IDC_CHECK_BAOHE, 0 );
		GetDlgItem( IDC_RADIO_ZHQI ) -> EnableWindow( FALSE );
		GetDlgItem( IDC_RADIO_SHUI ) -> EnableWindow( FALSE );

		SetDlgItemText( IDC_RADIO_ZHQI,  "饱和蒸汽" ); 
		SetDlgItemText( IDC_RADIO_SHUI,  "饱和水" );
		CheckRadioButton( IDC_RADIO_ZHQI,
						  IDC_RADIO_SHUI,
						  IDC_RADIO_ZHQI );

		SetDlgItemText( IDC_RADIO_GUOJI,     "国际单位制" ); 
		SetDlgItemText( IDC_RADIO_GONGCHENG, "工程单位制" );
		SetDlgItemText( IDC_RADIO_YINGZHI,   "英制");
		CheckRadioButton( IDC_RADIO_GUOJI,
						  IDC_RADIO_YINGZHI,
						  IDC_RADIO_GUOJI );

		SetDlgItemText( IDC_BUTTON_OK,     "计   算" ); 
		SetDlgItemText( IDC_BUTTON_CANCEL, "退   出" );
	}
	else
	{
		SetDlgItemText( IDC_CHECK_BAOHE, "Saturation" ); 
		CheckDlgButton( IDC_CHECK_BAOHE, 0 );
		GetDlgItem( IDC_RADIO_ZHQI ) -> EnableWindow( FALSE );
		GetDlgItem( IDC_RADIO_SHUI ) -> EnableWindow( FALSE );

		SetDlgItemText( IDC_RADIO_ZHQI,  "Saturation Steam" ); 
		SetDlgItemText( IDC_RADIO_SHUI,  "Saturation Water" );
		CheckRadioButton( IDC_RADIO_ZHQI,
						  IDC_RADIO_SHUI,
						  IDC_RADIO_ZHQI );

		SetDlgItemText( IDC_RADIO_GUOJI,     "International" ); 
		SetDlgItemText( IDC_RADIO_GONGCHENG, "Engineering" );
		SetDlgItemText( IDC_RADIO_YINGZHI,   "British");
		CheckRadioButton( IDC_RADIO_GUOJI,
						  IDC_RADIO_YINGZHI,
						  IDC_RADIO_GUOJI );

		SetDlgItemText( IDC_BUTTON_OK,     "Calculate" ); 
		SetDlgItemText( IDC_BUTTON_CANCEL, "Quit" );
	}

	m_RADIO_ZHQI = 0;
	hp_i_old_unit = m_RADIO_GUOJI = 0;
	hp_f_Unit( 0 );

	hp_f_MenuChecked( 5 ); 

	return FALSE;
}

void CHsbiaoDlg::OnSysCommand(UINT nID, LPARAM lParam)
{
	if ((nID & 0xFFF0) == IDM_ABOUTBOX)
	{
		CAboutDlg dlgAbout;
		dlgAbout.DoModal();
	}
	else
	{
		CDialog::OnSysCommand(nID, lParam);
	}
}

void CHsbiaoDlg::OnPaint() 
{
	if (IsIconic())
	{
		CPaintDC dc(this); 

		SendMessage(WM_ICONERASEBKGND, (WPARAM) dc.GetSafeHdc(), 0);

		// Center icon in client rectangle
		int cxIcon = GetSystemMetrics(SM_CXICON);
		int cyIcon = GetSystemMetrics(SM_CYICON);
		CRect rect;
		GetClientRect(&rect);
		int x = (rect.Width() - cxIcon + 1) / 2;
		int y = (rect.Height() - cyIcon + 1) / 2;

		dc.DrawIcon(x, y, m_hIcon);
	}
	else
	{
		CDialog::OnPaint();
	}
}

HCURSOR CHsbiaoDlg::OnQueryDragIcon()
{
	return (HCURSOR) m_hIcon;
}

void CHsbiaoDlg::OnCheckBaohe() 
{
	// TODO: Add your control notification handler code here

	UpdateData( TRUE );
	if ( m_CHECK_BAOHE == TRUE )
	{	GetDlgItem( IDC_RADIO_ZHQI ) -> EnableWindow( TRUE );
		GetDlgItem( IDC_RADIO_SHUI ) -> EnableWindow( TRUE );
		if ( m_CHECK_YL == TRUE ) 
		{	m_CHECK_WD = FALSE;
			m_CHECK_BRONG = FALSE;
			m_CHECK_HAN = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
		}
		else if ( m_CHECK_WD == TRUE )
		{	m_CHECK_YL = FALSE;
			m_CHECK_BRONG = FALSE;
			m_CHECK_HAN = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_WD ) -> SetFocus( );
		}
		else if ( m_CHECK_HAN == TRUE && 
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
		{	m_CHECK_YL = FALSE;
			m_CHECK_WD = FALSE;
			m_CHECK_BRONG = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_WD ) -> SetFocus( );
		}
		else if ( m_CHECK_BRONG == TRUE && 
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
		{	m_CHECK_YL = FALSE;
			m_CHECK_WD = FALSE;
			m_CHECK_HAN = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_BRONG ) -> SetFocus( );
		}
		else
		{	m_CHECK_WD = FALSE;
			m_CHECK_BRONG = FALSE;
			m_CHECK_HAN = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
		}

		m_CHECK_SH    = FALSE;
		m_CHECK_GD    = FALSE;
		UpdateData( FALSE );
	}
	else
	{	GetDlgItem( IDC_RADIO_ZHQI ) -> EnableWindow( FALSE );
		GetDlgItem( IDC_RADIO_SHUI ) -> EnableWindow( FALSE );
		m_CHECK_YL    = TRUE;
		m_CHECK_WD    = TRUE;
		m_CHECK_BRONG = FALSE;
		m_CHECK_HAN   = FALSE;
		m_CHECK_SH    = FALSE;
		m_CHECK_GD    = FALSE;
		UpdateData( FALSE );
		GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
	}

	UpdateData( FALSE );

	hp_f_ClearEditBox( );
	hp_f_setParameterMenuChecked( );
}

void CHsbiaoDlg::hp_f_SetEditFocus( int ii )
{

	if ( ii == 0 ) goto set;

	if ( hp_i_old_focus == IDC_EDIT_YL && m_CHECK_YL == TRUE )
	{	GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
		goto end;
	}

	if ( hp_i_old_focus == IDC_EDIT_WD && m_CHECK_WD == TRUE )
	{	GetDlgItem( IDC_EDIT_WD ) -> SetFocus( );
		goto end;
	}

	if ( hp_i_old_focus == IDC_EDIT_HAN && m_CHECK_HAN == TRUE )
	{	GetDlgItem( IDC_EDIT_HAN ) -> SetFocus( );
		goto end;
	}

	if ( hp_i_old_focus == IDC_EDIT_SH && m_CHECK_SH == TRUE )
	{	GetDlgItem( IDC_EDIT_SH ) -> SetFocus( );
		goto end;
	}

	if ( hp_i_old_focus == IDC_EDIT_BRONG && m_CHECK_BRONG == TRUE )
	{	GetDlgItem( IDC_EDIT_BRONG ) -> SetFocus( );
		goto end;
	}

	if ( hp_i_old_focus == IDC_EDIT_GD && m_CHECK_GD == TRUE )
	{	GetDlgItem( IDC_EDIT_GD ) -> SetFocus( );
		goto end;
	}

set:
	if ( m_CHECK_YL == TRUE )
	{	GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
		goto end;
	}
	if ( m_CHECK_WD == TRUE )
	{	GetDlgItem( IDC_EDIT_WD ) -> SetFocus( );
		goto end;
	}

	if ( m_CHECK_HAN == TRUE )
	{	GetDlgItem( IDC_EDIT_HAN ) -> SetFocus( );
		goto end;
	}

	if ( m_CHECK_SH == TRUE )
	{	GetDlgItem( IDC_EDIT_SH ) -> SetFocus( );
		goto end;
	}

	if ( m_CHECK_BRONG == TRUE )
	{	GetDlgItem( IDC_EDIT_BRONG ) -> SetFocus( );
		goto end;
	}

	if ( m_CHECK_GD == TRUE )
	{	GetDlgItem( IDC_EDIT_GD ) -> SetFocus( );
		goto end;
	}

end:
	UpdateData( FALSE );
}

void CHsbiaoDlg::OnSetfocusEditYL() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_i_new_focus = IDC_EDIT_YL;
	hp_f_ClickedEdit( IDC_EDIT_YL );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	m_CHECK_YL == FALSE && strlen( m_EDIT_YL ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_YL, "压力", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_YL, "Pressure", NULL ); 
		}
	}
}

void CHsbiaoDlg::OnSetfocusEditWd() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_i_new_focus = IDC_EDIT_WD;
	hp_f_ClickedEdit( IDC_EDIT_WD );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	m_CHECK_WD == FALSE && strlen( m_EDIT_WD ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_WD, "温度", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_WD, "Temperature", NULL ); 
		}
	}
}

void CHsbiaoDlg::OnSetfocusEditHan() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_i_new_focus = IDC_EDIT_HAN;
	hp_f_ClickedEdit( IDC_EDIT_HAN );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	m_CHECK_HAN == FALSE && strlen( m_EDIT_HAN ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_HAN, "焓", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_HAN, "Enthalpy", NULL ); 
		}
	}
}

void CHsbiaoDlg::OnSetfocusEditSh() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_i_new_focus = IDC_EDIT_SH;
	hp_f_ClickedEdit( IDC_EDIT_SH );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	m_CHECK_SH == FALSE && strlen( m_EDIT_SH ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_SH, "熵", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_SH, "Entropy", NULL ); 
		}
	}
}

void CHsbiaoDlg::OnSetfocusEditBrong() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_i_new_focus = IDC_EDIT_BRONG;
	hp_f_ClickedEdit( IDC_EDIT_BRONG );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	m_CHECK_BRONG == FALSE && strlen( m_EDIT_BRONG ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_BRONG, "比容", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_BRONG, "Sp. V", NULL ); 
		}
	}
}

void CHsbiaoDlg::OnSetfocusEditGd() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_i_new_focus = IDC_EDIT_GD;
	hp_f_ClickedEdit( IDC_EDIT_GD );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	m_CHECK_GD == FALSE && strlen( m_EDIT_GD ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_GD, "干度", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_GD, "Dryness", NULL ); 
		}
	}
}

void CHsbiaoDlg::OnSetfocusEditBre() 
{
	// TODO: Add your control notification handler code here
	hp_f_ClickedEdit( -1 );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	strlen( m_EDIT_BRE ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_BRE, "比热", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_BRE, "BIRE", NULL ); 
		}
	}
}

void CHsbiaoDlg::OnSetfocusEditDr() 
{
	// TODO: Add your control notification handler code here
	hp_f_ClickedEdit( -1 );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	strlen( m_EDIT_DR ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_DR, "导热系数", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_DR, "DR", NULL ); 
		}
	}
}

void CHsbiaoDlg::OnSetfocusEditNd() 
{
	// TODO: Add your control notification handler code here
	hp_f_ClickedEdit( -1 );

	if ( ( ::GetKeyState( VK_CONTROL ) & 0xfffe ) &&
	strlen( m_EDIT_ND ) > 9 )
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{
			MessageBox( m_EDIT_ND, "粘度", NULL ); 
		}
		else
		{
			MessageBox( m_EDIT_ND, "ND", NULL ); 
		}
	}
}

void CHsbiaoDlg::hp_f_ClickedEdit( int ii ) 
{
	if ( ii == IDC_EDIT_YL    && m_CHECK_YL    == TRUE ) goto end;
	if ( ii == IDC_EDIT_WD    && m_CHECK_WD    == TRUE ) goto end;
	if ( ii == IDC_EDIT_HAN   && m_CHECK_HAN   == TRUE ) goto end;
	if ( ii == IDC_EDIT_SH    && m_CHECK_SH    == TRUE ) goto end;
	if ( ii == IDC_EDIT_BRONG && m_CHECK_BRONG == TRUE ) goto end;
	if ( ii == IDC_EDIT_GD    && m_CHECK_GD    == TRUE ) goto end;

	hp_f_SetEditFocus( 0 );

end:
	;
}

void CHsbiaoDlg::OnCheckYl() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Input_CheckBox( IDC_CHECK_YL );
}

void CHsbiaoDlg::OnCheckWd() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Input_CheckBox( IDC_CHECK_WD );
}

void CHsbiaoDlg::OnCheckHan() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Input_CheckBox( IDC_CHECK_HAN );
}

void CHsbiaoDlg::OnCheckSh() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Input_CheckBox( IDC_CHECK_SH );
}

void CHsbiaoDlg::OnCheckBrong() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Input_CheckBox( IDC_CHECK_BRONG );
}

void CHsbiaoDlg::OnCheckGd() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Input_CheckBox( IDC_CHECK_GD );
}

void CHsbiaoDlg::hp_f_Input_CheckBox( int ii )
{
	if ( ii == IDC_CHECK_YL    && m_CHECK_YL    == FALSE ) goto CHECK_FALSE;
	if ( ii == IDC_CHECK_WD    && m_CHECK_WD    == FALSE ) goto CHECK_FALSE;
	if ( ii == IDC_CHECK_HAN   && m_CHECK_HAN   == FALSE ) goto CHECK_FALSE;
	if ( ii == IDC_CHECK_SH    && m_CHECK_SH    == FALSE ) goto CHECK_FALSE;
	if ( ii == IDC_CHECK_BRONG && m_CHECK_BRONG == FALSE ) goto CHECK_FALSE;
	if ( ii == IDC_CHECK_GD    && m_CHECK_GD    == FALSE ) goto CHECK_FALSE;
	goto CHECK_TRUE;

CHECK_FALSE:
	hp_f_SetEditFocus( 0 );
	goto end;

CHECK_TRUE: 
	if ( m_CHECK_BAOHE == TRUE ) 
	{
		if ( ii == IDC_CHECK_YL )
		{	m_CHECK_WD = FALSE;
			m_CHECK_BRONG = FALSE;
			m_CHECK_HAN = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
		}
		else if ( ii == IDC_CHECK_WD )
		{	m_CHECK_YL = FALSE;
			m_CHECK_BRONG = FALSE;
			m_CHECK_HAN = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_WD ) -> SetFocus( );
		}
		else if ( ii == IDC_CHECK_HAN && 
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
		{	m_CHECK_YL = FALSE;
			m_CHECK_WD = FALSE;
			m_CHECK_BRONG = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_HAN ) -> SetFocus( );
		}
		else if ( ii == IDC_CHECK_BRONG && 
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
		{	m_CHECK_YL = FALSE;
			m_CHECK_WD = FALSE;
			m_CHECK_HAN = FALSE;
			UpdateData( FALSE );
			GetDlgItem( IDC_EDIT_BRONG ) -> SetFocus( );
		}
		else
		{
			if ( m_CHECK_YL == TRUE ) 
			{	m_CHECK_WD = FALSE;
				m_CHECK_BRONG = FALSE;
				m_CHECK_HAN = FALSE;
				UpdateData( FALSE );
				GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
			}
			else if ( m_CHECK_WD == TRUE )
			{	m_CHECK_YL = FALSE;
				m_CHECK_BRONG = FALSE;
				m_CHECK_HAN = FALSE;
				UpdateData( FALSE );
				GetDlgItem( IDC_EDIT_WD ) -> SetFocus( );
			}
			else if ( m_CHECK_HAN == TRUE &&  
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
			{	m_CHECK_YL = FALSE;
				m_CHECK_WD = FALSE;
				m_CHECK_BRONG = FALSE;
				UpdateData( FALSE );
				GetDlgItem( IDC_EDIT_HAN ) -> SetFocus( );
			}
			else if ( m_CHECK_BRONG == TRUE && 
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
			{	m_CHECK_YL = FALSE;
				m_CHECK_WD = FALSE;
				m_CHECK_HAN = FALSE;
				UpdateData( FALSE );
				GetDlgItem( IDC_EDIT_BRONG ) -> SetFocus( );
			}
			else
			{	m_CHECK_WD = FALSE;
				m_CHECK_BRONG = FALSE;
				m_CHECK_HAN = FALSE;
				UpdateData( FALSE );
				GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
			}
		}

		m_CHECK_SH    = FALSE;
		m_CHECK_GD    = FALSE;
		UpdateData( FALSE );
		goto end;
	}

	if ( ii == IDC_CHECK_YL )
	{	if ( m_CHECK_WD    == TRUE ) goto YL_WD;
		if ( m_CHECK_HAN   == TRUE ) goto YL_HAN;
		if ( m_CHECK_SH    == TRUE ) goto YL_SH;
		if ( m_CHECK_BRONG == TRUE ) goto YL_BRONG;
		if ( m_CHECK_GD    == TRUE ) goto YL_GD;
		m_CHECK_WD = TRUE;
YL_WD:
		m_CHECK_HAN   = FALSE;
YL_HAN:
		m_CHECK_SH    = FALSE;
YL_SH:
		m_CHECK_BRONG = FALSE;
YL_BRONG:
		m_CHECK_GD    = FALSE;
YL_GD:
		UpdateData( FALSE );
		GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
		goto end;
	}

	if ( ii == IDC_CHECK_WD )
	{	if ( m_CHECK_YL    == TRUE ) goto WD_YL;
		if ( m_CHECK_HAN   == TRUE ) goto WD_HAN;
		if ( m_CHECK_SH    == TRUE ) goto WD_SH;
		if ( m_CHECK_BRONG == TRUE ) goto WD_BRONG;
		if ( m_CHECK_GD    == TRUE ) goto WD_GD;
		m_CHECK_YL = TRUE;
WD_YL:
		m_CHECK_HAN   = FALSE;
WD_HAN:
		m_CHECK_SH    = FALSE;
WD_SH:
		m_CHECK_BRONG = FALSE;
WD_BRONG:
		m_CHECK_GD    = FALSE;
WD_GD:
		UpdateData( FALSE );
		GetDlgItem( IDC_EDIT_WD ) -> SetFocus( );
		goto end;
	}

	if ( ii == IDC_CHECK_HAN )
	{	if ( m_CHECK_YL == TRUE ) goto HAN_YL;
		if ( m_CHECK_WD == TRUE ) goto HAN_WD;
		if ( m_CHECK_SH == TRUE ) goto HAN_SH;
		m_CHECK_YL = TRUE;
HAN_YL:
		m_CHECK_WD = FALSE;
HAN_WD:
		m_CHECK_SH = FALSE;
HAN_SH:
		m_CHECK_BRONG = FALSE;
		m_CHECK_GD    = FALSE;
		UpdateData( FALSE );
		GetDlgItem( IDC_EDIT_HAN ) -> SetFocus( );
		goto end;
	}

	if ( ii == IDC_CHECK_SH )
	{	if ( m_CHECK_YL  == TRUE ) goto SH_YL;
		if ( m_CHECK_WD  == TRUE ) goto SH_WD;
		if ( m_CHECK_HAN == TRUE ) goto SH_HAN;
		m_CHECK_YL = TRUE;
SH_YL:
		m_CHECK_WD = FALSE;
SH_WD:
		m_CHECK_HAN = FALSE;
SH_HAN:
		m_CHECK_BRONG = FALSE;
		m_CHECK_GD    = FALSE;
		UpdateData( FALSE );
		GetDlgItem( IDC_EDIT_SH ) -> SetFocus( );
		goto end;
	}

	if ( ii == IDC_CHECK_BRONG )
	{	if ( m_CHECK_YL  == TRUE ) goto BRONG_YL;
		if ( m_CHECK_WD  == TRUE ) goto BRONG_WD;
		m_CHECK_YL = TRUE;
BRONG_YL:
		m_CHECK_WD = FALSE;
BRONG_WD:
		m_CHECK_HAN = FALSE;
		m_CHECK_SH  = FALSE;
		m_CHECK_GD  = FALSE;
		UpdateData( FALSE );
		GetDlgItem( IDC_EDIT_BRONG ) -> SetFocus( );
		goto end;
	}
	if ( ii == IDC_CHECK_GD )
	{	if ( m_CHECK_YL  == TRUE ) goto GD_YL;
		if ( m_CHECK_WD  == TRUE ) goto GD_WD;
		m_CHECK_YL = TRUE;
GD_YL:
		m_CHECK_WD = FALSE;
GD_WD:
		m_CHECK_HAN   = FALSE;
		m_CHECK_SH    = FALSE;
		m_CHECK_BRONG = FALSE;
		UpdateData( FALSE );
		GetDlgItem( IDC_EDIT_GD ) -> SetFocus( );
		goto end;
	}

end:
	hp_f_ClearEditBox( );
	hp_f_setParameterMenuChecked( );
}

void CHsbiaoDlg::hp_f_ClearEditBox( void )
{
	if ( m_CHECK_YL == FALSE || m_EDIT_YL == "0" )
	{	m_EDIT_YL = "";
	}
	if ( m_CHECK_WD == FALSE || m_EDIT_WD == "0" )
	{	m_EDIT_WD = "";
	}
	if ( m_CHECK_HAN == FALSE || m_EDIT_HAN == "0" )
	{	m_EDIT_HAN = "";
	}
	if ( m_CHECK_SH == FALSE || m_EDIT_SH == "0" )
	{	m_EDIT_SH = "";
	}
	if ( m_CHECK_BRONG == FALSE || m_EDIT_BRONG == "0" )
	{	m_EDIT_BRONG = "";
	}
	if ( m_CHECK_GD == FALSE || m_EDIT_GD == "0" )
	{	m_EDIT_GD = "";
	}
	m_EDIT_ND = "";
	m_EDIT_DR = "";
	m_EDIT_BRE = "";
	UpdateData( FALSE );
}

void CHsbiaoDlg::OnRadioGuoji() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Unit( 0 );

	{	CMenu *pMenu;
		CMenu * pMenu1;

		pMenu = GetMenu( );
		pMenu1 = pMenu->GetSubMenu( 2 );

		pMenu1->CheckMenuItem( ID_MENU_GUOJI,     MF_BYCOMMAND | MF_CHECKED );
		pMenu1->CheckMenuItem( ID_MENU_GONGCHENG, MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->CheckMenuItem( ID_MENU_YINGZHI,   MF_BYCOMMAND | MF_UNCHECKED );
	}
}

void CHsbiaoDlg::OnRadioGongcheng() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Unit( 0 );

	{	CMenu *pMenu;
		CMenu * pMenu1;

		pMenu = GetMenu( );
		pMenu1 = pMenu->GetSubMenu( 2 );

		pMenu1->CheckMenuItem( ID_MENU_GUOJI,     MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->CheckMenuItem( ID_MENU_GONGCHENG, MF_BYCOMMAND | MF_CHECKED );
		pMenu1->CheckMenuItem( ID_MENU_YINGZHI,   MF_BYCOMMAND | MF_UNCHECKED );
	}
}

void CHsbiaoDlg::OnRadioYingzhi() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );
	hp_f_Unit( 0 );

	{	CMenu *pMenu;
		CMenu * pMenu1;

		pMenu = GetMenu( );
		pMenu1 = pMenu->GetSubMenu( 2 );

		pMenu1->CheckMenuItem( ID_MENU_GUOJI,     MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->CheckMenuItem( ID_MENU_GONGCHENG, MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->CheckMenuItem( ID_MENU_YINGZHI,   MF_BYCOMMAND | MF_CHECKED );
	}
}

void CHsbiaoDlg::hp_f_Unit( int ii )
{

	if ( ii == 1 ) goto disp;

	if ( hp_i_old_unit == 0 )
	{	IfcHSB.hp_d_ptv[0] = strtod( m_EDIT_YL, NULL );
		IfcHSB.hp_d_ptv[1] = strtod( m_EDIT_WD, NULL );
		IfcHSB.hp_d_ptv[2] = strtod( m_EDIT_BRONG, NULL );
		IfcHSB.hp_d_ptv[3] = strtod( m_EDIT_HAN, NULL );
		IfcHSB.hp_d_ptv[4] = strtod( m_EDIT_SH, NULL );
		IfcHSB.hp_d_ptv[5] = strtod( m_EDIT_GD, NULL );
		IfcHSB.hp_d_ptv[6] = strtod( m_EDIT_ND, NULL );
		IfcHSB.hp_d_ptv[7] = strtod( m_EDIT_DR, NULL );
		IfcHSB.hp_d_ptv[8] = strtod( m_EDIT_BRE, NULL );
	}
	else if ( hp_i_old_unit == 1 ) 
	{	IfcHSB.hp_d_ptv[0] = strtod( m_EDIT_YL, NULL ) / 10.1972;
		IfcHSB.hp_d_ptv[1] = strtod( m_EDIT_WD, NULL );
		IfcHSB.hp_d_ptv[2] = strtod( m_EDIT_BRONG, NULL );
		IfcHSB.hp_d_ptv[3] = strtod( m_EDIT_HAN, NULL ) / 0.2388459;
		IfcHSB.hp_d_ptv[4] = strtod( m_EDIT_SH, NULL ) / 0.2388459;
		IfcHSB.hp_d_ptv[5] = strtod( m_EDIT_GD, NULL );
		IfcHSB.hp_d_ptv[6] = strtod( m_EDIT_ND, NULL ) / 0.101972;
		IfcHSB.hp_d_ptv[7] = strtod( m_EDIT_DR, NULL ) / 0.859845;
		IfcHSB.hp_d_ptv[8] = strtod( m_EDIT_BRE, NULL ) / 0.2388459;
	}
	else if ( hp_i_old_unit == 2 ) 
	{	IfcHSB.hp_d_ptv[0] = strtod( m_EDIT_YL, NULL ) / 145.0377;
		IfcHSB.hp_d_ptv[1] = (strtod( m_EDIT_WD, NULL ) - 32.0 ) / 1.8;
		IfcHSB.hp_d_ptv[2] = strtod( m_EDIT_BRONG, NULL ) / 16.0185;
		IfcHSB.hp_d_ptv[3] = strtod( m_EDIT_HAN, NULL ) / 0.429923;
		IfcHSB.hp_d_ptv[4] = strtod( m_EDIT_SH, NULL ) / 0.2388459;
		IfcHSB.hp_d_ptv[5] = strtod( m_EDIT_GD, NULL );
		IfcHSB.hp_d_ptv[6] = strtod( m_EDIT_ND, NULL ) / 2419.0884;
		IfcHSB.hp_d_ptv[7] = strtod( m_EDIT_DR, NULL ) / 0.577789;
		IfcHSB.hp_d_ptv[8] = strtod( m_EDIT_BRE, NULL ) / 0.2388459;
	}

	if ( ii == 2 ) goto end;
disp:
	if ( m_RADIO_GUOJI == 0 )
	{	m_EDIT_YL    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[0] );
		m_EDIT_WD    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[1] );
		m_EDIT_BRONG = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[2] );
		m_EDIT_HAN   = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[3] );
		m_EDIT_SH    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[4] );
		m_EDIT_GD    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[5] );
		m_EDIT_ND    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[6] );
		m_EDIT_DR    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[7] );
		m_EDIT_BRE   = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[8] );
		SetDlgItemText( IDC_STATIC_U_YL,    "MPa" );
		SetDlgItemText( IDC_STATIC_U_WD,    "℃" );
		SetDlgItemText( IDC_STATIC_U_BRONG, "m^3/Kg" );
		SetDlgItemText( IDC_STATIC_U_HAN,   "KJ/Kg" );
		SetDlgItemText( IDC_STATIC_U_SH,    "KJ/Kg*K" );
		SetDlgItemText( IDC_STATIC_U_GD,    "" );
		SetDlgItemText( IDC_STATIC_U_ND,    "1E-6 Pa*s" );
		SetDlgItemText( IDC_STATIC_U_DR,    "1E-3 W/m*K" );
		SetDlgItemText( IDC_STATIC_U_BRE,   "KJ/Kg*K" );
	}
	else if ( m_RADIO_GUOJI == 1 ) 
	{	m_EDIT_YL    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[0] * 10.1972 );
		m_EDIT_WD    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[1] );
		m_EDIT_BRONG = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[2] );
		m_EDIT_HAN   = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[3] * 0.2388459 );
		m_EDIT_SH    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[4] * 0.2388459 );
		m_EDIT_GD    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[5] );
		m_EDIT_ND    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[6] * 0.101972 );
		m_EDIT_DR    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[7] * 0.859845 );
		m_EDIT_BRE   = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[8] * 0.2388459 );

		SetDlgItemText( IDC_STATIC_U_YL,    "Kgf/CM^2" );
		SetDlgItemText( IDC_STATIC_U_WD,    "℃" );
		SetDlgItemText( IDC_STATIC_U_BRONG, "m^3/Kg" );
		SetDlgItemText( IDC_STATIC_U_HAN,   "Kcal/Kg" );
		SetDlgItemText( IDC_STATIC_U_SH,    "Kcal/Kg*C" );
		SetDlgItemText( IDC_STATIC_U_GD,    "" );
		SetDlgItemText( IDC_STATIC_U_ND,    "1E-6 Kgf*s/m^2" );
		SetDlgItemText( IDC_STATIC_U_DR,    "1E-3 Kcal/m*h*C" );
		SetDlgItemText( IDC_STATIC_U_BRE,   "Kcal/Kg*C" );
	}
	else if ( m_RADIO_GUOJI == 2 ) 
	{	m_EDIT_YL    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[0] * 145.0377 );
		m_EDIT_WD    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[1] * 1.8 + 32.0 );
		m_EDIT_BRONG = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[2] * 16.0185 );
		m_EDIT_HAN   = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[3] * 0.429923 );
		m_EDIT_SH    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[4] * 0.2388459 );
		m_EDIT_GD    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[5] );
		m_EDIT_ND    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[6] * 2419.0884 ); 
		m_EDIT_DR    = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[7] * 0.577789 ); 
		m_EDIT_BRE   = hp_f_DoubleToStr( IfcHSB.hp_d_ptv[8] * 0.2388459 );
		SetDlgItemText( IDC_STATIC_U_YL,    "psi" );
		SetDlgItemText( IDC_STATIC_U_WD,    "F" ); 
		SetDlgItemText( IDC_STATIC_U_BRONG, "ft^3/lb" );
		SetDlgItemText( IDC_STATIC_U_HAN,   "Btu/lb" );
		SetDlgItemText( IDC_STATIC_U_SH,    "Btu/lb*F" );
		SetDlgItemText( IDC_STATIC_U_GD,    "" );
		SetDlgItemText( IDC_STATIC_U_ND,    "1E-6 lb/h*ft" );
		SetDlgItemText( IDC_STATIC_U_DR,    "1E-3 Btu/ft*h*F" );
		SetDlgItemText( IDC_STATIC_U_BRE,   "Btu/lb*F" );
	}
	if ( m_EDIT_YL    == "0" ) m_EDIT_YL    = "";
	if ( m_EDIT_WD    == "0" ) m_EDIT_WD    = "";
	if ( m_EDIT_BRONG == "0" ) m_EDIT_BRONG = "";
	if ( m_EDIT_HAN   == "0" ) m_EDIT_HAN   = "";
	if ( m_EDIT_SH    == "0" ) m_EDIT_SH    = "";

	if ( m_EDIT_ND    == "0" ) m_EDIT_ND    = "";
	if ( m_EDIT_DR    == "0" ) m_EDIT_DR    = "";
	if ( m_EDIT_BRE   == "0" ) m_EDIT_BRE   = "";
	UpdateData( FALSE );

	hp_i_old_unit = m_RADIO_GUOJI;

	hp_f_SetEditFocus( 1 );
end:
	;
}

char * hp_f_DoubleToStr( double dd )
{	static char hp_s_DoubleToStr[256];

	sprintf( hp_s_DoubleToStr, "%.7g", dd );

	return hp_s_DoubleToStr;
}

void CHsbiaoDlg::OnKillfocusEditYl() 
{
	// TODO: Add your control notification handler code here
	hp_i_old_focus = IDC_EDIT_YL;	
}

void CHsbiaoDlg::OnKillfocusEditWd() 
{
	// TODO: Add your control notification handler code here
	hp_i_old_focus = IDC_EDIT_WD;	
}

void CHsbiaoDlg::OnKillfocusEditHan() 
{
	// TODO: Add your control notification handler code here
	hp_i_old_focus = IDC_EDIT_HAN;	
}

void CHsbiaoDlg::OnKillfocusEditSh() 
{
	// TODO: Add your control notification handler code here
	hp_i_old_focus = IDC_EDIT_SH;	
}

void CHsbiaoDlg::OnKillfocusEditBrong() 
{
	// TODO: Add your control notification handler code here
	hp_i_old_focus = IDC_EDIT_BRONG;	
}

void CHsbiaoDlg::OnKillfocusEditGd() 
{
	// TODO: Add your control notification handler code here
	hp_i_old_focus = IDC_EDIT_GD;
}

void CHsbiaoDlg::OnRadioZhqi() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );

	hp_f_Calculate( 1 );
}

void CHsbiaoDlg::OnRadioShui() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );

	hp_f_Calculate( 1 );
}

void CHsbiaoDlg::OnButtonCancel() 
{
	// TODO: Add your control notification handler code here
	CString ss;

	if ( ( ::GetKeyState( VK_CONTROL ) & 0x8000 ) == 0x8000 && 
		 ( ::GetKeyState( VK_MENU ) & 0x8000 ) == 0x8000 ) 
	{

	}
	else
	{
		OnOK( );
	}
}

void CHsbiaoDlg::OnButtonOk() 
{
	// TODO: Add your control notification handler code here
	UpdateData( TRUE );

	hp_f_Calculate( 0 );
}

void CHsbiaoDlg::hp_f_Calculate( int ii )
{	int i=0;
	static int flag;
	static double pold, told, hanold, brongold;

	//i = InitHSB( ); Xiah
	if ( i != 0 )
	{
		return;
	}

	i = 0;
	hp_f_Unit( 2 );
	if ( m_CHECK_BAOHE == FALSE ) goto baohe_false;

	if ( m_CHECK_YL == TRUE && pold != IfcHSB.hp_d_ptv[0] ||
		 m_CHECK_WD == TRUE && told != IfcHSB.hp_d_ptv[1] ||
		 m_CHECK_BRONG == TRUE && brongold != IfcHSB.hp_d_ptv[2] &&  
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE || 
		 m_CHECK_HAN == TRUE && hanold != IfcHSB.hp_d_ptv[3] &&  
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
		 flag = 0;

	if ( ii == 0 && flag == 1 )
	{	if ( m_RADIO_ZHQI == 0 )
			m_RADIO_ZHQI = 1;
		else
			m_RADIO_ZHQI = 0;

		UpdateData( FALSE );
	}
	flag = 1;

	if ( m_CHECK_YL == TRUE ) 
	{
		if ( m_RADIO_ZHQI == 0 )
		{
			i = IfcHSB.hp_ifczhqip( IfcHSB.hp_d_ptv[0] );
		}
		else if ( m_RADIO_ZHQI == 1 )
		{
			i = IfcHSB.hp_ifcshuip( IfcHSB.hp_d_ptv[0] );
		}
		else
		{
		}
	}
	else if ( m_CHECK_WD == TRUE )
	{
		if ( m_RADIO_ZHQI == 0 )
		{	
			i = IfcHSB.hp_ifczhqit( IfcHSB.hp_d_ptv[1] );
		}
		else if ( m_RADIO_ZHQI == 1 )
		{
			i = IfcHSB.hp_ifcshuit( IfcHSB.hp_d_ptv[1] );
		}
		else
		{
		}
	}
	else if ( m_CHECK_BRONG == TRUE && 
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
	{

		if ( IfcHSB.hp_d_ptv[2] >= 0.00317 || m_RADIO_ZHQI == 0 && IfcHSB.hp_d_ptv[2] == 0.0 )
		{
			m_RADIO_ZHQI = 0;
			i = IfcHSB.hp_ifczhqiv( IfcHSB.hp_d_ptv[2] );
		}
		else
		{
			m_RADIO_ZHQI = 1;
			i = IfcHSB.hp_ifcshuiv( IfcHSB.hp_d_ptv[2] );
		}
	}
	else if ( m_CHECK_HAN == TRUE &&  
				g_iEnglish == 0 && 
				g_wLangPID == LANG_CHINESE ) 
	{
		static int iHanFlag = 0;
		if ( IfcHSB.hp_d_ptv[3] > 2107.4 ) 
		{
			m_RADIO_ZHQI = 0;
			if ( IfcHSB.hp_d_ptv[3] < 2501.555 )
			{
				i = IfcHSB.hp_ifczhqih( IfcHSB.hp_d_ptv[3], 1 );
				iHanFlag = 0;
			}
			else
			{
				if ( iHanFlag == 0 )
				{
					i = IfcHSB.hp_ifczhqih( IfcHSB.hp_d_ptv[3], 0 );
					iHanFlag = 1;
				}
				else
				{
					i = IfcHSB.hp_ifczhqih( IfcHSB.hp_d_ptv[3], 1 );
					iHanFlag = 0;
				}
			}
		}
		else
		{
			m_RADIO_ZHQI = 1;
			i = IfcHSB.hp_ifcshuih( IfcHSB.hp_d_ptv[3] );
		}
	}
	else
	{
	}
	pold = IfcHSB.hp_d_ptv[0]; 
	told = IfcHSB.hp_d_ptv[1];
	brongold = IfcHSB.hp_d_ptv[2];
	hanold = IfcHSB.hp_d_ptv[3];

	goto common;

baohe_false:

	if ( hp_i_new_focus == IDC_EDIT_YL )
	{	if ( m_CHECK_WD    == TRUE ) i = IfcHSB.hp_ifcpt( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[1] );
		if ( m_CHECK_HAN   == TRUE ) i = IfcHSB.hp_ifcph( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[3] );
		if ( m_CHECK_SH    == TRUE ) i = IfcHSB.hp_ifcps( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[4] );
		if ( m_CHECK_BRONG == TRUE ) i = IfcHSB.hp_ifcpv( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[2] );
		if ( m_CHECK_GD    == TRUE ) i = IfcHSB.hp_ifcpx( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[5] );
	}
	if ( hp_i_new_focus == IDC_EDIT_WD )
	{	if ( m_CHECK_YL    == TRUE ) i = IfcHSB.hp_ifcpt( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[1] );
		if ( m_CHECK_HAN   == TRUE ) i = IfcHSB.hp_ifcth( IfcHSB.hp_d_ptv[1], IfcHSB.hp_d_ptv[3] );
		if ( m_CHECK_SH    == TRUE ) i = IfcHSB.hp_ifcts( IfcHSB.hp_d_ptv[1], IfcHSB.hp_d_ptv[4] );
		if ( m_CHECK_BRONG == TRUE ) i = IfcHSB.hp_ifctv( IfcHSB.hp_d_ptv[1], IfcHSB.hp_d_ptv[2] );
		if ( m_CHECK_GD    == TRUE ) i = IfcHSB.hp_ifctx( IfcHSB.hp_d_ptv[1], IfcHSB.hp_d_ptv[5] );
	}
	if ( hp_i_new_focus == IDC_EDIT_HAN )
	{	if ( m_CHECK_YL == TRUE ) i = IfcHSB.hp_ifcph( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[3] );
		if ( m_CHECK_WD == TRUE ) i = IfcHSB.hp_ifcth( IfcHSB.hp_d_ptv[1], IfcHSB.hp_d_ptv[3] );
		if ( m_CHECK_SH == TRUE ) i = IfcHSB.hp_ifchs( IfcHSB.hp_d_ptv[3], IfcHSB.hp_d_ptv[4] );
	}
	if ( hp_i_new_focus == IDC_EDIT_SH )
	{	if ( m_CHECK_YL  == TRUE ) i = IfcHSB.hp_ifcps( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[4] );
		if ( m_CHECK_WD  == TRUE ) i = IfcHSB.hp_ifcts( IfcHSB.hp_d_ptv[1], IfcHSB.hp_d_ptv[4] );
		if ( m_CHECK_HAN == TRUE ) i = IfcHSB.hp_ifchs( IfcHSB.hp_d_ptv[3], IfcHSB.hp_d_ptv[4] );
	}
	if ( hp_i_new_focus == IDC_EDIT_BRONG )
	{	if ( m_CHECK_YL == TRUE ) i = IfcHSB.hp_ifcpv( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[2] );
		if ( m_CHECK_WD == TRUE ) i = IfcHSB.hp_ifctv( IfcHSB.hp_d_ptv[1], IfcHSB.hp_d_ptv[2] );
	}
	if ( hp_i_new_focus == IDC_EDIT_GD )
	{	if ( m_CHECK_YL == TRUE ) i = IfcHSB.hp_ifcpx( IfcHSB.hp_d_ptv[0], IfcHSB.hp_d_ptv[5] );
		if ( m_CHECK_WD == TRUE ) i = IfcHSB.hp_ifctx( IfcHSB.hp_d_ptv[1], IfcHSB.hp_d_ptv[5] );
	}

common:
	hp_f_setParameterMenuChecked( );

	if ( i == 0 ) 
	{	hp_f_Unit( 1 );
		hp_f_SetEditFocus( 1 );
		goto end;
	}
	else 
	{	hp_f_ClearEditBox( );
	}

	if ( i == 1 )
	{	GetDlgItem( IDC_EDIT_YL ) -> SetFocus( );
	}
	else if ( i == 2 )
	{	GetDlgItem( IDC_EDIT_WD ) -> SetFocus( );
	}
	else if ( i == 3 )
	{	GetDlgItem( IDC_EDIT_BRONG ) -> SetFocus( );
	}
	else if ( i == 4 )
	{	GetDlgItem( IDC_EDIT_HAN ) -> SetFocus( );
	}
	else if ( i == 5 )
	{	GetDlgItem( IDC_EDIT_SH ) -> SetFocus( );
	}
	else if ( i == 6 )
	{	GetDlgItem( IDC_EDIT_GD ) -> SetFocus( );
	}
	else
	{
		if ( g_iEnglish == 0 && 
			 g_wLangPID == LANG_CHINESE ) 
		{

			MessageBox( "查水蒸汽焓熵表错误", "水蒸汽焓熵表", MB_ICONEXCLAMATION ); 

		}
		else 
		{
			MessageBox( "Error!", "Inquire about water and steam parameters",
				MB_ICONEXCLAMATION );
		}
	}

end:
	;
}

void CHsbiaoDlg::OnMenuExit() 
{
	// TODO: Add your command handler code here
	OnOK( );
}

void CHsbiaoDlg::OnMenuBaohe() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_BAOHE = !m_CHECK_BAOHE;
	UpdateData( FALSE );

	OnCheckBaohe();
}

void CHsbiaoDlg::OnMenuZhqi() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_RADIO_ZHQI = 0; 
	UpdateData( FALSE );

	OnRadioZhqi( ); 	
}

void CHsbiaoDlg::OnMenuShui() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_RADIO_ZHQI = 1; 
	UpdateData( FALSE );

	OnRadioShui( );
}

void CHsbiaoDlg::OnMenuGuoji() 
{
	// TODO: Add your command handler code here
	m_RADIO_GUOJI = 0; 
	UpdateData( FALSE );

	OnRadioGuoji();
}

void CHsbiaoDlg::OnMenuGongcheng() 
{
	// TODO: Add your command handler code here
	m_RADIO_GUOJI = 1; 
	UpdateData( FALSE );

	OnRadioGongcheng();
}

void CHsbiaoDlg::OnMenuYingzhi() 
{
	// TODO: Add your command handler code here
	m_RADIO_GUOJI = 2; 
	UpdateData( FALSE );

	OnRadioYingzhi();
}

void CHsbiaoDlg::OnMenuPZhqi()
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_YL    = TRUE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 0 );
}

void CHsbiaoDlg::OnMenuPShui() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_YL    = TRUE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 1 );
}

void CHsbiaoDlg::OnMenuTZhqi() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = TRUE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 2 );
}

void CHsbiaoDlg::OnMenuTShui() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = TRUE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 3 );
}

void CHsbiaoDlg::OnMenuBrongZhqi() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = TRUE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 18 );
}

void CHsbiaoDlg::OnMenuBrongShui() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = TRUE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 19 );
}

void CHsbiaoDlg::OnMenuHZhqi() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = TRUE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 20 );
}

void CHsbiaoDlg::OnMenuHShui() 
{
	// TODO: Add your command handler code here
	UpdateData( TRUE );
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = TRUE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 21 );
}

void CHsbiaoDlg::OnMenuPt() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = TRUE;
	m_CHECK_WD    = TRUE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 5 );
}

void CHsbiaoDlg::OnMenuPh() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = TRUE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = TRUE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 6 );
}

void CHsbiaoDlg::OnMenuPs() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = TRUE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = TRUE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 7 );
}

void CHsbiaoDlg::OnMenuPv() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = TRUE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = TRUE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 8 );
}

void CHsbiaoDlg::OnMenuPx() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = TRUE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = TRUE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 9 );
}

void CHsbiaoDlg::OnMenuTh() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = TRUE;
	m_CHECK_HAN   = TRUE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 11 );
}

void CHsbiaoDlg::OnMenuTs() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = TRUE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = TRUE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 12 );
}

void CHsbiaoDlg::OnMenuTv() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = TRUE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = TRUE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 13 );
}

void CHsbiaoDlg::OnMenuTx() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = TRUE;
	m_CHECK_HAN   = FALSE;
	m_CHECK_SH    = FALSE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = TRUE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 14 );
}

void CHsbiaoDlg::OnMenuHs() 
{
	// TODO: Add your command handler code here
	m_CHECK_YL    = FALSE;
	m_CHECK_WD    = FALSE;
	m_CHECK_HAN   = TRUE;
	m_CHECK_SH    = TRUE;
	m_CHECK_BRONG = FALSE;
	m_CHECK_GD    = FALSE;
	UpdateData( FALSE );

	hp_f_ClearEditBox( );

	hp_f_MenuChecked( 16 );
}

void CHsbiaoDlg::hp_f_MenuChecked( int ii ) 
{	CMenu *pMenu;
	CMenu * pMenu1;
	int i;

	pMenu = GetMenu( );
	pMenu1 = pMenu->GetSubMenu( 3 ); 

	for ( i = 0; i < 22; i ++ ) 
	{	if ( i == 4 || i == 10 || i == 15 || i == 17 )
			continue; 
		else if ( i == ii )
			pMenu1->CheckMenuItem( i, MF_BYPOSITION | MF_CHECKED );
		else
			pMenu1->CheckMenuItem( i, MF_BYPOSITION | MF_UNCHECKED );
	}
	hp_f_SetEditFocus( 1 );

	if (ii >= 0 && ii <= 3 || ii >= 18 ) 
	{	m_CHECK_BAOHE = 1;
		GetDlgItem( IDC_RADIO_ZHQI ) -> EnableWindow( TRUE );
		GetDlgItem( IDC_RADIO_SHUI ) -> EnableWindow( TRUE );
	}
	else
	{	m_CHECK_BAOHE = 0;
		GetDlgItem( IDC_RADIO_ZHQI ) -> EnableWindow( FALSE );
		GetDlgItem( IDC_RADIO_SHUI ) -> EnableWindow( FALSE );
	}

	if ( ii == 0 || ii == 2 || ii == 18 || ii == 20 ) 
	{	m_RADIO_ZHQI = 0;
	}
	else if ( ii == 1 || ii == 3 || ii == 19 || ii == 21 )
	{	m_RADIO_ZHQI = 1;
	}

	UpdateData( FALSE );

	pMenu1 = pMenu->GetSubMenu( 1 ); 
	if ( m_CHECK_BAOHE == TRUE ) 
	{	pMenu1->CheckMenuItem( ID_MENU_BAOHE, MF_BYCOMMAND | MF_CHECKED );
		pMenu1->EnableMenuItem( ID_MENU_ZHQI, MF_BYCOMMAND | MF_ENABLED );
		pMenu1->EnableMenuItem( ID_MENU_SHUI, MF_BYCOMMAND | MF_ENABLED );
		if ( m_RADIO_ZHQI == 0 )
		{	pMenu1->CheckMenuItem( ID_MENU_ZHQI, MF_BYCOMMAND | MF_CHECKED );
			pMenu1->CheckMenuItem( ID_MENU_SHUI, MF_BYCOMMAND | MF_UNCHECKED );
		}
		else
		{	pMenu1->CheckMenuItem( ID_MENU_ZHQI, MF_BYCOMMAND | MF_UNCHECKED );
			pMenu1->CheckMenuItem( ID_MENU_SHUI, MF_BYCOMMAND | MF_CHECKED );
		}
	}
	else
	{	pMenu1->CheckMenuItem( ID_MENU_BAOHE, MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->EnableMenuItem( ID_MENU_ZHQI, MF_BYCOMMAND | MF_GRAYED );
		pMenu1->EnableMenuItem( ID_MENU_SHUI, MF_BYCOMMAND | MF_GRAYED );
	}

	pMenu1 = pMenu->GetSubMenu( 2 ); 
	if ( m_RADIO_GUOJI == 0 ) 
	{	pMenu1->CheckMenuItem( ID_MENU_GUOJI, MF_BYCOMMAND | MF_CHECKED );
		pMenu1->CheckMenuItem( ID_MENU_GONGCHENG, MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->CheckMenuItem( ID_MENU_YINGZHI, MF_BYCOMMAND | MF_UNCHECKED );
	}
	else if ( m_RADIO_GUOJI == 1 ) 
	{	pMenu1->CheckMenuItem( ID_MENU_GUOJI, MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->CheckMenuItem( ID_MENU_GONGCHENG, MF_BYCOMMAND | MF_CHECKED );
		pMenu1->CheckMenuItem( ID_MENU_YINGZHI, MF_BYCOMMAND | MF_UNCHECKED );
	}
	else if ( m_RADIO_GUOJI == 2 ) 
	{	pMenu1->CheckMenuItem( ID_MENU_GUOJI, MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->CheckMenuItem( ID_MENU_GONGCHENG, MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->CheckMenuItem( ID_MENU_YINGZHI, MF_BYCOMMAND | MF_CHECKED );
	}
}

void CHsbiaoDlg::hp_f_setParameterMenuChecked( void ) 
{	CMenu *pMenu;
	CMenu * pMenu1;
	int i, ii;

	ii = -1;

	if ( m_CHECK_BAOHE == TRUE ) 
	{	if ( m_CHECK_YL == TRUE )
		{	if ( m_RADIO_ZHQI == 0 ) ii = 0;
			if ( m_RADIO_ZHQI == 1 ) ii = 1;
		}
		else if ( m_CHECK_WD == TRUE )
		{	if ( m_RADIO_ZHQI == 0 ) ii = 2;
			if ( m_RADIO_ZHQI == 1 ) ii = 3;
		}
		else if ( m_CHECK_BRONG == TRUE )
		{	if ( m_RADIO_ZHQI == 0 ) ii = 18;
			if ( m_RADIO_ZHQI == 1 ) ii = 19;
		}
		else if ( m_CHECK_HAN == TRUE )
		{	if ( m_RADIO_ZHQI == 0 ) ii = 20;
			if ( m_RADIO_ZHQI == 1 ) ii = 21;
		}
		goto end;
	}

	if ( m_CHECK_YL == TRUE && m_CHECK_WD == TRUE )    ii = 5;
	if ( m_CHECK_YL == TRUE && m_CHECK_HAN == TRUE )   ii = 6;
	if ( m_CHECK_YL == TRUE && m_CHECK_SH == TRUE )    ii = 7;
	if ( m_CHECK_YL == TRUE && m_CHECK_BRONG == TRUE ) ii = 8;
	if ( m_CHECK_YL == TRUE && m_CHECK_GD == TRUE )    ii = 9;
	if ( m_CHECK_WD == TRUE && m_CHECK_HAN == TRUE )   ii = 11;
	if ( m_CHECK_WD == TRUE && m_CHECK_SH == TRUE )    ii = 12;
	if ( m_CHECK_WD == TRUE && m_CHECK_BRONG == TRUE ) ii = 13;
	if ( m_CHECK_WD == TRUE && m_CHECK_GD == TRUE )    ii = 14;
	if ( m_CHECK_HAN == TRUE && m_CHECK_SH == TRUE )   ii = 16;

end:
	pMenu = GetMenu( );
	pMenu1 = pMenu->GetSubMenu( 3 );

	for ( i = 0; i < 22; i ++ )
	{	if ( i == 4 || i == 10 || i == 15 || i == 17 )
			continue; 
		else if ( i == ii )
			pMenu1->CheckMenuItem( i, MF_BYPOSITION | MF_CHECKED );
		else
			pMenu1->CheckMenuItem( i, MF_BYPOSITION | MF_UNCHECKED );
	}

	pMenu1 = pMenu->GetSubMenu( 1 );
	if ( m_CHECK_BAOHE == TRUE )
	{	pMenu1->CheckMenuItem( ID_MENU_BAOHE, MF_BYCOMMAND | MF_CHECKED );
		pMenu1->EnableMenuItem( ID_MENU_ZHQI, MF_BYCOMMAND | MF_ENABLED );
		pMenu1->EnableMenuItem( ID_MENU_SHUI, MF_BYCOMMAND | MF_ENABLED );
		if ( m_RADIO_ZHQI == 0 )
		{	pMenu1->CheckMenuItem( ID_MENU_ZHQI, MF_BYCOMMAND | MF_CHECKED );
			pMenu1->CheckMenuItem( ID_MENU_SHUI, MF_BYCOMMAND | MF_UNCHECKED );
		}
		else
		{	pMenu1->CheckMenuItem( ID_MENU_ZHQI, MF_BYCOMMAND | MF_UNCHECKED );
			pMenu1->CheckMenuItem( ID_MENU_SHUI, MF_BYCOMMAND | MF_CHECKED );
		}
	}
	else
	{	pMenu1->CheckMenuItem( ID_MENU_BAOHE, MF_BYCOMMAND | MF_UNCHECKED );
		pMenu1->EnableMenuItem( ID_MENU_ZHQI, MF_BYCOMMAND | MF_GRAYED );
		pMenu1->EnableMenuItem( ID_MENU_SHUI, MF_BYCOMMAND | MF_GRAYED );
	}
}

void CHsbiaoDlg::OnMenuShuoming() 
{
	// TODO: Add your command handler code here

	if ( g_iEnglish == 0 && 
		 g_wLangPID == LANG_CHINESE ) 
	{
	MessageBox( "\n\
1. 用户可以使用下拉菜单选择已知参数及单位制，亦可使用对话框中的复选按钮与\n\
   单选按钮选择已知参数及单位制。\n\
2. 计算饱和状态参数时，连续按回车键可在 '饱和蒸汽' 与 '饱和水' 之间切换。\n\
3. 当文本编辑框显示不出全部数据位数时，按住CTRL键同时用鼠标点击该 '文本编\n\
   辑框' 就会弹出消息框显示完整数据。\n\
4. 计算结果可能出现偶然的或必然的错误，敬请使用者自行校核。\n\
5. 版权所有，未经同意请勿复制。否则，对由此而造成的任何直接或间接的损害均\n\
   不负赔偿责任。\n\
6. 1.06 版及更晚的版本可以根据焓或比容求得饱和状态下的物理参数\
", "水蒸汽焓熵表 - 说明" );
	}
	else 
	{
	MessageBox( "\n\
1. You can select parameters and switch unit system using popup menu or\n\
   buttons in dialog.\n\
2. Hardware requirement: CPU 486 or above, memory 16MB at least, monitor\n\
   640X480 or above.\n\
3. Operating system:     Windows 95/98/NT4.0\n\
", "Inquire about water and steam parameters - Illustrate" );
	}
}

void CHsbiaoDlg::OnMenuGuanyu()
{
	// TODO: Add your command handler code here

	CString ss;

	if ( g_iEnglish == 0 && 
		 g_wLangPID == LANG_CHINESE ) 
	{
		if ( g_iSpecSingleFlag == 0 ) 
		{
			ss.Format( "\n\
\n         欢 迎 使 用 水 蒸 汽 焓 熵 表          \
\n                 (网络版 %g)                  \n\n\
\n             上海动力设备有限公司               \
\n                  设计研究所                    \
\n                    2002.7                      \n\
\n           版权所有，未经同意请勿复制", g_dMyApplicationVersionNumber );
		}
		else
		{	
			ss.Format( "\n\
\n         欢 迎 使 用 水 蒸 汽 焓 熵 表          \
\n                 (单机版 %g)                  \n\n\
\n             上海动力设备有限公司               \
\n                  设计研究所                    \
\n                    2002.7                      \n\
\n           版权所有，未经同意请勿复制", g_dMyApplicationVersionNumber );
		}

		MessageBox( ss, "水蒸汽焓熵表" );
	}
	else 
	{
		if ( g_iSpecSingleFlag == 0 ) 
		{
			ss.Format( "\n\
\n            WELCOME TO USE THIS UTILITY            \
\n              (Network Version %g)\n\n\
\n                        SPEC\
\n                       2002.7\n\
", g_dMyApplicationVersionNumber );
		}
		else
		{	
			ss.Format( "\n\
\n            WELCOME TO USE THIS UTILITY            \
\n                        (Single Version %g)\n\n\
\n                                    SPEC\
\n                                   2002.7\n\
", g_dMyApplicationVersionNumber );
		}

		MessageBox( ss, "Inquire about water and steam parameters" );
	}

}

void CHsbiaoDlg::OnKeyDown(UINT nChar, UINT nRepCnt, UINT nFlags) 
{
	// TODO: Add your message handler code here and/or call default

	CString ss;

	if ( ( ::GetKeyState( VK_CONTROL ) & 0x8000 ) == 0x8000 && 
		 ( ::GetKeyState( VK_MENU ) & 0x8000 ) == 0x8000 ) 
	{

		switch ( nChar ) 
		{
			case VK_F12:

				break;

			default:
				;
		}
	}

	CDialog::OnKeyDown(nChar, nRepCnt, nFlags);

}
