using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppTheMeetingRecord
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            MeetingList temp = new MeetingList();

            Application.Run(temp);
            //Application.Run(new MeetingList());
        }


        static public TheClass.ClassConData theConn;
        static public TheClass.ClassData theData = new TheClass.ClassData();
    }
}
