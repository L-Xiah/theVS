#include <stdio.h>
#include <stdlib.h>
#include <iostream>
#include <iomanip>

namespace MyNewSpace
{
	const int Num=124;
}

using std::cout;
using std::cin ;
using std::endl;
using std::setw;


void Booltest(bool);
void calc_壁纸();
int Ex3_01Cpp();
int Ex3_10Cpp();
void Ex3_Continue();
void Ex3_14Cpp();
int WorkEx3_01();
int WorkEx3_02();
void Ex4_01For();

int main()
{	
	
	int n=6 ;
	switch((n>=0)? n :8)
	{
	case 6:
		Ex4_01For();
		break;
	case 0:
		{	Booltest(false );
			calc_壁纸();
			break;}
	case 1:
		std::cout<<	Ex3_01Cpp();
		break;
	case 2:
		std::cout<<std::endl << Ex3_10Cpp();
		break;
	case 3:
		 Ex3_Continue();
		 break;
	case 4:
		Ex3_14Cpp();
		break;
	case 5:
		std::cout <<"这个总和是：" << WorkEx3_02();
		break ;
	default :
		std::cout << std::endl <<"The default Case."<<std::endl;
		std::cout <<"NameSpace调用：" << MyNewSpace::Num ;
		break;
	}

	



			
	cout<<"\a\n";//反斜杠\转义符
	system("pause");//getchar();
	return 0;	
 }



void Ex4_01For()
{
	double tempValues[]={12,123,45.5,212,23,34,34.3};
	double sum=0;
	int count=0;
	int myTest=0;
	myTest =_countof(tempValues );  //数组大小
	std::cout<<"tempValues数组大小为："<<myTest
		<<std::endl ;
	for (double item:tempValues)  //遍历数组中的元素
	{
		sum +=item;
		++count ;
	}
	std::cout <<"数组中平均值："<<sum/count<<std::endl;
	const int Max=80;
	char buffer[Max];
	count=0;
	std::cout<<"Enter a string of less than "<<Max<<" characters:\n";
	cin.getline(buffer,Max,'\0');

	while(buffer[count] !='\0')
		count++;
	std::cout<<std::endl<<"The string \""<<buffer
		<<"\" has " <<count<<" characters."
		<<std::endl;
	
}



/*******************************
asd
********************************/
int Ex3_01Cpp()
{
	char letter(0);
	std::cout <<std::endl
		<< "Enter a letter:";
	std::cin>> letter;

	if(letter>='A' && letter <='Z')
	{
		std::cout<<std::endl
			<<"You entered a capital letter."
			<<letter
			<< std::endl ;
	return 1;	
	}

	if(letter >='a' && letter <='z')
	{
		std::cout << std::endl
			<<"You entered a small letter."
			<< letter
			<<std::endl;
		return 2;
		}
	

	std::cout<<std::endl
		<<"You did not enter a letter."
		<< std::endl ;	
	return 0;
}
 
int Ex3_10Cpp()
{
	double value(0.0);
	double sum=0.0;
	int i=0;
	char indicator='n';

	for(int i=1;i>0;i++)
	{
		std::cout << std::endl << "Input value:";
		std::cout<<std::endl
			<< "Enter a value";
		std::cin >> value;
		if(0==value)
			std::cin >>indicator;
			continue;
		++i;
		std::cout << std::endl
			<< value <<std::endl;
		sum +=value;

		std::cout << endl
			<< "Do you want to enter another value (enter y or n)?";
		std::cin >> indicator;
		if('n'==indicator || 'N'==indicator)
			break;
	}
	std::cout << std::endl
		<< "The average of the "<< i
		<< " values you entered is " << sum/i << "."
		<< std::endl;
	return 0;

}

void Ex3_Continue()
{
	int value=0;
	int product=1;

	for (int i=1 ;i<=10 ;i++)
	{
		cout<<"Enter an integer:";
		cin>>value;
		if(0==value)
			continue;
		product *=value;

	}

	cout<< endl << "Product (ignoring zeros): " << product;
	cout <<endl;
}

void Ex3_14Cpp()
{
	const int size=12;
	int i=0,j=0;

	std::cout<<std::endl
		<< size << " by "<< " Multiplication Table " << endl <<endl;
	std::cout << std::endl << setw(5) << "" << " |";

	for(i=1;i<=size;i++)
		std::cout<< setw(5) << i << " ";
	std::cout << std::endl;
	for(i=0;i<=size;i++)
		cout << "______";

	for(i=1;i<=size;i++)
	{
		std::cout << std::endl
			<< setw(5) << i << " |";
		for(j=1;j<=size;j++)
		{std::cout << setw(5) << i*j << " ";
		}
	}
	std::cout << endl;
	

}

int WorkEx3_01()
{
	int tempsum(0), tempI(0);
	int i(0);
	/****************
	for循环
	****************/
	for (i=1;i<3;i++)
	{
	for (;;)
	{
		std::cout <<"For Input Value: ";
		std::cin >>tempI;
		if (0 == tempI) 
			break  ;
		else 
			tempsum +=tempI ;
	}}

	return tempsum;


	
	/**********
	do-while循环
	**********/
	do
	{	std::cout<<"input value:";
		std::cin >>tempI ;
		tempsum +=tempI ;
		}while (0!=tempI);
	return tempsum ;

	
	/**************
	While循环
	***************/
	std::cout << "Input:";
	std::cin>>tempI ;
	while (0!=tempI )
	{
		tempsum=tempsum + tempI ;
		std::cout << "Input:";
		std::cin >> tempI;
	}
	return tempsum ;
}

int WorkEx3_02()
{
	char tempChar;
	int tempSum(0);
	for(;;)
	{
		std::cin >>tempChar ;
		if( 'q'== tempChar ||'Q'==tempChar )
			break ;
		switch (tempChar )
		{
		case 'a':case 'e':case 'i':case 'o':case 'u':
		case 'A':case 'E':case 'I':case 'O':case 'U':
			tempSum +=1 ; break;
		default :{}
		}
	}
	return tempSum ;

}

void Booltest(bool testTemp)
 {
	 if (testTemp==true)
	 {
		 cout <<"hello world\n";
	 }
 }
 
void calc_壁纸()
 {
	double height=0.0,width=0.0,length=0.0;
	double perimeter=0.0;

	const double rollwidth=21.0;
	const double rolllength=12*33;

	int  strips_per_roll=0;
	int  strips_reqd=0;
	int nrolls=0;

	std::cout<<std::endl;
	std::cout<<"输入房间的高度in：";
	std::cin>>height;

	std::cout<<std::endl
		<<"输入房间的长度和宽度in：" ;
	std::cin>>length>>width;

	strips_per_roll =static_cast <int> (rolllength / height) ;
	perimeter =2*(length + width );
	strips_reqd=static_cast <int>( perimeter /rollwidth);
	nrolls =strips_reqd /strips_per_roll ;
	if (nrolls==0)
	{
		nrolls=1;
	}

	std::cout<<std::endl
		<<"你需要"<<nrolls<<"卷壁纸。"
		<<std::endl;
	

 }

