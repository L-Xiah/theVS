
//////////////////////////////////////////////////////////////////////

#if !defined(AFX_IFCHSB_H__20631120_4912_11D5_A2DA_D845906E9849__INCLUDED_)
#define AFX_IFCHSB_H__20631120_4912_11D5_A2DA_D845906E9849__INCLUDED_

#if _MSC_VER >= 1000
#pragma once
#endif 

class CIfcHSB  
{
public:
	CIfcHSB();
	
	double hp_d_ptv[9];

	int hp_ifcshuip ( double p );
	int hp_ifcshuit ( double t );
	int hp_ifcshuiv ( double v );
	int hp_ifcshuih ( double h );
	int hp_ifczhqip ( double p );
	int hp_ifczhqit ( double t );
	int hp_ifczhqiv ( double v );
	int hp_ifczhqih ( double h, int ii ); 
	int hp_ifcpt (double p, double t);
	int hp_ifcpx (double p, double x);

	int hp_ifcph (double p, double h);
	int hp_ifcps (double p, double s);
	int hp_ifcpv (double p, double v);
	int hp_ifcth (double t, double h);
	int hp_ifcts (double t, double s);
	int hp_ifctv (double t, double v);
	int hp_ifctx (double t, double x);
	int hp_ifchs (double h, double s);
	int hp_find_p4( double tt, double *pp );


	~CIfcHSB()
	{
		//delete [] hp_d_ptv;
	}
};

#endif 
