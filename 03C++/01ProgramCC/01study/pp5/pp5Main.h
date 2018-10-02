/***************************************************************
 * Name:      pp5Main.h
 * Purpose:   Defines Application Frame
 * Author:     ()
 * Created:   2012-06-10
 * Copyright:  ()
 * License:
 **************************************************************/

#ifndef PP5MAIN_H
#define PP5MAIN_H

//(*Headers(pp5Dialog)
#include <wx/sizer.h>
#include <wx/stattext.h>
#include <wx/statline.h>
#include <wx/button.h>
#include <wx/dialog.h>
//*)

class pp5Dialog: public wxDialog
{
    public:

        pp5Dialog(wxWindow* parent,wxWindowID id = -1);
        virtual ~pp5Dialog();

    private:

        //(*Handlers(pp5Dialog)
        void OnQuit(wxCommandEvent& event);
        void OnAbout(wxCommandEvent& event);
        //*)

        //(*Identifiers(pp5Dialog)
        static const long ID_STATICTEXT1;
        static const long ID_BUTTON1;
        static const long ID_STATICLINE1;
        static const long ID_BUTTON2;
        //*)

        //(*Declarations(pp5Dialog)
        wxButton* Button1;
        wxStaticText* StaticText1;
        wxBoxSizer* BoxSizer2;
        wxButton* Button2;
        wxStaticLine* StaticLine1;
        wxBoxSizer* BoxSizer1;
        //*)

        DECLARE_EVENT_TABLE()
};

#endif // PP5MAIN_H
