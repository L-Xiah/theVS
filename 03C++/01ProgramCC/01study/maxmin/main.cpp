#include <iostream>
#include <stdio.h>
#include <stdlib.h>
#include "max_min.hpp"


int main()

{


    int a=100,b=99,c=101;
    int d,e=5;
    d=min(a,min(b,c));
    e=max(a,max(b,c));
    std::cout << "������Ϊ��" << a << " " << d << " " << c <<'\n'<<'\n'<<'\n';
    std::cout << "��С����:" << d <<'\n';
    std::cout << "�������:" << e <<'\n'<<'\n';


    system ("pause");     //��exe��������ͣ�õ�


}

