#ifndef NEWPANEL123_H
#define NEWPANEL123_H

//(*Headers(NewPanel123)
#include <wx/panel.h>
//*)

class NewPanel123: public wxPanel
{
	public:

		NewPanel123(wxWindow* parent,wxWindowID id=wxID_ANY,const wxPoint& pos=wxDefaultPosition,const wxSize& size=wxDefaultSize);
		virtual ~NewPanel123();

		//(*Declarations(NewPanel123)
		//*)

	protected:

		//(*Identifiers(NewPanel123)
		//*)

	private:

		//(*Handlers(NewPanel123)
		//*)

		DECLARE_EVENT_TABLE()
};

#endif
