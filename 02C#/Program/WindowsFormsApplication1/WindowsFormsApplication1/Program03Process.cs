using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;


namespace WindowsFormsApplication1
{
    class Program03Process: IDisposable
    {


        public bool GetProcess()
        {
            string str = "";
            Process[] processes;
            //Get the list of current active processes.
            processes = System.Diagnostics.Process.GetProcesses();
            //Grab some basic information for each process.
            Process process;
            for (int i = 0; i < processes.Length - 1; i++)
            {
                process = processes[i];
                str = str + Convert.ToString(process.Id) + " : " +
                process.ProcessName + "\r\n";
            }
            //Display the process information to the user
            System.Diagnostics.Debug.Print(str);

            process = System.Diagnostics.Process.GetCurrentProcess();
            str = Convert.ToString(process.Id) + " : " + process.ProcessName + "\r\n"; 

            System.Windows.Forms.MessageBox.Show(str);

            return true;

        }

        public void theProcessStartClose()
        {
            try
            {
                Process myProcess;
                myProcess = Process.Start("Notepad.exe");
                // Display physical memory usage 5 times at intervals of 2 seconds.
                for (int i = 0; i < 5; i++)
                {
                    if (!myProcess.HasExited)
                    {
                        // Discard cached information about the process.
                        myProcess.Refresh();
                        // Print working set to console.
                        System.Diagnostics.Debug.WriteLine("Physical Memory Usage: "
                                             + myProcess.WorkingSet64.ToString());
                        // Wait 2 seconds.
                        System.Threading.Thread.Sleep(2000);
                    }
                    else
                    {
                        break;
                    }
                }

                // Close process by sending a close message to its main window.
                myProcess.CloseMainWindow();
                // Free resources associated with process.
                myProcess.Close();

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine("The following exception was raised: ");
                System.Diagnostics.Debug.WriteLine(e.Message);
            }
        }






        #region "Dispose"




        private bool disposed = false;
        ~Program03Process()
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



    class TheThread : IDisposable
    {

        

        private void Game()
        {
            System.Windows.Forms.MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fffff") + " - The Game ");
        }

        private void Music()
        {
            System.Windows.Forms.MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fffff") + " The Music  "); 
        }


        public void MainSub()
        {
            System.Threading.Thread t1 = new System.Threading.Thread(new System.Threading.ThreadStart(Game));
            System.Threading.Thread t2 = new System.Threading.Thread(new System.Threading.ThreadStart(Music));

            t1.Priority = System.Threading.ThreadPriority.BelowNormal;
            t2.Priority = System.Threading.ThreadPriority.Lowest;
            t1.Start();
            t2.Start();
            System.Windows.Forms.MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fffff") + " The Main Thread  ");

            t1.Join();
            t2.Join();

            System.Windows.Forms.MessageBox.Show(DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss.fffff") + " The Thread Closed  ");

        
        }


      


 
         #region "Dispose"




        private bool disposed = false;
        ~TheThread()
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
