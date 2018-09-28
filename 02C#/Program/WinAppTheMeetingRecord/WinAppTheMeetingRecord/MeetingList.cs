using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinAppTheMeetingRecord
{
    public partial class MeetingList : Form
    {
        public MeetingList()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WinAppTheMeetingRecord.Program.theConn = new TheClass.ClassConData();
            
            
            ShowData("select * from TheMeetingRecord");
        }

        private void ShowData(string strConn)
        {
            dataGridView1.DataSource =Program.theConn.SelectData(strConn);
            if (dataGridView1.Columns.Count <= 0)
            { return; }
            dataGridView1.ReadOnly = true;
            dataGridView1.Columns[0].Visible = false; //隐藏某列

            //System.Diagnostics.Debug.Print(dataGridView1.Columns[1].DataPropertyName);
            //System.Diagnostics.Debug.Print(dataGridView1.Columns[1].Name);

            //dataGridView1.Columns[1].DataPropertyName = "开始时间";
            int i = 1;
            dataGridView1.Columns[i].HeaderCell.Value = "开始时间"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "结束时间"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "会议地点"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "项目"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "会议类型"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "内容"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "与会人员"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "其它"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "备注"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "附件"; i += 1;
            dataGridView1.Columns[i].HeaderCell.Value = "记录人"; i += 1;
        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(e.RowIndex <0)
            { return; }
            MeetingEdit theTempEdit = new MeetingEdit( );

            this.Hide();

            //System.Diagnostics.Debug.Print(dataGridView1.Rows[0].Cells[0].Value.ToString());
            //System.Diagnostics.Debug.Print("-----------------"  + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            Program.theData.Data(dataGridView1.Rows[e.RowIndex]);

            // System.Diagnostics.Debug.Print(dataGridView1.Columns[e.RowIndex].ToString);
           // dataGridView1.Rows[0].Cells[0].;
            theTempEdit.ShowDialog();

            this.Show();
           // DataGridViewRow then;
           

        }


       
        
        
    }
}
