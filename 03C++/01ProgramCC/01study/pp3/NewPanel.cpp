#include "NewPanel.h"

//(*InternalHeaders(NewPanel)
#include <wx/settings.h>
#include <wx/intl.h>
#include <wx/string.h>
//*)

//(*IdInit(NewPanel)
const long NewPanel::ID_PANEL3 = wxNewId();
const long NewPanel::ID_PANEL1 = wxNewId();
const long NewPanel::ID_PANEL2 = wxNewId();
//*)

BEGIN_EVENT_TABLE(NewPanel,wxPanel)
	//(*EventTable(NewPanel)
	//*)
END_EVENT_TABLE()

NewPanel::NewPanel(wxWindow* parent,wxWindowID id,const wxPoint& pos,const wxSize& size)
{
	//(*Initialize(NewPanel)
	Create(parent, id, wxDefaultPosition, wxSize(595,463), wxTAB_TRAVERSAL, _T("id"));
	SetBackgroundColour(wxSystemSettings::GetColour(wxSYS_COLOUR_BACKGROUND));
	Panel1 = new wxPanel(this, ID_PANEL1, wxPoint(48,8), wxSize(280,128), wxTAB_TRAVERSAL, _T("ID_PANEL1"));
	Panel1->SetBackgroundColour(wxColour(255,128,128));
	Panel3 = new wxPanel(Panel1, ID_PANEL3, wxPoint(56,24), wxSize(136,56), wxTAB_TRAVERSAL, _T("ID_PANEL3"));
	Panel2 = new wxPanel(this, ID_PANEL2, wxPoint(64,160), wxSize(208,64), wxTAB_TRAVERSAL, _T("ID_PANEL2"));
	Panel2->SetBackgroundColour(wxColour(128,255,128));
	//*)
}

NewPanel::~NewPanel()
{
	//(*Destroy(NewPanel)
	//*)
}

