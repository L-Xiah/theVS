using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Management;


namespace WindowsFormsApplication1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //连接MySql数据库；
            string MyconectionString = "server = localhost; user id = root; password = 753951; database = sakila";
            MySqlConnection connection = new MySqlConnection(MyconectionString);
            connection.Open();

            try
            {
                MySqlCommand cmd = connection.CreateCommand();
                cmd.CommandText = "Select * from sakila.actor limit 50";
                MySqlDataAdapter adap = new MySqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                adap.Fill(ds);
                dataGridView1.DataSource = ds.Tables[0].DefaultView;
            }
            catch (Exception)
            { throw; }
            finally
            {
                if (connection.State == ConnectionState.Open)
                { connection.Close(); }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            //ManagementObject disk = new ManagementObject("");

            String HDid;
            ManagementClass cimobject = new ManagementClass("Win32_DiskDrive");
            ManagementObjectCollection moc = cimobject.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                HDid = (string)mo.Properties["Model"].Value;
                MessageBox.Show(HDid);
            }


            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");//"SELECT * FROM Win32_DiskDrive"\"SELECT * FROM Win32_PhysicalMedia"
                String strHardDiskID = null;
                foreach (ManagementObject mo in searcher.Get())
                {
                    strHardDiskID = mo["PNPDeviceID"].ToString().Trim();//PNPDeviceID、SerialNumber
                    MessageBox.Show(strHardDiskID);
                    //break;
                }
            }
            catch
            {
                return;
            }





        }



        private List<string> _serialNumber = new List<string>();
        /// <summary>
        /// 调用这个函数将本机所有U盘序列号存储到_serialNumber中
        /// </summary>
        private void matchDriveLetterWithSerial()
        {
            string[] diskArray;
            string driveNumber;
            var searcher = new ManagementObjectSearcher("SELECT * FROM Win32_LogicalDiskToPartition");
            foreach (ManagementObject dm in searcher.Get())
            {
                getValueInQuotes(dm["Dependent"].ToString());
                diskArray = getValueInQuotes(dm["Antecedent"].ToString()).Split(',');
                driveNumber = diskArray[0].Remove(0, 6).Trim();
                var disks = new ManagementObjectSearcher("SELECT * FROM Win32_DiskDrive");
                foreach (ManagementObject disk in disks.Get())
                {
                    if (disk["Name"].ToString() == ("\\\\.\\PHYSICALDRIVE" + driveNumber) & disk["InterfaceType"].ToString() == "USB")
                    {
                        _serialNumber.Add(parseSerialFromDeviceID(disk["PNPDeviceID"].ToString()));
                    }
                }
            }
        }
        private static string parseSerialFromDeviceID(string deviceId)
        {
            var splitDeviceId = deviceId.Split('\\');
            var arrayLen = splitDeviceId.Length - 1;
            var serialArray = splitDeviceId[arrayLen].Split('&');
            var serial = serialArray[0];
            return serial;
        }

        private static string getValueInQuotes(string inValue)
        {
            var posFoundStart = inValue.IndexOf("\"");
            var posFoundEnd = inValue.IndexOf("\"", posFoundStart + 1);
            var parsedValue = inValue.Substring(posFoundStart + 1, (posFoundEnd - posFoundStart) - 1);
            return parsedValue;
        }




        private void button3_Click(object sender, EventArgs e)
        {
            matchDriveLetterWithSerial();
            string[] aa = _serialNumber.ToArray();

            for (int i = 0; i < aa.Length; i++)
            {
                MessageBox.Show(aa[i].ToString());
                aa[i].ToString();  //这里就可以拿出现在所有的U盘序列号
            }




        }







    }
}
