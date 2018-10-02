/***************************************************************
 * Name:      pp5App.cpp
 * Purpose:   Code for Application Class
 * Author:     ()
 * Created:   2012-06-10
 * Copyright:  ()
 * License:
 **************************************************************/

#include "pp5App.h"

//(*AppHeaders
#include "pp5Main.h"
#include <wx/image.h>
//*)

IMPLEMENT_APP(pp5App);

bool pp5App::OnInit()
{
    //(*AppInitialize
    bool wxsOK = true;
    wxInitAllImageHandlers();
    if ( wxsOK )
    {
    	pp5Dialog Dlg(0);
    	SetTopWindow(&Dlg);
    	Dlg.ShowModal();
    	wxsOK = false;
    }
    //*)
    return wxsOK;

}
