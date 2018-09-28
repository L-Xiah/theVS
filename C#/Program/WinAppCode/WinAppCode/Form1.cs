using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {




            Stream myStream = null;
            openFileDialog1 = new OpenFileDialog();

            openFileDialog1.InitialDirectory = "D:\\";
            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.Multiselect = false;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                 string fileName = openFileDialog1.FileName;
                 System.DateTime startTime = TimeZone.CurrentTimeZone.ToLocalTime(new System.DateTime(1970, 1, 1)); // 当地时区
                 long timeStamp = (long)(DateTime.Now - startTime).TotalMilliseconds; // 相差毫秒数
                 System.Diagnostics.Debug.Print("------" + openFileDialog1.FileName);//Console.Write("------" + openFileDialog1.FileName);
                 if (File.Exists(fileName))
                    {
                        string fileNameNew = System.IO.Path.GetDirectoryName(fileName) + "\\temp" + timeStamp + System.IO.Path.GetFileName(fileName);
                        Console.Write("--------------------------" + fileNameNew);
                        Console.WriteLine();
                        BinaryReader binReader = new BinaryReader(File.Open(fileName, FileMode.Open,FileAccess.Read));
                        BinaryWriter binWriter = new BinaryWriter(File.Open(fileNameNew, FileMode.Create));
                        try
                        {
                            // If the file is not empty,
                            // read the application settings.
                            // First read 4 bytes into a buffer to
                            // determine if the file is empty.
                            byte[] testArray = new byte[3];
                            int count = binReader.Read(testArray, 0, 3);
                            Byte t1 = 0x2b;//非
                            Byte t2 = 0xd4;//不变
                            if (count != 0)
                            {
                                // Reset the position in the stream to zero.
                                binReader.BaseStream.Seek(0, SeekOrigin.Begin);
                                Byte b1;

                                do
                                {
                                    b1 = binReader.ReadByte();             // 13为"\n"，表示回车；10为"\r"，表示换行   
                                    Console.Write("{0}-{1}", b1.ToString(), b1.ToString("x2"));
                                    Console.Write(",");
                                    b1 = (byte)((b1 & t2)|((~b1) & t1));
                                    Console.Write("{0}-{1}", b1.ToString(), b1.ToString("x2"));
                                    Console.Write("...");
                                    binWriter.Write(b1);


                                } while (true);      
                                Console.WriteLine("\n");         // 以二进制方式读文件结束

                            }
                        }

                        // If the end of the stream is reached before reading
                        // the four data values, ignore the error and use the
                        // default settings for the remaining values.
                        catch (EndOfStreamException es)
                        {
                            Console.WriteLine("{0} caught and ignored. " +
                                "Using default values.", es.GetType().Name);
                        }
                        finally
                        {
                            binWriter.Flush();
                            binWriter.Close();
                            binReader.Close();
                        }
                    }


                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            // Insert code to read the stream here.
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }





        }
    }
}
