using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinQrCode
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ClassQrCode.Generate3();
            ClassQrCode.Generate4();
            ClassQrCode.Generate5();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = ClassQrCode.Generate1("www.baidu.com");
            ClassQrCode.Generate2("www.baidu.com");
        }


        private void button3_Click(object sender, EventArgs e)
        {
            ClassZxing.Generate("");
        }
    }
}
