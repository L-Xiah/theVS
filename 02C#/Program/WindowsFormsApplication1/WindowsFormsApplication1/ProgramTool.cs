using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DllImport所在的名字空间
using System.Runtime.InteropServices;

namespace WindowsFormsApplication1
{

    static class hsbiao
    {
        //焓熵表

        //[DllImport(@"D:\Excel\123\ZhengLenQi.dll")]
        //[DllImport("WindowsFormsApplication1.Resources.ZhengLenQi.dll")]
        [DllImport(@"D:\Excel\ZhengLenQi.dll")]  //引入非托管dll
        public static extern int dll_ifcshuip(ref double ptv, double P);



        static private double[] ptv = new double[8];
        //'' ''ptv(0)-压力P，ptv(1)-温度T，ptv(2)-比容V，ptv(3)-焓H，ptv(4)-熵S，ptv(5)-干度X，ptv(6)-粘度N，ptv(7)-导热系数K，ptv(8)-比热R



        static public double P_H(double p)
        {

            //数组清空
            Array.Clear(ptv, 0, ptv.Length);
            if (dll_ifcshuip(ref ptv[0], p) < 0 )
            { return -1; }
            return ptv[3];
        }

    }

    static class ProgramTool
    {
        static public Boolean IsN(int tempA)
        {
            if (tempA > 10)
            { return true; }
            else
            { return false; }
        }



    }








}
