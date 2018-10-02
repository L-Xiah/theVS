//例子1.3C 函数返回指向静态变量的地址

#include <stdio.h>
int* fact ()                               //该函数类型为一个整数类型的指针（地址）
{
    static int i=0,j;                      //如果去掉static限定预测并观察程序运行结果
    if (i <= 0)
        printf("please input a positive number:\n");
    else
    {
        for (j=1; i > 0; i--)             //求阶乘运算
        j = i *j;
        printf("the pactorial = %d\n",j);
    }
    return (&i);                          //返回i的地址
}

int main()
{
    do
    {
        scanf("%d",fact());               //将一个操作数写入i
    }
    while (1);                           //do{} while;语句先做do中的内容，只有当while()中值为0时停止。
}
