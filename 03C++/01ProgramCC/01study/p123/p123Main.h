/***************************************************************
 * Name:      p123Main.h
 * Purpose:   Defines Application Frame
 * Author:     ()
 * Created:   2012-06-10
 * Copyright:  ()
 * License:
 **************************************************************/

#ifndef P123MAIN_H
#define P123MAIN_H

//(*Headers(p123Dialog)
#include <wx/sizer.h>
#include <wx/stattext.h>
#include <wx/statline.h>
#include <wx/button.h>
#include <wx/dialog.h>
//*)

class p123Dialog: public wxDialog
{
    public:

        p123Dialog(wxWindow* parent,wxWindowID id = -1);
        virtual ~p123Dialog();

    private:

        //(*Handlers(p123Dialog)
        void OnQuit(wxCommandEvent& event);
        void OnAbout(wxCommandEvent& event);
        //*)

        //(*Identifiers(p123Dialog)
        static const long ID_STATICTEXT1;
        static const long ID_BUTTON1;
        static const long ID_STATICLINE1;
        static const long ID_BUTTON2;
        //*)

        //(*Declarations(p123Dialog)
        wxButton* Button1;
        wxStaticText* StaticText1;
        wxBoxSizer* BoxSizer2;
        wxButton* Button2;
        wxStaticLine* StaticLine1;
        wxBoxSizer* BoxSizer1;
        //*)

        DECLARE_EVENT_TABLE()
};

#endif // P123MAIN_H
