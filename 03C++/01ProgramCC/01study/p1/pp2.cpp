//����1.2 �˽�һ��by reference���͵ı���
//
//    By reference ���͵ı����ڱ���ʼ����ʱ����Ҫ����һ��ͬ���͵ı����� (�磺count)����ɳ�ʼ���󣬸ñ����Ϳ�����Ϊ��count�����ı��������жԸñ����Ĳ������ᷴӳ��count�����С�
#include <stdio.h>
void f11()

{
   static int count = 0;                 //use static variable

   int& j = count;                       //j��Ϊby reference���ͣ�����ֵ����α仯��

   printf("I was called %d times. j = %d \n",++count, j);

   j = 4;
}
void f12()

{
  f11();
}

int main()

{
   int x=3;

   f11(); f12(); f11();
}
