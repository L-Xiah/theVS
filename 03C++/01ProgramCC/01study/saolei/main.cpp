 #include   <stdlib.h>
  #include   <dos.h>
  #include   <conio.h>

  /*�����Ϣ�궨��*/
  #define   WAITING   0xff00
  #define   LEFTPRESS   0xff01
  #define   LEFTCLICK   0xff10
  #define   LEFTDRAG   0xff19
  #define   RIGHTPRESS   0xff02
  #define   RIGHTCLICK   0xff20
  #define   RIGHTDRAG   0xff2a
  #define   MIDDLEPRESS   0xff04
  #define   MIDDLECLICK   0xff40
  #define   MIDDLEDRAG   0xff4c
  #define   MOUSEMOVE   0xff08

struct
{
   int num;/*���ӵ�ǰ����ʲô״̬,1���ף�0�Ѿ���ʾ�����ֻ��߿հ׸���*/
   int roundnum;/*ͳ�Ƹ�����Χ�ж�����*/
   int flag;/*�Ҽ�������ʾ����ı�־,0û�к����־,1�к����־*/
}Mine[10][10];

int gameAGAIN=0;/*�Ƿ������ı���*/
int gamePLAY=0;/*�Ƿ��ǵ�һ������Ϸ�ı�־*/
int mineNUM;/*ͳ�ƴ�����ĸ�����*/
char randmineNUM[3];/*��ʾ���ֵ��ַ���*/

int Keystate;
int MouseExist;
int MouseButton;
int MouseX;
int MouseY;
int   up[16][16],down[16][16],mouse_draw[16][16],pixel_save[16][16];

 void   MouseMath()/*������������*/
  {int   i,j,jj,k;
  long   UpNum[16]={
                0x3fff,0x1fff,0x0fff,0x07ff,
                0x03ff,0x01ff,0x00ff,0x007f,
                0x003f,0x00ff,0x01ff,0x10ff,
                0x30ff,0xf87f,0xf87f,0xfc3f
                };
  long       DownNum[16]={
                0x0000,0x7c00,0x6000,0x7000,
                0x7800,0x7c00,0x7e00,0x7f00,
                0x7f80,0x7e00,0x7c00,0x4600,
                0x0600,0x0300,0x0300,0x0180
              };
        for(i=0;i<16;i++)
        {
        j=jj=15;
          while(UpNum[i]!=0)
          {
          up[i][j]=UpNum[i]%2;
          j--;
          UpNum[i]/=2;
          }
        while(DownNum[i]!=0)
          {
          down[i][jj--]=DownNum[i]%2;
          DownNum[i]/=2;
          }
      for(k=j;k>=0;k--)
        up[i][k]=0;
      for(k=jj;k>=0;k--)
        down[i][k]=0;
      for(k=0;k<16;k++)/*������Ϸ�ʽ*/
        {
        if(up[i][k]==0&&down[i][k]==0)
          mouse_draw[i][k]=1;
        else   if(up[i][k]==0&&down[i][k]==1)
          mouse_draw[i][k]=2;
        else   if(up[i][k]==1&&down[i][k]==0)
          mouse_draw[i][k]=3;
        else
          mouse_draw[i][k]=4;
      }
  }
  mouse_draw[1][2]=4;/*�����*/
  }

void Init(void);/*ͼ������*/
void MouseOn(int,int);/*�������ʾ*/
void MouseOff(void);/*���������*/
void MouseSetXY(int,int);/*���õ�ǰλ��*/
int  LeftPress(void);/*�������*/
int  RightPress(void);/*����Ҽ�����*/
int   MiddlePress();
void MouseGetXY(void);/*�õ���ǰλ��*/
int   MouseStatus();
void Control(void);/*��Ϸ��ʼ,����,�ر�*/
void GameBegain(void);/*��Ϸ��ʼ����*/
void DrawSmile(void);/*��Ц��*/
void DrawRedflag(int,int);/*��ʾ����*/
void DrawEmpty(int,int,int,int);/*���ֿո��ӵ���ʾ*/
void GameOver(void);/*��Ϸ����*/
void GameWin(void);/*��ʾʤ��*/
int  MineStatistics(int,int);/*ͳ��ÿ��������Χ������*/
int  ShowWhite(int,int);/*��ʾ�������Ŀհײ���*/
void GamePlay(void);/*��Ϸ����*/
void Close(void);/*ͼ�ιر�*/

void main(void)
{
   Init();
   MouseMath();
   //MouseOn(MouseX,MouseY);
   Control();
   Close();
}

void Init(void)/*ͼ�ο�ʼ*/
{
   int gd=DETECT,gm;
   registerbgidriver(EGAVGA_driver);
   initgraph(&gd,&gm,"");
}
void Close(void)/*ͼ�ιر�*/
{
   closegraph();
}
/*�������ʾ*/
  void  MouseOn(int   x,int   y)
      {
  int   i,j;
  int   color;

      for(i=0;i<16;i++)/*�����*/
      {
        for(j=0;j<16;j++)
          {
          pixel_save[i][j]=getpixel(x+j,y+i);/*����ԭ������ɫ*/
          if(mouse_draw[i][j]==1)
            putpixel(x+j,y+i,0);
          else   if(mouse_draw[i][j]==2)
            putpixel(x+j,y+i,15);
          }
        }
      }
/*�������*/
  void   MouseOff()
  {
  int   i,j,x,y,color;
  x=MouseX;
  y=MouseY;
  for(i=0;i<16;i++)/*ԭλ�������ȥ*/
      for(j=0;j<16;j++)
          {
          if(mouse_draw[i][j]==3||mouse_draw[i][j]==4)
            continue;
          color=getpixel(x+j,y+i);
          putpixel(x+j,y+i,color^color);
          putpixel(x+j,y+i,pixel_save[i][j]);
          }
  }
void MouseSetXY(int x,int y)/*���õ�ǰλ��*/
{
   _CX=x;
   _DX=y;
   _AX=0x04;
   geninterrupt(0x33);
}
int LeftPress(void)/*����������*/
{
   _AX=0x03;
   geninterrupt(0x33);
   return(_BX&1);
}
int RightPress(void)/*����Ҽ�����*/
{
   _AX=0x03;
   geninterrupt(0x33);
   return(_BX&2);
}
 /*�Ƿ����м�
      ����ֵͬ��       */
  int   MiddlePress()
      {
        _AX=0x03;
        geninterrupt(0x33);
        return(_BX&4);
      }
void MouseGetXY(void)/*�õ���ǰλ��*/
{
   _AX=0x03;
   geninterrupt(0x33);
   MouseX=_CX;
   MouseY=_DX;
}
/*��갴�����,����0��ʾֻ�ƶ�������1��ʾ���Ҽ�ͬʱ���£�2��ʾֻ���������3��ʾֻ�����Ҽ�*/

  int   MouseStatus()
  {
  int   x,y;
  int   status;
  int   press=0;

  int   i,j,color;
  status=0;/*Ĭ�����û���ƶ�*/

  x=MouseX;
  y=MouseY;

  while(x==MouseX&&y==MouseY&&status==0&&press==0)
  {
  if(LeftPress()&&RightPress())
      press=1;
  else   if(LeftPress())
      press=2;
  else   if(RightPress())
      press=3;
  MouseGetXY();
  if(MouseX!=x||MouseY!=y)
      status=1;
  }
  if(status)/*�ƶ������������ʾ���*/
  {
  for(i=0;i<16;i++)/*ԭλ�������ȥ*/
      for(j=0;j<16;j++)
          {
          if(mouse_draw[i][j]==3||mouse_draw[i][j]==4)
            continue;
          color=getpixel(x+j,y+i);
          putpixel(x+j,y+i,color^color);
          putpixel(x+j,y+i,pixel_save[i][j]);
          }
  MouseOn(MouseX,MouseY);/*��λ����ʾ*/
  }
  if(press!=0)/*�а��������*/
      return   press;
  return   0;/*ֻ�ƶ������*/
  }

void Control(void)/*��Ϸ��ʼ,����,�ر�*/
{
   int gameFLAG=1;/*��Ϸʧ�ܺ��ж��Ƿ����¿�ʼ�ı�־*/
   while(1)
   {
       MouseStatus();
      if(gameFLAG)/*��Ϸʧ�ܺ�û�жϳ����¿�ʼ�����˳���Ϸ�Ļ��ͼ����ж�*/
      {

     GameBegain(); /*��Ϸ��ʼ����*/
     GamePlay();/*������Ϸ*/
     if(gameAGAIN==1)/*��Ϸ�����¿�ʼ*/
     {
        gameAGAIN=0;
        continue;
     }
      }

   gameFLAG=0;
   if(LeftPress())/*�ж��Ƿ����¿�ʼ*/
   {
      if(MouseX>280&&MouseX<300&&MouseY>65&&MouseY<85)
      {
     gameFLAG=1;
     continue;
      }
   }
   if(kbhit())/*�ж��Ƿ񰴼��˳�*/
      break;
   }

}
void DrawSmile(void)/*��Ц��*/
{
    MouseOff();
   setfillstyle(SOLID_FILL,YELLOW);
   fillellipse(290,75,10,10);
   setcolor(YELLOW);
   setfillstyle(SOLID_FILL,BLACK);/*�۾�*/
   fillellipse(285,75,2,2);
   fillellipse(295,75,2,2);
   setcolor(BLACK);/*���*/
   bar(287,80,293,81);
   MouseGetXY();
   MouseOn(MouseX,MouseY);
}
void DrawRedflag(int i,int j)/*��ʾ����*/
{
    MouseOff();
   setcolor(7);
   setfillstyle(SOLID_FILL,RED);
   bar(198+j*20,95+i*20,198+j*20+5,95+i*20+5);
   setcolor(BLACK);
   line(198+j*20,95+i*20,198+j*20,95+i*20+10);
   MouseGetXY();
   MouseOn(MouseX,MouseY);
}
void DrawEmpty(int i,int j,int mode,int color)/*���ֿո��ӵ���ʾ*/
{
    MouseOff();
   setcolor(color);
   setfillstyle(SOLID_FILL,color);
   if(mode==0)/*û�е������Ĵ����*/
      bar(200+j*20-8,100+i*20-8,200+j*20+8,100+i*20+8);
   else
      if(mode==1)/*����������ʾ�հ׵�С����*/
     bar(200+j*20-7,100+i*20-7,200+j*20+7,100+i*20+7);
     MouseGetXY();
   MouseOn(MouseX,MouseY);
}
void GameBegain(void)/*��Ϸ��ʼ����*/
{
   int i,j;
   cleardevice();
   if(gamePLAY!=1)
   {
      MouseSetXY(290,70); /*���һ��ʼ��λ��,����Ϊ���ĳ�ʼ����*/
      MouseX=290;
      MouseY=70;
   }
   gamePLAY=1;/*�´ΰ����¿�ʼ�Ļ���겻���³�ʼ��*/
   mineNUM=0;
   setfillstyle(SOLID_FILL,7);
   bar(190,60,390,290);
   for(i=0;i<10;i++)/*������*/
      for(j=0;j<10;j++)
     DrawEmpty(i,j,0,8);
   setcolor(7);
   DrawSmile();/*����*/
   randomize();
   for(i=0;i<10;i++)/*100�����������ֵ��û�е���*/
      for(j=0;j<10;j++)
      {
     Mine[i][j].num=random(8);/*���������Ľ����1��ʾ��������е���*/
     if(Mine[i][j].num==1)
        mineNUM++;/*����������1*/
     else
        Mine[i][j].num=2;
     Mine[i][j].flag=0;/*��ʾû�����־*/
      }
   sprintf(randmineNUM,"%d",mineNUM); /*��ʾ����ܹ��ж�������*/
   setcolor(1);
   settextstyle(0,0,2);
   outtextxy(210,70,randmineNUM);
   mineNUM=100-mineNUM;/*����ȡ�հ׸�����*/

}
void GameOver(void)/*��Ϸ��������*/
{
   int i,j;
   setcolor(0);
   for(i=0;i<10;i++)
      for(j=0;j<10;j++)
     if(Mine[i][j].num==1)/*��ʾ���еĵ���*/
     {

        DrawEmpty(i,j,0,RED);
        setfillstyle(SOLID_FILL,BLACK);
        MouseOff();
        fillellipse(200+j*20,100+i*20,7,7);

        MouseGetXY();
        MouseOn(MouseX,MouseY);
     }
}
void GameWin(void)/*��ʾʤ��*/
{
   setcolor(11);
   settextstyle(0,0,2);
   outtextxy(230,30,"YOU WIN!");
}
int MineStatistics(int i,int j)/*ͳ��ÿ��������Χ������*/
{
   int nNUM=0;
   if(i==0&&j==0)/*���ϽǸ��ӵ�ͳ��*/
   {
      if(Mine[0][1].num==1)
     nNUM++;
      if(Mine[1][0].num==1)
     nNUM++;
      if(Mine[1][1].num==1)
     nNUM++;
   }
   else
      if(i==0&&j==9)/*���ϽǸ��ӵ�ͳ��*/
      {
     if(Mine[0][8].num==1)
        nNUM++;
     if(Mine[1][9].num==1)
        nNUM++;
     if(Mine[1][8].num==1)
        nNUM++;
      }
     else
     if(i==9&&j==0)/*���½Ǹ��ӵ�ͳ��*/
     {
        if(Mine[8][0].num==1)
           nNUM++;
        if(Mine[9][1].num==1)
           nNUM++;
        if(Mine[8][1].num==1)
           nNUM++;
     }
    else
        if(i==9&&j==9)/*���½Ǹ��ӵ�ͳ��*/
        {
           if(Mine[9][8].num==1)
          nNUM++;
           if(Mine[8][9].num==1)
          nNUM++;
           if(Mine[8][8].num==1)
          nNUM++;
        }
        else if(j==0)/*��ߵ�һ�и��ӵ�ͳ��*/
        {
           if(Mine[i][j+1].num==1)
          nNUM++;
           if(Mine[i+1][j].num==1)
          nNUM++;
           if(Mine[i-1][j].num==1)
          nNUM++;
           if(Mine[i-1][j+1].num==1)
          nNUM++;
           if(Mine[i+1][j+1].num==1)
          nNUM++;
        }
        else if(j==9)/*�ұߵ�һ�и��ӵ�ͳ��*/
        {
           if(Mine[i][j-1].num==1)
          nNUM++;
           if(Mine[i+1][j].num==1)
          nNUM++;
           if(Mine[i-1][j].num==1)
          nNUM++;
           if(Mine[i-1][j-1].num==1)
          nNUM++;
           if(Mine[i+1][j-1].num==1)
          nNUM++;
        }
        else if(i==0)/*��һ�и��ӵ�ͳ��*/
        {
           if(Mine[i+1][j].num==1)
          nNUM++;
           if(Mine[i][j-1].num==1)
          nNUM++;
           if(Mine[i][j+1].num==1)
          nNUM++;
           if(Mine[i+1][j-1].num==1)
          nNUM++;
           if(Mine[i+1][j+1].num==1)
          nNUM++;
         }
         else if(i==9)/*���һ�и��ӵ�ͳ��*/
         {
           if(Mine[i-1][j].num==1)
          nNUM++;
           if(Mine[i][j-1].num==1)
          nNUM++;
           if(Mine[i][j+1].num==1)
          nNUM++;
           if(Mine[i-1][j-1].num==1)
          nNUM++;
           if(Mine[i-1][j+1].num==1)
          nNUM++;
        }
        else/*��ͨ���ӵ�ͳ��*/
        {
           if(Mine[i-1][j].num==1)
          nNUM++;
           if(Mine[i-1][j+1].num==1)
          nNUM++;
           if(Mine[i][j+1].num==1)
          nNUM++;
           if(Mine[i+1][j+1].num==1)
          nNUM++;
           if(Mine[i+1][j].num==1)
          nNUM++;
           if(Mine[i+1][j-1].num==1)
          nNUM++;
           if(Mine[i][j-1].num==1)
          nNUM++;
           if(Mine[i-1][j-1].num==1)
          nNUM++;
         }
   return(nNUM);/*�Ѹ�����Χһ���ж���������ͳ�ƽ������*/
}
int ShowWhite(int i,int j)/*��ʾ�������Ŀհײ���*/
{
   if(Mine[i][j].flag==1||Mine[i][j].num==0)/*����к����ø�����Ͳ��Ըø�����κ��ж�*/
      return;
   mineNUM--;/*��ʾ�����ֻ��߿ո�ĸ��Ӿͱ�ʾ�ദ����һ������,�����и��Ӷ�������˱�ʾʤ��*/
   if(Mine[i][j].roundnum==0&&Mine[i][j].num!=1)/*��ʾ�ո�*/
   {
      DrawEmpty(i,j,1,7);

      Mine[i][j].num=0;
   }
   else
      if(Mine[i][j].roundnum!=0)/*�������*/
      {
     DrawEmpty(i,j,0,8);
     sprintf(randmineNUM,"%d",Mine[i][j].roundnum);
     setcolor(RED);
     MouseOff();
     outtextxy(195+j*20,95+i*20,randmineNUM);
     MouseGetXY();
     MouseOn(MouseX,MouseY);
     Mine[i][j].num=0;/*�Ѿ���������ĸ�����0��ʾ�Ѿ��ù��������*/
     return ;
      }
 /*8������ݹ���ʾ���еĿհ׸���*/
   if(i!=0&&Mine[i-1][j].num!=1)
      ShowWhite(i-1,j);
   if(i!=0&&j!=9&&Mine[i-1][j+1].num!=1)
      ShowWhite(i-1,j+1);
   if(j!=9&&Mine[i][j+1].num!=1)
      ShowWhite(i,j+1);
   if(j!=9&&i!=9&&Mine[i+1][j+1].num!=1)
      ShowWhite(i+1,j+1);
   if(i!=9&&Mine[i+1][j].num!=1)
      ShowWhite(i+1,j);
   if(i!=9&&j!=0&&Mine[i+1][j-1].num!=1)
      ShowWhite(i+1,j-1);
   if(j!=0&&Mine[i][j-1].num!=1)
      ShowWhite(i,j-1);
   if(i!=0&&j!=0&&Mine[i-1][j-1].num!=1)
      ShowWhite(i-1,j-1);
}
void GamePlay(void)/*��Ϸ����*/
{
   int i,j,Num;/*Num��������ͳ�ƺ�������һ��������Χ�ж��ٵ���*/
   for(i=0;i<10;i++)
      for(j=0;j<10;j++)
     Mine[i][j].roundnum=MineStatistics(i,j);/*ͳ��ÿ��������Χ�ж��ٵ���*/
   while(!kbhit())
   {     MouseStatus();
      if(LeftPress())/*�������̰���*/
      {

     if(MouseX>280&&MouseX<300&&MouseY>65&&MouseY<85)/*������*/
     {

        gameAGAIN=1;
        break;
     }
     if(MouseX>190&&MouseX<390&&MouseY>90&&MouseY<290)/*��ǰ���λ���ڸ��ӷ�Χ��*/
     {
        j=(MouseX-190)/20;/*x����*/
        i=(MouseY-90)/20;/*y����*/
        if(Mine[i][j].flag==1)/*��������к����������Ч*/
           continue;
        if(Mine[i][j].num!=0)/*�������û�д����*/
        {
           if(Mine[i][j].num==1)/*��갴�µĸ����ǵ���*/
           {

          GameOver();/*��Ϸʧ��*/
          break;
           }
           else/*��갴�µĸ��Ӳ��ǵ���*/
           {

          Num=MineStatistics(i,j);
          if(Num==0)/*��Χû���׾��õݹ��㷨����ʾ�հ׸���*/
             ShowWhite(i,j);
          else/*���¸�����Χ�е���*/
          {
              MouseOff();
             sprintf(randmineNUM,"%d",Num);/*�����ǰ������Χ������*/
             setcolor(RED);
             outtextxy(195+j*20,95+i*20,randmineNUM);
             mineNUM--;

             MouseGetXY();
             MouseOn(MouseX,MouseY);
          }

           Mine[i][j].num=0;/*����ĸ�����Χ���������ֱ�Ϊ0��ʾ��������Ѿ��ù�*/
           if(mineNUM<1)/*ʤ����*/
           {
          GameWin();
          break;
           }
        }
     }
      }
   }
   if(RightPress())/*����Ҽ����̰���*/
   {

      if(MouseX>190&&MouseX<390&&MouseY>90&&MouseY<290)/*��ǰ���λ���ڸ��ӷ�Χ��*/
      {
     j=(MouseX-190)/20;/*x����*/
     i=(MouseY-90)/20;/*y����*/

     if(Mine[i][j].flag==0&&Mine[i][j].num!=0)/*����û����������ʾ����*/
     {
        DrawRedflag(i,j);
        Mine[i][j].flag=1;
     }
     else
        if(Mine[i][j].flag==1)/*�к����־�ٰ��Ҽ��ͺ�����ʧ*/
        {
           DrawEmpty(i,j,0,8);
           Mine[i][j].flag=0;
        }
      }
      delay(1000000);
      delay(1000000);
      delay(1000000);
      delay(1000000);
      delay(1000000);
      }
   }
}
