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


namespace WinAppPageSetup
{
    public partial class Form1 : Form
    {
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern System.IntPtr GetWindowThreadProcessId(System.IntPtr hwnd, out int ID);
        [DllImport("user32.dll")]
        public static extern System.IntPtr FindWindowEx(System.IntPtr parent, System.IntPtr childe, string strclass, string strname);

        public Form1()
        {
            InitializeComponent();
            theStrPath = new List<string>();
            txt_Up.Text = "2.5";
            txt_Down.Text = "2.5";
            txt_Left.Text = "2.5";
            txt_Right.Text = "2.5";
            txt_Gutter.Text = "0";
            txt_HeaderDistance.Text = "1.5";
            txt_FooterDistance.Text = "1.7";

            this.Text = "WordPageSetup^^^^^^^^^^^" + WinAppPageSetup.Program.dVer ;
            System.Diagnostics.Debug.Print(Convert.ToInt32(true).ToString());
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
            openFileDialog1.FileName = "";
            openFileDialog1.Filter = "Word文档 (*.doc/docx)|*.doc?";
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


        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.Items.Count <= 0)
            {
                return;
            }
            float fUp = float.Parse(txt_Up.Text);
            float fDown = float.Parse(txt_Down.Text);
            float fLeft = float.Parse(txt_Left.Text);
            float fRight = float.Parse(txt_Right.Text);
            float fGutter = float.Parse(txt_Gutter.Text);
            float fHeaderDistance = float.Parse(txt_HeaderDistance.Text);
            float fFooterDistance = float.Parse(txt_FooterDistance.Text);

            int iFirst = 0;
            int iOddandEven = 0;
            if (chk_FirstPage.Checked)
            { iFirst = -1; }
            if (chk_OddAndEven.Checked)
            { iOddandEven = -1;}

            


            Object filename = "test.docx";
            Object filefullname = null;
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
            MSWord.Document tempDocument = null;
          
            theAppWord.Visible = false;
            //先关闭打开的文档（注意saveChanges选项）  
            Object saveChanges = MSWord.WdSaveOptions.wdSaveChanges;
            Object originalFormat = Type.Missing;
            Object routeDocument = Type.Missing;

            for (int i = 0; i < theStrPath.Count; i++)
            {
                progressBar1.Value = i * 100 / theStrPath.Count;
                filefullname = @theStrPath[i];
                try
                {
                    tempDocument = theAppWord.Documents.Open(ref filefullname, ref confirmConversions, ref readOnly, ref addToRecentFiles,
                        ref passwordDocument, ref passwordTemplate, ref revert,
                        ref writePasswordDocument, ref writePasswordTemplate,
                        ref format, ref encoding, ref visible, ref openConflictDocument,
                        ref openAndRepair, ref documentDirection, ref noEncodingDialog
                        );
                }
                catch
                {
                    return;
                }
                

                tempDocument.Sections[1].PageSetup.DifferentFirstPageHeaderFooter = iFirst;//首页不同
                tempDocument.Sections[1].PageSetup.OddAndEvenPagesHeaderFooter = iOddandEven;//奇偶页不同
                theAppWord.ActiveWindow.ActivePane.View.SeekView = MSWord.WdSeekView.wdSeekCurrentPageFooter;
                for (int j = 1; j <= tempDocument.Sections.Count; j++)
                {

                   
                    //设置页码续前节
                    tempDocument.Sections[j].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].Range.Select();
                    theAppWord.Selection.HeaderFooter.PageNumbers.NumberStyle = MSWord.WdPageNumberStyle.wdPageNumberStyleArabic;
                    theAppWord.Selection.HeaderFooter.PageNumbers.HeadingLevelForChapter = 0;
                    theAppWord.Selection.HeaderFooter.PageNumbers.IncludeChapterNumber = false;
                    theAppWord.Selection.HeaderFooter.PageNumbers.ChapterPageSeparator = MSWord.WdSeparatorType.wdSeparatorHyphen;
                    theAppWord.Selection.HeaderFooter.PageNumbers.RestartNumberingAtSection = false;
                    theAppWord.Selection.HeaderFooter.PageNumbers.StartingNumber = 0;
                    
                    //链接到前一节页眉页脚（奇偶页）
                    tempDocument.Sections[j].Headers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].LinkToPrevious = true;
                    tempDocument.Sections[j].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].LinkToPrevious = true;
                    tempDocument.Sections[j].Headers[MSWord.WdHeaderFooterIndex.wdHeaderFooterEvenPages].LinkToPrevious = true;
                    tempDocument.Sections[j].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterEvenPages].LinkToPrevious = true;


                    if (tempDocument.Sections[j].PageSetup.Orientation == MSWord.WdOrientation.wdOrientLandscape && j >1)
                    {
                        if (tempDocument.Sections[j-1].PageSetup.Orientation == MSWord.WdOrientation.wdOrientPortrait)
                        {//链接到前一节页眉页脚（奇偶页）
                        tempDocument.Sections[j].Headers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].LinkToPrevious = false ;
                        tempDocument.Sections[j].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterPrimary].LinkToPrevious = false ;
                        tempDocument.Sections[j].Headers[MSWord.WdHeaderFooterIndex.wdHeaderFooterEvenPages].LinkToPrevious = false ;
                        tempDocument.Sections[j].Footers[MSWord.WdHeaderFooterIndex.wdHeaderFooterEvenPages].LinkToPrevious = false ;
                        }

                        
                    }


                    tempDocument.Sections[j].PageSetup.TopMargin = theAppWord.CentimetersToPoints(fUp);
                    tempDocument.Sections[j].PageSetup.BottomMargin = theAppWord.CentimetersToPoints(fDown);
                    tempDocument.Sections[j].PageSetup.LeftMargin = theAppWord.CentimetersToPoints(fLeft);
                    tempDocument.Sections[j].PageSetup.RightMargin = theAppWord.CentimetersToPoints(fRight);
                    tempDocument.Sections[j].PageSetup.Gutter = theAppWord.CentimetersToPoints(fGutter);
                    tempDocument.Sections[j].PageSetup.HeaderDistance = theAppWord.CentimetersToPoints(fHeaderDistance);
                    tempDocument.Sections[j].PageSetup.FooterDistance = theAppWord.CentimetersToPoints(fFooterDistance);
                }

                theAppWord.ActiveWindow.ActivePane.View.SeekView = MSWord.WdSeekView.wdSeekMainDocument;

                ((MSWord._Document)tempDocument).Close(ref saveChanges, ref originalFormat, ref routeDocument);
            }

            ((MSWord._Application)theAppWord).Quit(Type.Missing, Type.Missing, Type.Missing);

            Kill(theAppWord);
            progressBar1.Value = 100;
            MessageBox.Show("恭喜您,Word文件页边距设置完成！", "页面设置！", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);





        }

        private void txt_Up_KeyPress(object sender, KeyPressEventArgs e)
        {
            //System.Diagnostics.Debug.Print("<<<<<" + e.KeyChar.ToString() + ">>>>>>>>>" );

            if (e.KeyChar != 8 && !Char.IsDigit(e.KeyChar))
            {
                if (e.KeyChar == '.')
                {
                    String temp = ((System.Windows.Forms.TextBox)sender).Text;
                    if (temp.IndexOf('.') >= 0)
                    { e.Handled = true; }

                }
                else
                { e.Handled = true; }
                
            }
            

        }
    }
}
