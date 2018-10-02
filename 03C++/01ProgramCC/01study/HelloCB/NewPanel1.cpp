#include "NewPanel1.h"

//(*InternalHeaders(NewPanel1)
#include <wx/intl.h>
#include <wx/string.h>
//*)

//(*IdInit(NewPanel1)
//*)

BEGIN_EVENT_TABLE(NewPanel1,wxPanel)
	//(*EventTable(NewPanel1)
	//*)
END_EVENT_TABLE()

NewPanel1::NewPanel1(wxWindow* parent,wxWindowID id,const wxPoint& pos,const wxSize& size)
{
	//(*Initialize(NewPanel1)
	Create(parent, id, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL, _T("id"));
	//*)
}

NewPanel1::~NewPanel1()
{
	//(*Destroy(NewPanel1)
	//*)
}

