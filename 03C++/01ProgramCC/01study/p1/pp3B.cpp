//1.3B 通过指针变量传递参数

#include <stdio.h>
void swap(int* pa, int *pb)
{
  int* temp;

   temp = pa;
   pa = pb;
   pb = temp;

   printf("*pa= %d; *pb = %d\n",*pa, *pb);
}

int main()
{
   int i, j;
   int*p1,*p2;           //注意，如果写成 int* p1,p2; 则p2为一个整型变量

   p1= &i; p2 = &j;

   printf("Pls input two int:");
   scanf("%d%d",p1,p2);

   swap(p1,p2);
   printf("*p1= %d; *p2 = %d\n",*p1, *p2);
}
