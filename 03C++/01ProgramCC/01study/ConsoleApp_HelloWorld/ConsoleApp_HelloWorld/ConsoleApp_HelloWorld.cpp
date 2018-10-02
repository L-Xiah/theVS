// ConsoleApp_HelloWorld.cpp : 定义控制台应用程序的入口点。
//

#include "stdafx.h"

int _tmain(int argc, _TCHAR* argv[])
{


	char strch[]={"shrimp"};
	std::string str=strch;
	std::cout << str << std::endl;
	
	str="fish";
	strcpy_s(strch,str.c_str());
	std::cout<< strch<<std::endl;

	str="duck";
	str._Copy_s(strch,4,3);
	std::cout<<strch<<std::endl;

	/*str="chicken";
	strcpy_s(strch,str.data());
	std::cout<<strch<<std::endl;*/



	TCHAR * ptest01= L"ww1234" ;
	TCHAR * ptest=argv[1];
	std::cout << argc << "\n";
	std::cout << &ptest <<"\n";
	std::wcout << ptest <<"\n";
	std::wcout << ptest01 <<"\n";

	

	return 0;
}

