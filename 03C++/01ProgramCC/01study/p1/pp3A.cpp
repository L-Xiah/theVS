//例子1.3 理解指针类型的变量

//1.3A 指针声明与赋值

#include <stdio.h>
int main()
{
   int* p1,* p2;
   int i = 9;

   p1 = &i;           //p1获得i的地址。指向i
   p2 = p1;

   printf("%d \n\n",*p2);

}
