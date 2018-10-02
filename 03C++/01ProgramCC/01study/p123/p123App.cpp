/***************************************************************
 * Name:      p123App.cpp
 * Purpose:   Code for Application Class
 * Author:     ()
 * Created:   2012-06-10
 * Copyright:  ()
 * License:
 **************************************************************/

#include "p123App.h"

//(*AppHeaders
#include "p123Main.h"
#include <wx/image.h>
//*)

IMPLEMENT_APP(p123App);

bool p123App::OnInit()
{
    //(*AppInitialize
    bool wxsOK = true;
    wxInitAllImageHandlers();
    if ( wxsOK )
    {
    	p123Dialog Dlg(0);
    	SetTopWindow(&Dlg);
    	Dlg.ShowModal();
    	wxsOK = false;
    }
    //*)
    return wxsOK;

}
