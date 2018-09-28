using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MSWord = Microsoft.Office.Interop.Word;
using System.Runtime.InteropServices;

namespace WinAppWordMerge
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern System.IntPtr GetWindowThreadProcessId(System.IntPtr hwnd, out int ID);
        [DllImport("user32.dll")]
        public static extern System.IntPtr FindWindowEx(System.IntPtr parent, System.IntPtr childe, string strclass, string strname);
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        private static extern void keybd_event(byte bVk, byte bScan, uint dwFlags, uint dwExtraInfo);
        [DllImport("user32.dll")]
        public static extern IntPtr SetFocus(IntPtr hWnd);//设定焦点



        private const int WM_CHAR = 0X102;


        public Form1()
        {
            InitializeComponent();
            theStrPath = new List<string>();
        }


        List<string> theStrPath;

        private void Kill(MSWord.Application word)
        {

            IntPtr p = FindWindowEx(System.IntPtr.Zero, System.IntPtr.Zero, null, word.Caption);
            int k = 0;

            GetWindowThreadProcessId(p, out k);   //得到本进程唯一标志k  
            if (k != 0)
            {
                System.Diagnostics.Process fp = System.Diagnostics.Process.GetProcessById(k);   //得到对进程k的引用  

                fp.Kill();
            }//关闭进程k  
        }

        private void button1_Click(object sender, EventArgs e)
        {


            openFileDialog1.InitialDirectory = "D:\\";
            //openFileDialog1.DefaultExt = ".files";
            openFileDialog1.Filter = "txt files (*.doc/docx)|*.doc?";
            openFileDialog1.FilterIndex = 1;
            openFileDialog1.Multiselect = true;
            // Call the ShowDialog method to show the dialog box.
            //bool? userClickedOK = openFileDialog1.ShowDialog();

            // Process input if the user clicked OK.
            if (openFileDialog1.ShowDialog() != DialogResult.OK)
            { return; }


      
             foreach (String file in openFileDialog1.FileNames) 
        {
                 listBox1.Items.Add(file);
                 theStrPath.Add(file);
             }



    
           
            // Open the selected file to read.
               
            

            

        }

        private void button2_Click(object sender, EventArgs e)
        {


            if (listBox1.Items.Count <= 1)
            {
                return;
            }
            Object filename = "test.docx";
            Object filefullname = @theStrPath[0];
            Object confirmConversions = Type.Missing;
            Object readOnly = false;
            Object addToRecentFiles = Type.Missing;
            Object passwordDocument = Type.Missing;
            Object passwordTemplate = Type.Missing;
            Object revert = Type.Missing;
            Object writePasswordDocument = Type.Missing;
            Object writePasswordTemplate = Type.Missing;
            Object format = Type.Missing;
            Object encoding = Type.Missing;
            Object visible = Type.Missing;
            Object openConflictDocument = Type.Missing;
            Object openAndRepair = Type.Missing;
            Object documentDirection = Type.Missing;
            Object noEncodingDialog = Type.Missing;  

            Microsoft.Office.Interop.Word.Application theAppWord = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document theDocument = null;
            MSWord.Document tempDocument = null;
            theDocument = theAppWord.Documents.Open(ref filefullname, ref confirmConversions, ref readOnly, ref addToRecentFiles,  
                        ref passwordDocument, ref passwordTemplate, ref revert,  
                        ref writePasswordDocument, ref writePasswordTemplate,  
                        ref format, ref encoding, ref visible, ref openConflictDocument,  
                        ref openAndRepair, ref documentDirection, ref noEncodingDialog  
                        );

            theAppWord.Visible = false;
            //先关闭打开的文档（注意saveChanges选项）  
            Object saveChanges = MSWord.WdSaveOptions.wdSaveChanges;
            Object originalFormat = Type.Missing;
            Object routeDocument = Type.Missing;

            object docStart = null;
            object docEnd = null;
            object start = null;
            object end = null;

            for (int i = 1; i < theStrPath.Count; i++)
            {
                progressBar1.Value = i * 100 / theStrPath.Count;
                filefullname = @theStrPath[i];
                readOnly = true;
                tempDocument = theAppWord.Documents.Open(ref filefullname, ref confirmConversions, ref readOnly, ref addToRecentFiles,
                        ref passwordDocument, ref passwordTemplate, ref revert,
                        ref writePasswordDocument, ref writePasswordTemplate,
                        ref format, ref encoding, ref visible, ref openConflictDocument,
                        ref openAndRepair, ref documentDirection, ref noEncodingDialog
                        );


                theDocument.Sections.Add();
                docStart = theDocument.Content.End - 1;
                docEnd = theDocument.Content.End;

                start = tempDocument.Content.Start;
                end = tempDocument.Content.End;
                //tempDocument.Range(ref start, ref end).Copy();
                
                tempDocument.Activate();
                theAppWord.ActiveWindow.View.Type = MSWord.WdViewType.wdNormalView;
                theAppWord.Selection.WholeStory();
                theAppWord.Selection.Copy();

                //计算word文档页数
                
                MSWord.WdStatistic tempstart = MSWord.WdStatistic.wdStatisticPages;
                int num = tempDocument.ComputeStatistics(tempstart);

                System.Diagnostics.Debug.Print("--------------------" + num);
                theDocument.Activate();
                //theAppWord.Selection.EndKey(MSWord.WdUnits.wdStory);
                if (num > 10)
                {
                    IntPtr p = FindWindowEx(System.IntPtr.Zero, System.IntPtr.Zero, null, theAppWord.Caption);
                    SetFocus(p);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.ControlKey), 0, 0, 0);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.End), 0, 0, 0);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.ControlKey), 0, 0, 0);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.End), 0, 2, 0);

                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.ControlKey), 0, 0, 0);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.V), 0, 0, 0);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.ControlKey), 0, 2, 0);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.V), 0, 2, 0);
                    System.Threading.Thread.Sleep(500);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.N), 0, 0, 0);
                    keybd_event(Convert.ToByte(System.Windows.Forms.Keys.N), 0, 2, 0);
                    //byte[] ch = (ASCIIEncoding.ASCII.GetBytes());
                    //SendMessage(p, WM_CHAR, Convert.ToByte(System.Windows.Forms.Keys.ControlKey), 0);
                    //SendMessage(p, WM_CHAR, Convert.ToByte(System.Windows.Forms.Keys.V), 0);
                    
                }
                else
                {
                    theAppWord.Selection.PasteAndFormat(MSWord.WdRecoveryType.wdUseDestinationStylesRecovery);
                }               
                
                
                //theDocument.Range(ref docStart, ref docEnd).PasteAndFormat(MSWord.WdRecoveryType.wdUseDestinationStylesRecovery);

                saveChanges = MSWord.WdSaveOptions.wdDoNotSaveChanges;
                ((MSWord._Document)tempDocument).Close(ref saveChanges, ref originalFormat, ref routeDocument);  
            }

            saveChanges = MSWord.WdSaveOptions.wdSaveChanges;
            ((MSWord._Document)theDocument).Close(ref saveChanges, ref originalFormat, ref routeDocument);

            ((MSWord._Application)theAppWord).Quit(Type.Missing,Type.Missing,Type.Missing);

            Kill(theAppWord);
            progressBar1.Value = 100;
            MessageBox.Show("恭喜您,Word文件合标完成！","合并成功！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            if (listBox1.SelectedIndex <= 0)
            { return; }

            int i = listBox1.SelectedIndex;

            int count = theStrPath.Count;

            String tempStr = theStrPath[i];

            theStrPath[i] = theStrPath[i - 1];
            theStrPath[i - 1] = tempStr;

            listBox1.Items.Clear();

            for (int j = 0; j < theStrPath.Count; j++)
            {
                listBox1.Items.Add(theStrPath[j]);
            }

            listBox1.SelectedIndex = i - 1;
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0 || listBox1.SelectedIndex == listBox1.Items.Count -1)
            { return; }

            int i = listBox1.SelectedIndex;

            int count = theStrPath.Count;

            String tempStr = theStrPath[i];

            theStrPath[i] = theStrPath[i + 1];
            theStrPath[i + 1] = tempStr;

            listBox1.Items.Clear();

            for (int j = 0; j < theStrPath.Count; j++)
            {
                listBox1.Items.Add(theStrPath[j]);
            }

            listBox1.SelectedIndex = i + 1;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();

            theStrPath.Clear();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex < 0)
            { return; }
            theStrPath.RemoveAt(listBox1.SelectedIndex);
            listBox1.Items.RemoveAt(listBox1.SelectedIndex);
            listBox1.Refresh();
            
            



        }

        private void button7_Click(object sender, EventArgs e)
        {
            int count = theStrPath.Count;
            if (count <= 1)
            { return; }

            int i = count / 2 - 1;
            String tempStr = "";
            int tempInt;
            for (int j = 0; j <= i; j++)
            {
                tempStr = theStrPath[j];
                tempInt = count - j - 1;
                theStrPath[j] = theStrPath[tempInt];
                theStrPath[tempInt] = tempStr;

            }

            listBox1.Items.Clear();

            for (int j = 0; j < theStrPath.Count; j++)
            {
                listBox1.Items.Add(theStrPath[j]);
            }

        }




    }
}
