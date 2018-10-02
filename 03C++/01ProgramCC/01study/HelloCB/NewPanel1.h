#ifndef NEWPANEL1_H
#define NEWPANEL1_H

//(*Headers(NewPanel1)
#include <wx/stattext.h>
#include <wx/textctrl.h>
#include <wx/panel.h>
//*)

class NewPanel1: public wxPanel
{
	public:

		NewPanel1(wxWindow* parent,wxWindowID id=wxID_ANY,const wxPoint& pos=wxDefaultPosition,const wxSize& size=wxDefaultSize);
		virtual ~NewPanel1();

		//(*Declarations(NewPanel1)
		wxStaticText* StaticText1;
		wxTextCtrl* TextCtrl1;
		//*)

	protected:

		//(*Identifiers(NewPanel1)
		static const long ID_STATICTEXT1;
		static const long ID_TEXTCTRL1;
		//*)

	private:

		//(*Handlers(NewPanel1)
		//*)

		DECLARE_EVENT_TABLE()
};

#endif
