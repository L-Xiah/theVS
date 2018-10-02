#include "NewPanel.h"

//(*InternalHeaders(NewPanel)
#include <wx/intl.h>
#include <wx/string.h>
//*)

//(*IdInit(NewPanel)
const long NewPanel::ID_STATICBITMAP1 = wxNewId();
//*)

BEGIN_EVENT_TABLE(NewPanel,wxPanel)
	//(*EventTable(NewPanel)
	//*)
END_EVENT_TABLE()

NewPanel::NewPanel(wxWindow* parent,wxWindowID id)
{
	//(*Initialize(NewPanel)
	Create(parent, id, wxDefaultPosition, wxSize(445,267), wxTAB_TRAVERSAL, _T("id"));
	SetForegroundColour(wxColour(255,128,128));
	SetBackgroundColour(wxColour(255,255,128));
	StaticBitmap1 = new wxStaticBitmap(this, ID_STATICBITMAP1, wxNullBitmap, wxPoint(360,152), wxSize(392,264), 0, _T("ID_STATICBITMAP1"));
	
	Connect(wxEVT_PAINT,(wxObjectEventFunction)&NewPanel::OnPaint);
	//*)
}

NewPanel::~NewPanel()
{
	//(*Destroy(NewPanel)
	//*)
}

