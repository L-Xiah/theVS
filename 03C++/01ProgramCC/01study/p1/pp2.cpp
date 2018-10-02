//例子1.2 了解一下by reference类型的变量
//
//    By reference 类型的变量在被初始化的时候需要接受一个同类型的变量名 (如：count)。完成初始化后，该变量就可以认为是count变量的别名。所有对该变量的操作都会反映到count变量中。
#include <stdio.h>
void f11()

{
   static int count = 0;                 //use static variable

   int& j = count;                       //j改为by reference类型，看看值会如何变化？

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
