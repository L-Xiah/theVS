
// MyTextEditorView.h : CMyTextEditorView ��Ľӿ�
//

#pragma once


class CMyTextEditorView : public CEditView
{
protected: // �������л�����
	CMyTextEditorView();
	DECLARE_DYNCREATE(CMyTextEditorView)

// ����
public:
	CMyTextEditorDoc* GetDocument() const;

// ����
public:

// ��д
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// ʵ��
public:
	virtual ~CMyTextEditorView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// ���ɵ���Ϣӳ�亯��
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // MyTextEditorView.cpp �еĵ��԰汾
inline CMyTextEditorDoc* CMyTextEditorView::GetDocument() const
   { return reinterpret_cast<CMyTextEditorDoc*>(m_pDocument); }
#endif

