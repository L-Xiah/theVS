//�ڶ����� �۲�����������ʱ�����Ŀռ���估������
//2.1 �Ķ��������������й۲�auto���ͱ����ĵ�ַ���仯��������auto���ͱ����������ڡ�

#include <stdio.h>

void f1()
{
   int i = 1;
   printf("the address of 'f1 i' is %u, i = %d\n",&i ,i++);
}

void f2()

{
   int j = 2;
   printf("the address of 'f2 j' is %u, j = %d\n",&j ,j++);
   f1();
}

int main()

{
   int x = 3;

   f1(); f2(); f1();
   printf("the address of 'main x' is %u, x = %d\n",&x ,x);
   }
