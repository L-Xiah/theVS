#ifndef NEWPANEL_H
#define NEWPANEL_H

//(*Headers(NewPanel)
#include <wx/panel.h>
#include <wx/statbmp.h>
//*)

class NewPanel: public wxPanel
{
	public:

		NewPanel(wxWindow* parent,wxWindowID id=wxID_ANY);
		virtual ~NewPanel();

		//(*Declarations(NewPanel)
		wxStaticBitmap* StaticBitmap1;
		//*)

	protected:

		//(*Identifiers(NewPanel)
		static const long ID_STATICBITMAP1;
		//*)

	private:

		//(*Handlers(NewPanel)
		void OnPaint(wxPaintEvent& event);
		//*)

		DECLARE_EVENT_TABLE()
};

#endif
