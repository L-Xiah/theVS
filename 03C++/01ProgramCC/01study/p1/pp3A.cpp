//����1.3 ���ָ�����͵ı���

//1.3A ָ�������븳ֵ

#include <stdio.h>
int main()
{
   int* p1,* p2;
   int i = 9;

   p1 = &i;           //p1���i�ĵ�ַ��ָ��i
   p2 = p1;

   printf("%d \n\n",*p2);

}
