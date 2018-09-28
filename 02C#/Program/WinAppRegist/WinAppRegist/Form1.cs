using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Win32;

namespace WinAppRegist
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

            RegistryKey keyMain = Registry.LocalMachine;
            RegistryKey hkSoftWare = keyMain.OpenSubKey(@"SOFTWARE\xiah0089", true);

            if (hkSoftWare == null)
            {
                hkSoftWare = keyMain.CreateSubKey(@"SOFTWARE\xiah0089");
                //return;
            }

            double dVer = 1.12;
            double dReg = -1 ;
            if (hkSoftWare.GetValue("theName") == null)
            {
                hkSoftWare.SetValue("theName", dVer, RegistryValueKind.String);
            }
            else
            {
                String theValue = hkSoftWare.GetValue("theName").ToString();
                dReg = double.Parse(theValue);
    
            }

            this.Text = "注册表--" + dReg;
            


            hkSoftWare.Close();
            keyMain.Close();



        }
    }
}
