using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//DllImport所在的名字空间
using System.Runtime.InteropServices;


namespace WindowsFormsApplication1
{
    #region Win API 声明
    class LoadDllAPI
    {

        [DllImport("kernel32.dll")]
        public extern static IntPtr LoadLibrary(string path);

        [DllImport("kernel32.dll")]
        public extern static IntPtr GetProcAddress(IntPtr lib, string funcName);

        [DllImport("kernel32.dll")]
        public extern static bool FreeLibrary(IntPtr lib);

        [DllImport("kernel32.dll")]
        public static extern IntPtr GetStdHandle(int nStdHandle);

        [DllImport("user32", EntryPoint = "CallWindowProc")]
        public static extern int CallWindowProc(IntPtr lpPrevWndFunc, int hwnd, int MSG, int wParam, int lParam);
    }
    #endregion

    public class LoadDll
    {
        IntPtr DllLib;//DLL文件名柄     
        #region 构造函数
        public LoadDll()
        { }
        public LoadDll(string dllpath)
        {
            DllLib = LoadDllAPI.LoadLibrary(dllpath);
        }
        #endregion
        /// <summary>     
        /// 析构函数     
        /// </summary>     
        ~LoadDll()
        {
            LoadDllAPI.FreeLibrary(DllLib);//释放名柄     
        }
        public void initPath(string dllpath)
        {
            if (DllLib == IntPtr.Zero)
            {
                DllLib = LoadDllAPI.LoadLibrary(dllpath);
            }
        }
        /// <summary>     
        /// 获取ＤＬＬ中一个方法的委托     
        /// </summary>     
        /// <param name="methodname"></param>     
        /// <param name="methodtype"></param>     
        /// <returns></returns>     
        public Delegate InvokeMethod(string methodname, Type methodtype)
        {
            IntPtr MethodPtr = LoadDllAPI.GetProcAddress(DllLib, methodname);

            return (Delegate)Marshal.GetDelegateForFunctionPointer(MethodPtr, methodtype);
        }
    }
    
    class TextFileIO
    {
        //@在c#中为强制不转义 的符号,在里面的转义字符无效。
        const string Const_thePath = @"D:\testDir\";

        public Boolean WriteTextFile()
        {
            Boolean IsReturn = false;

            //如果文件不存在，则创建；存在则覆盖
            //该方法写入字符数组换行显示
            string[] lines = { "first line", "second line", "third line", "第四行" };
            System.IO.File.WriteAllLines(Const_thePath + "test.txt", lines, Encoding.UTF8);

            //如果文件不存在，则创建；存在则覆盖
            string strTest = "该例子测试一个字符串写入文本文件。";
            System.IO.File.WriteAllText(Const_thePath + "test1.txt", strTest, Encoding.UTF8);

            //在将文本写入文件前，处理文本行
            //StreamWriter一个参数默认覆盖
            //StreamWriter第二个参数为false覆盖现有文件，为true则把文本追加到文件末尾
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(Const_thePath + "test2.txt", true))
            {
                foreach (string line in lines)
                {
                    if (!line.Contains("second"))
                    {
                        file.Write(line);//直接追加文件末尾，不换行
                        file.Write("//");
                        file.WriteLine(line);// 直接追加文件末尾，换行   
                    }
                }
            }


            return IsReturn;
        }


        public Boolean ReadTextFile()
        {
            Boolean IsReturn = false;

            System.Diagnostics.Debug.Close();

            //直接读取出字符串
            string text = System.IO.File.ReadAllText(Const_thePath + "test1.txt");
            System.Diagnostics.Debug.Print(text);



            //按行读取为字符串数组
            string[] lines = System.IO.File.ReadAllLines(Const_thePath + "test.txt");
            foreach (string line in lines)
            {
                System.Diagnostics.Debug.Print(line);
            }

            //从头到尾以流的方式读出文本文件
            //该方法会一行一行读出文本
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Const_thePath + "test2.txt"))
            {
                string str;
                while ((str = sr.ReadLine()) != null)
                {
                    System.Diagnostics.Debug.Print(str);

                }
            }

            return IsReturn;
        }





    }


}
