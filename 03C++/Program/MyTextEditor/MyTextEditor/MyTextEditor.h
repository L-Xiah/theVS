
// MyTextEditor.h : MyTextEditor Ӧ�ó������ͷ�ļ�
//
#pragma once

#ifndef __AFXWIN_H__
	#error "�ڰ������ļ�֮ǰ������stdafx.h�������� PCH �ļ�"
#endif

#include "resource.h"       // ������


// CMyTextEditorApp:
// �йش����ʵ�֣������ MyTextEditor.cpp
//

class CMyTextEditorApp : public CWinApp
{
public:
	CMyTextEditorApp();


// ��д
public:
	virtual BOOL InitInstance();
	virtual int ExitInstance();

// ʵ��
	afx_msg void OnAppAbout();
	DECLARE_MESSAGE_MAP()
};

extern CMyTextEditorApp theApp;
