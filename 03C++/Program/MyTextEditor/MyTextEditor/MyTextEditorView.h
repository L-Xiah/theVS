
// MyTextEditorView.h : CMyTextEditorView 类的接口
//

#pragma once


class CMyTextEditorView : public CEditView
{
protected: // 仅从序列化创建
	CMyTextEditorView();
	DECLARE_DYNCREATE(CMyTextEditorView)

// 特性
public:
	CMyTextEditorDoc* GetDocument() const;

// 操作
public:

// 重写
public:
	virtual BOOL PreCreateWindow(CREATESTRUCT& cs);
protected:
	virtual BOOL OnPreparePrinting(CPrintInfo* pInfo);
	virtual void OnBeginPrinting(CDC* pDC, CPrintInfo* pInfo);
	virtual void OnEndPrinting(CDC* pDC, CPrintInfo* pInfo);

// 实现
public:
	virtual ~CMyTextEditorView();
#ifdef _DEBUG
	virtual void AssertValid() const;
	virtual void Dump(CDumpContext& dc) const;
#endif

protected:

// 生成的消息映射函数
protected:
	DECLARE_MESSAGE_MAP()
};

#ifndef _DEBUG  // MyTextEditorView.cpp 中的调试版本
inline CMyTextEditorDoc* CMyTextEditorView::GetDocument() const
   { return reinterpret_cast<CMyTextEditorDoc*>(m_pDocument); }
#endif

