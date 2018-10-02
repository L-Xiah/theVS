
// MyTextEditorView.cpp : CMyTextEditorView ���ʵ��
//

#include "stdafx.h"
// SHARED_HANDLERS ������ʵ��Ԥ��������ͼ������ɸѡ�������
// ATL ��Ŀ�н��ж��壬�����������Ŀ�����ĵ����롣
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
	// ��׼��ӡ����
	ON_COMMAND(ID_FILE_PRINT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_DIRECT, &CEditView::OnFilePrint)
	ON_COMMAND(ID_FILE_PRINT_PREVIEW, &CEditView::OnFilePrintPreview)
END_MESSAGE_MAP()

// CMyTextEditorView ����/����

CMyTextEditorView::CMyTextEditorView()
{
	// TODO: �ڴ˴���ӹ������

}

CMyTextEditorView::~CMyTextEditorView()
{
}

BOOL CMyTextEditorView::PreCreateWindow(CREATESTRUCT& cs)
{
	// TODO: �ڴ˴�ͨ���޸�
	//  CREATESTRUCT cs ���޸Ĵ��������ʽ

	BOOL bPreCreated = CEditView::PreCreateWindow(cs);
	cs.style &= ~(ES_AUTOHSCROLL|WS_HSCROLL);	// ���û���

	return bPreCreated;
}


// CMyTextEditorView ��ӡ

BOOL CMyTextEditorView::OnPreparePrinting(CPrintInfo* pInfo)
{
	// Ĭ�� CEditView ׼��
	return CEditView::OnPreparePrinting(pInfo);
}

void CMyTextEditorView::OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// Ĭ�� CEditView ��ʼ��ӡ
	CEditView::OnBeginPrinting(pDC, pInfo);
}

void CMyTextEditorView::OnEndPrinting(CDC* pDC, CPrintInfo* pInfo)
{
	// Ĭ�� CEditView ������ӡ
	CEditView::OnEndPrinting(pDC, pInfo);
}


// CMyTextEditorView ���

#ifdef _DEBUG
void CMyTextEditorView::AssertValid() const
{
	CEditView::AssertValid();
}

void CMyTextEditorView::Dump(CDumpContext& dc) const
{
	CEditView::Dump(dc);
}

CMyTextEditorDoc* CMyTextEditorView::GetDocument() const // �ǵ��԰汾��������
{
	ASSERT(m_pDocument->IsKindOf(RUNTIME_CLASS(CMyTextEditorDoc)));
	return (CMyTextEditorDoc*)m_pDocument;
}
#endif //_DEBUG


// CMyTextEditorView ��Ϣ�������
