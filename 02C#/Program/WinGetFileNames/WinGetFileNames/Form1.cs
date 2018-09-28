using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WinGetFileNames
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            comboBox1.Items.Add("*.*");
            comboBox1.Items.Add("*.pdf");
            comboBox1.Items.Add("*.doc");
        }

        private void button1_Click(object sender, EventArgs e)
        {

            folderBrowserDialog1.Description = "请选择遍历目录！";
            if (folderBrowserDialog1.ShowDialog() != DialogResult.OK && folderBrowserDialog1.ShowDialog() != DialogResult.Yes)
            {      return;}



            label1.Text = folderBrowserDialog1.SelectedPath;
            DirectoryInfo direcIn = new DirectoryInfo(folderBrowserDialog1.SelectedPath);

            ClassGetFile theFile = new ClassGetFile();
            String tempPattern = "";
            if (comboBox1.Text != "")
            { tempPattern = comboBox1.Text; }
            else
            { tempPattern = "*"; }
            
            theFile.GetFileName(direcIn,tempPattern,1);

           

            List<String> theList = theFile.theStrFullName;
            String tempIntoal = "";
            for (int i = 0; i < theFile.theIntCount; i++)
            {
                tempIntoal = tempIntoal + theFile.theStrFileName[i] + "\t" + theFile.theStrFullName[i] + "\t" + theFile.theStrName[i]
                     + "\t" + theFile.theStrExtension[i] + "\r\n";
 
            }
                foreach (String tempStr in theList)
                {
                    tempIntoal = tempIntoal + tempStr + "\r\n";
                }
            richTextBox1.Clear();
            richTextBox1.Text = tempIntoal;
            //for (int i = 1; i < 10; i++ )
            //{ theList.Add("12--" + i); }
            //theFile.theStrList = theList;

            System.Diagnostics.Debug.Print("-------------------");
            System.Diagnostics.Debug.Print(theFile.theStrFullName.Count.ToString());
        }

        private void button2_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.SaveFileDialog tempSaveFileDialog = new System.Windows.Forms.SaveFileDialog();

            tempSaveFileDialog.InitialDirectory = "D:\\";
            tempSaveFileDialog.DefaultExt = ".files";
            tempSaveFileDialog.Filter = "txt files (*.files)|*.files|All files (*.*)|*.*";
            tempSaveFileDialog.FilterIndex = 2;
            tempSaveFileDialog.RestoreDirectory = true;

            String tempStrSavePath = "";
            if (tempSaveFileDialog.ShowDialog() != DialogResult.OK)
            {return;            }

            tempStrSavePath = tempSaveFileDialog.FileName.ToString();
            System.IO.FileStream theFileStream = (System.IO.FileStream)tempSaveFileDialog.OpenFile();


            byte[] value0 = new System.Text.UnicodeEncoding().GetBytes(richTextBox1.Text);

            
            theFileStream.Write(value0,0,value0.Length);


            tempStrSavePath = "1234567-----";
            byte[] value1 = new System.Text.UnicodeEncoding().GetBytes(tempStrSavePath);
            theFileStream.Position = value0.Length;//设定书写的开始位置为文件的末尾  
            theFileStream.Write(value1, 0 , value1.Length);
            theFileStream.Flush();
            


            //System.Diagnostics.Debug.Print(tempStrSavePath);

        }

        private void button3_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.SaveFileDialog tempSaveFileDialog = new System.Windows.Forms.SaveFileDialog();

            tempSaveFileDialog.InitialDirectory = "D:\\";
            tempSaveFileDialog.DefaultExt = ".files";
            tempSaveFileDialog.Filter = "txt files (*.files)|*.files|All files (*.*)|*.*";
            tempSaveFileDialog.FilterIndex = 2;
            tempSaveFileDialog.RestoreDirectory = true;

            String tempStrSavePath = "";
            if (tempSaveFileDialog.ShowDialog() != DialogResult.OK)
            { return; }

            tempStrSavePath = tempSaveFileDialog.FileName.ToString();
            System.IO.FileStream theFileStream = (System.IO.FileStream)tempSaveFileDialog.OpenFile();
            ClassFileStream theClassFileStream = (ClassFileStream)theFileStream;



            String tempStr = @"cv:/df\dsdf\sdsd";
            byte[] value0 = new System.Text.UnicodeEncoding().GetBytes(richTextBox1.Text);
            byte[] value1 = new System.Text.UnicodeEncoding().GetBytes(tempStr);

            theClassFileStream.Write(richTextBox1.Text);
            theClassFileStream.Write(tempStr);
            theClassFileStream.Flush();


        }
    }
}
