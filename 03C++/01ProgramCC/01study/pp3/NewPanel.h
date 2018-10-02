#ifndef NEWPANEL_H
#define NEWPANEL_H

//(*Headers(NewPanel)
#include <wx_panel.h>
//*)

class NewPanel: public wxPanel
{
	public:

		NewPanel(wxWindow* parent,wxWindowID id=wxID_ANY,const wxPoint& pos=wxDefaultPosition,const wxSize& size=wxDefaultSize);
		virtual ~NewPanel();

		//(*Declarations(NewPanel)
		wxPanel* Panel1;
		wxPanel* Panel2;
		//*)

	protected:

		//(*Identifiers(NewPanel)
		static const long ID_PANEL1;
		static const long ID_PANEL2;
		//*)

	private:

		//(*Handlers(NewPanel)
		//*)

		DECLARE_EVENT_TABLE()
};

#endif
