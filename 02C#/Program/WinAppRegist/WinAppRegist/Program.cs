using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppRegist
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (args.Length == 0)
            { Application.Run(new Form1()); }
            else
            {
                for (int i = 0; i < args.Length; i++)
                {
                    System.Diagnostics.Debug.Print(args[i]);
                }
                
            }

            


        }



    }
}
