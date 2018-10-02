#ifndef NEW1_H
#define NEW1_H

//(*Headers(new1)
#include <wx/textctrl.h>
#include <wx/panel.h>
//*)

class new1: public wxPanel
{
	public:

		new1(wxWindow* parent,wxWindowID id=wxID_ANY,const wxPoint& pos=wxDefaultPosition,const wxSize& size=wxDefaultSize);
		virtual ~new1();

		//(*Declarations(new1)
		wxTextCtrl* TextCtrl1;
		//*)

	protected:

		//(*Identifiers(new1)
		static const long ID_TEXTCTRL1;
		//*)

	private:

		//(*Handlers(new1)
		void OnTextCtrl1Text(wxCommandEvent& event);
		//*)

		DECLARE_EVENT_TABLE()
};

#endif
