//1.3B ͨ��ָ��������ݲ���

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
   int*p1,*p2;           //ע�⣬���д�� int* p1,p2; ��p2Ϊһ�����ͱ���

   p1= &i; p2 = &j;

   printf("Pls input two int:");
   scanf("%d%d",p1,p2);

   swap(p1,p2);
   printf("*p1= %d; *p2 = %d\n",*p1, *p2);
}
