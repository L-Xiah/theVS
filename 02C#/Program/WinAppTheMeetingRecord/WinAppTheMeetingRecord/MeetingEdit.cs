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
    public partial class MeetingEdit : Form
    {
        public MeetingEdit()
        {
            InitializeComponent();
        }


        //private Boolean isNew;



        private void MeetingEdit_Load(object sender, EventArgs e)
        {
            show();


        }

        private void show()
        {
            dateTimePicker1_StartTime.Value = Program.theData.thePropStartTime;
            dateTimePicker2_EndTime.Value = Program.theData.thePropEndTime;
            cbo_address.Text = Program.theData.thePropAddress;
            cbo_project.Text = Program.theData.thePropProjectname;
            cbo_type.Text = Program.theData.thePropMeetingtype;
            richTextBox1_content.Text = Program.theData.thePropContent;

            string delimStr = ";:";
            char[] delimiter = delimStr.ToCharArray();
            String tempMember = Program.theData.thePropMember;
            String[] tempStr ;
            if (tempMember != "")
            {
                tempStr = tempMember.Split(delimiter, 12);
                for (int i = 0; i < tempStr.Length - 1; i++)
                {

                }
            }



        }

        private void save()
        {
            Program.theData.thePropStartTime = dateTimePicker1_StartTime.Value;
            Program.theData.thePropEndTime = dateTimePicker2_EndTime.Value;
            Program.theData.thePropAddress = cbo_address.Text ;

            Program.theData.thePropProjectname = cbo_project.Text;
            Program.theData.thePropMeetingtype = cbo_type.Text;
            Program.theData.thePropContent = richTextBox1_content.Text;


        }

        private void 保存ToolStripMenuItem_Click(object sender, EventArgs e)
        {


            save();
            Program.theConn.SaveData(Program.theData);
            

        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
