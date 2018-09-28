using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Runtime.InteropServices;
using System.Threading;



namespace WindowsFormsApplication1
{

   
    class Program04Location : IDisposable
    {

        [DllImport("user32.dll")]
        static extern IntPtr FindWindow(IntPtr classname, string title); // extern method: FindWindow

        [DllImport("user32.dll")]
        static extern void MoveWindow(IntPtr hwnd, int X, int Y, int nWidth, int nHeight, bool rePaint); // extern method: MoveWindow

        [DllImport("user32.dll")]
        static extern bool GetWindowRect(IntPtr hwnd, out System.Drawing.Rectangle rect); // extern method: GetWindowRect


        void FindAndMoveMsgBox(int x, int y, bool repaint, string title)
        {
            Thread thr = new Thread(() => // create a new thread
            {
                IntPtr msgBox = IntPtr.Zero;
                // while there's no MessageBox, FindWindow returns IntPtr.Zero
                while ((msgBox = FindWindow(IntPtr.Zero, title)) == IntPtr.Zero) ;
                // after the while loop, msgBox is the handle of your MessageBox
                System.Drawing.Rectangle r = new System.Drawing.Rectangle();
                GetWindowRect(msgBox, out r); // Gets the rectangle of the message box
                MoveWindow(msgBox /* handle of the message box */, x, y,
                  r.Width - r.X /* width of originally message box */,
                  r.Height - r.Y /* height of originally message box */,
                  repaint /* if true, the message box repaints */);
            });
            thr.Start(); //: starts the thread
        }



        public void TheMain()
        {
            FindAndMoveMsgBox(0, 0, true, "Title01");
            System.Threading.Thread.Sleep(13000);
            System.Windows.Forms.MessageBox.Show("Message", "Title01");

        }


            #region "Dispose"




        private bool disposed = false;
        ~Program04Location()
        {
            Dispose(true);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (disposed == false)
            {
                if (disposing == true)
                {
                    // 释托管代码
                    // ......
                }
                // 释非代码
                //......
            }
            disposed = true;
        }

        #endregion



    }
}
