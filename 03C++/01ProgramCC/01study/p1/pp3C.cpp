//����1.3C ��������ָ��̬�����ĵ�ַ

#include <stdio.h>
int* fact ()                               //�ú�������Ϊһ���������͵�ָ�루��ַ��
{
    static int i=0,j;                      //���ȥ��static�޶�Ԥ�Ⲣ�۲�������н��
    if (i <= 0)
        printf("please input a positive number:\n");
    else
    {
        for (j=1; i > 0; i--)             //��׳�����
        j = i *j;
        printf("the pactorial = %d\n",j);
    }
    return (&i);                          //����i�ĵ�ַ
}

int main()
{
    do
    {
        scanf("%d",fact());               //��һ��������д��i
    }
    while (1);                           //do{} while;�������do�е����ݣ�ֻ�е�while()��ֵΪ0ʱֹͣ��
}
