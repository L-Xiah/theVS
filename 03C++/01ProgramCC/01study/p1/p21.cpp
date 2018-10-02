//第二部分 观察理解程序运行时变量的空间分配及生存期
//2.1 阅读理解下面程序。运行观察auto类型变量的地址及变化情况。理解auto类型变量的生存期。

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
