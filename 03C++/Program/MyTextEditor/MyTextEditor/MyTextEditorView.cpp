
// MyTextEditorView.cpp : CMyTextEditorView 类的实现
//

#include "stdafx.h"
// SHARED_HANDLERS 可以在实现预览、缩略图和搜索筛选器句柄的
// ATL 项目中进行定义，并允许与该项目共享文档代码。
#ifndef SHARED_HANDLERS
#include "MyTextEditor.h"
#endif

#include "MyTextEditorDoc.h"
#include "MyTextEditorView.h"

#ifdef _DEBUG
#define new DEBUG_NEW
#endif


// CMyTextEditorView

IMPLEMENT_DYNCREATE(CMyTextEditorView, CEditView)

BEGIN_MESSAGE_MAP(CMyTextEditorView, CEditView)
	// 标准打印命令
	ON_COMMAND(ID_FILE_PRINT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CEditView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CMyTextEditorView 构造/析构

CMyTextEditorView::CMyTextEditorView()
{
	// TODO: 在此处添加构造代码

}

CMyTextEditorView::~CMyTextEditorView()
{
}

BOOL CMyTextEditorView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: 在此处通过修改
	//  CREATESTRUCT cs 来修改窗口类或样式

	BOOL bPreCreated = CEditView::PreCreateWindow(cs);
	cs.style &= ~(ES_AUTOHSCROLL|WS_HSCROLL);	// 启用换行

	return bPreCreated;
}


// CMyTextEditorView 打印

BOOL CMyTextEditorView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// 默认 CEditView 准备
	return CEditView::OnPreparePrinting(pInfo);
}

void CMyTextEditorView::OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// 默认 CEditView 开始打印
	CEditView::OnBeginPrinting(pDC, pInfo);
}

void CMyTextEditorView::OnEndPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// 默认 CEditView 结束打印
	CEditView::OnEndPrinting(pDC, pInfo);
}


// CMyTextEditorView 诊断

#ifdef _DEBUG
void CMyTextEditorView::AssertValid() const
{
	CEditView::AssertValid();
}

void CMyTextEditorView::Dump(CDumpContext& dc) const
{
	CEditView::Dump(dc);
}

CMyTextEditorDoc* CMyTextEditorView::GetDocument() const // 非调试版本是内联的
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMyTextEditorDoc)));
	return (CMyTextEditorDoc*)m_pDocument;
}
#endif //_DEBUG


// CMyTextEditorView 消息处理程序
