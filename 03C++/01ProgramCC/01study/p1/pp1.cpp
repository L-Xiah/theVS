//����1.1 static�洢���ͱ���

#include <iostream>
#include <stdio.h>

using namespace std;
void f1()

{
   static int count = 0;                 //use static variable

   static int j = count;               //j��ֵ����α仯��

   printf("I was called %d times.\n\n",++count);
   printf("I WAS CALLED %d times.\n\n",++j);
}
void f2()

{
  f1();
}

int main()

{

   f1(); f2(); f1();
  return 0;
}
