using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinAppMeetingRecord
{
    public partial class Form1 : Form
    {
        public ClassConData theConn;

        public Form1()
        {
            InitializeComponent();
            theConn = new ClassConData();

            ShowData("select * from TheMeetingRecord");
        
        }

        private void ShowData(string strConn)
        {
            dataGridView1.DataSource = theConn.SelectData(strConn);
            if (dataGridView1.Columns.Count <= 0)
            { return; }
            dataGridView1.Columns[0].Visible = false; //隐藏某列
        }
        
        private void btn_ser_Click(object sender, EventArgs e)
        {
            String strConn;
            if (txt_ser.Text == "")
            {
                strConn = "Select * from TheMeetingRecord";
            }
            else { 
                strConn = "Select * from TheMeetingRecord where projectname LIKE '%" + txt_ser.Text + "%'";
            }

            dataGridView1.DataSource = null;
            ShowData(strConn);
            

        }

        
        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            //Debug.Print (e.ToString());
            //Debug.Print ( e.GetType().ToString()); 

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.Print(e.ColumnIndex + "--col--row--" + e.RowIndex);
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Debug.Print(e.ColumnIndex + "--col--row--" + e.RowIndex);
            Debug.Print(dataGridView1.Rows[0].Cells[9].Value  + "--col--row--" + e.RowIndex);
           

            
        }

        
    }
}
