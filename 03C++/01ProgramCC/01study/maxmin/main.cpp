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
    std::cout << "三个数为：" << a << " " << d << " " << c <<'\n'<<'\n'<<'\n';
    std::cout << "最小数是:" << d <<'\n';
    std::cout << "最大数是:" << e <<'\n'<<'\n';


    system ("pause");     //在exe程序中暂停用的


}

