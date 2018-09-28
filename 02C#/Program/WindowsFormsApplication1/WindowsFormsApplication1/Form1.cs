using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.IO;



//DllImport所在的名字空间
using System.Runtime.InteropServices;




namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {


        /// <summary>
         /// 该函数检索一指定窗口的客户区域或整个屏幕的显示设备上下文环境的句柄，以后可以在GDI函数中使用该句柄来在设备上下文环境中绘图。hWnd：设备上下文环境被检索的窗口的句柄
        /// </summary>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
         public static extern IntPtr GetDC(IntPtr hWnd);
         /// <summary>
         /// 函数释放设备上下文环境（DC）供其他应用程序使用。
        /// </summary>
        //public static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);


        

        

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {


            /******************
             * Excel文件操作
             * */
            Microsoft.Office.Interop.Excel.Application tempAppExcel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook tempWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet tempWorkSheet;           
            tempAppExcel.Visible = true;
            tempWorkBook = tempAppExcel.Workbooks.Add(true);
            tempWorkSheet = tempWorkBook.Worksheets.Add();
            tempWorkSheet.Name = "info";




            int n = 0;

            tempWorkSheet.Cells[1, 1] = textBox1.Text;
            tempWorkSheet.Cells[1, 2] = textBox2.Text;
            tempWorkSheet.Cells[1, 3] = textBox3.Text;
            tempWorkSheet.Cells[1, 4] = textBox4.Text;
            //for (i = 0; i < 10; i++)
            //{
            //    n = n + i;
            //    tempWorkSheet.Cells[i + 1, 1] = n;

            //}

            textBox1.Text = "sdd" + n;



        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (ProgramTool.IsN(12))
            {
                MessageBox.Show("11111111", "10",MessageBoxButtons.OK,MessageBoxIcon.Error );
                   
            }


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("---", "***", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }


        #region "File Read/Write"

        private void button3_Click(object sender, EventArgs e)
        {

            TextFileIO theFileIo = new TextFileIO() ;
            theFileIo.WriteTextFile();


            MessageBox.Show("The End^^^^^^^^^^^^","--button3--",MessageBoxButtons.OK,MessageBoxIcon.Stop );
            

        }

        private void button4_Click(object sender, EventArgs e)
        {
            TextFileIO theFileIo = new TextFileIO();
            theFileIo.ReadTextFile();


            MessageBox.Show("The End^^^^^^^^^^^^", "--button3--", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        #endregion


        #region "Draw on the screen"

        private void button5_Click(object sender, EventArgs e)
        {
            
            System.IntPtr DesktopHandle = GetDC(System.IntPtr.Zero);
            Graphics g = Graphics.FromHdc(DesktopHandle);
            g.DrawRectangle(new Pen(Color.Red), new Rectangle(150, 150, 1000, 100));


            // Create string to draw.
            String drawString = "Sample Text";

            // Create font and brush.
            Font drawFont = new Font("Arial", 16);
            SolidBrush drawBrush = new SolidBrush(Color.Red);

            // Create point for upper-left corner of drawing.
            PointF drawPoint = new PointF(150.0F, 150.0F);



            g.DrawString(drawString,drawFont,drawBrush,drawPoint);

            return;


        }

        private void button6_Click(object sender, EventArgs e)
        {
            Image img = Image.FromFile(@"D:\img8.jpg");

            IntPtr hDesk = GetDC(IntPtr.Zero);

            Graphics gN = Graphics.FromHdc(hDesk);

            gN.DrawImage(img, 0, 0);
        }

        #endregion
        

        #region "调用焓熵表Class"

        private void button7_Click(object sender, EventArgs e)
        {

            double tempH;
            tempH = hsbiao.P_H(2.5);

            MessageBox.Show(tempH + "---", "Han", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

        }

        #endregion
            

        #region "加载嵌入资源文件"

        private void button8_Click(object sender, EventArgs e)
        {

            System.Reflection.Assembly _every = LoadFromResource(".Resources.ZhengLenQi.dll");


            Module[] mods = _every.GetModules();
            Console.WriteLine("\tModules in the assembly:");
            foreach (Module m in mods)
            System.Diagnostics.Debug.Print ("\t{0}", m);



            //_every.GetModules();

            //var plugin = Activator.CreateInstance(_every);
            //object[] paramertors = new object[] { 500, 2 };//参数集合
            //var temp = _every.GetMethod("Add");
            //object result = temp.Invoke(plugin, paramertors);
            //Console.WriteLine(result);


        }

        
        //加载资源转为Assembly程序集
        private static Assembly LoadFromResource(string resName)
        {



            Assembly ass = Assembly.GetExecutingAssembly();


              //var res = ass.GetManifestResourceNames();
              //System.Diagnostics.Debug.Print(ass.GetName().Name);
              //foreach (var r in res)
              //{
              //    System.Diagnostics.Debug.Print(r);
              //}


            using (Stream stream = ass.GetManifestResourceStream(ass.GetName().Name + resName))
            {
                byte[] bt = new byte[stream.Length];
                stream.Read(bt, 0, bt.Length);
                Assembly asm = Assembly.Load(bt);//转换流到程序集
                return asm;
            }
            //return null;
        }


        #endregion

        
        #region "动态加载C++生成的dll"

        LoadDll loaddll = new LoadDll();//实例化加载ＤＬＬ文件的类，，如上     
        public delegate int delegateadd(ref double ptv, double P);//声明此方法的一个委托  

        private void button9_Click(object sender, EventArgs e)
        {

            loaddll.initPath(@"D:\Excel\ZhengLenQi.dll");//载入文件     
            delegateadd m = (delegateadd)loaddll.InvokeMethod("dll_ifcshuip", typeof(delegateadd));//获取其中方法的委托     
            double[] ptv = new double[8];
            double p = 2.5;
            int re = m(ref ptv[0], p);//得到ＲＥ＝3，，成功     
            MessageBox.Show(ptv[3] + "---", "Han", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);

            
        }


        #endregion

       


    }






}
