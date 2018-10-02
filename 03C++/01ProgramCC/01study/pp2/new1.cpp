#include "new1.h"

//(*InternalHeaders(new1)
#include <wx/intl.h>
#include <wx/string.h>
//*)

//(*IdInit(new1)
const long new1::ID_TEXTCTRL1 = wxNewId();
//*)

BEGIN_EVENT_TABLE(new1,wxPanel)
	//(*EventTable(new1)
	//*)
END_EVENT_TABLE()

new1::new1(wxWindow* parent,wxWindowID id,const wxPoint& pos,const wxSize& size)
{
	//(*Initialize(new1)
	Create(parent, id, wxDefaultPosition, wxSize(228,176), wxTAB_TRAVERSAL, _T("id"));
	TextCtrl1 = new wxTextCtrl(this, ID_TEXTCTRL1, _("文本"), wxPoint(72,8), wxSize(400,232), 0, wxDefaultValidator, _T("ID_TEXTCTRL1"));
	
	Connect(ID_TEXTCTRL1,wxEVT_COMMAND_TEXT_UPDATED,(wxObjectEventFunction)&new1::OnTextCtrl1Text);
	//*)
}

new1::~new1()
{
	//(*Destroy(new1)
	//*)
}


void new1::OnTextCtrl1Text(wxCommandEvent& event)
{
}
