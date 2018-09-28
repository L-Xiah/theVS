using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.IO;

namespace WindowsFormsApplication1
{
    
#region "C#/C++"

    /************
     * C#已经和Vb非常的类似了
     * C#默认有个主程序入口，vb默认是启动窗体
     * C#省去了MFC的框架
     * 
     * 
     * 
     * *******/


#endregion



    #region "sddf"




    #endregion


    static class ProgramMain
        {
            /// <summary>
            /// 应用程序的主入口点。
            /// </summary>
            [STAThread]
            static void Main()
            {

                using(Program04Location temp = new Program04Location())
                {   temp.TheMain();                }


                using (TheThread temp = new TheThread())
                {  temp.MainSub();                }

                using ( Program03Process theProcess = new Program03Process())
                {  theProcess.theProcessStartClose();                }

                //Program03Process theProcess = new Program03Process();
                //theProcess.GetProcess();



                //添加程序集解析事件
                AppDomain.CurrentDomain.AssemblyResolve += CurrentDomain_AssemblyResolve;

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form1());
                Application.Run(new Form2());
            }


            //当程序集加载失败时调用此事件
            static System.Reflection.Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
            {
                return LoadFromResource("ZhengLenQi.dll");
            }


            //加载资源转为Assembly程序集
            private static Assembly LoadFromResource(string resName)
            {
                Assembly ass = Assembly.GetExecutingAssembly();
                using (Stream stream = ass.GetManifestResourceStream("AutoPublish.Resources." + resName))
                {
                    byte[] bt = new byte[stream.Length];
                    stream.Read(bt, 0, bt.Length);
                    Assembly asm = Assembly.Load(bt);//转换流到程序集
                    return asm;
                }
                //return null;
            }



        }

}
