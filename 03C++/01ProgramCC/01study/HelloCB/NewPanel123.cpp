#include "NewPanel123.h"

//(*InternalHeaders(NewPanel123)
#include <wx/intl.h>
#include <wx/string.h>
//*)

//(*IdInit(NewPanel123)
//*)

BEGIN_EVENT_TABLE(NewPanel123,wxPanel)
	//(*EventTable(NewPanel123)
	//*)
END_EVENT_TABLE()

NewPanel123::NewPanel123(wxWindow* parent,wxWindowID id,const wxPoint& pos,const wxSize& size)
{
	//(*Initialize(NewPanel123)
	Create(parent, id, wxDefaultPosition, wxDefaultSize, wxTAB_TRAVERSAL, _T("id"));
	//*)
}

NewPanel123::~NewPanel123()
{
	//(*Destroy(NewPanel123)
	//*)
}

