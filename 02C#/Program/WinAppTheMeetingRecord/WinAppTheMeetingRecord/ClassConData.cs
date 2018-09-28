using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheClass
{
    public class ClassConData
    {
        private OleDbConnection conn;
        private OleDbCommand cmd;
        private DataTable thedt;

        public ClassConData()
        {
            conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\12Other\\Databases\\MeetingRecord.accdb"); //Jet OLEDB:Database Password=
            
            thedt = new DataTable();
        }

        public DataTable SelectData( string strCon)
        {
            cmd = conn.CreateCommand();

            cmd.CommandText = strCon;// "select * from TheMeetingRecord";
            conn.Open();
            OleDbDataReader dr = cmd.ExecuteReader();

           
            thedt.Clear();
            thedt.Dispose();
            if (thedt.Columns.Count > 0)
            {
                int nCount = thedt.Columns.Count ;
                for (int i = 0; i < nCount; i++)
                {
                    Debug.Print(thedt.Columns[0].ColumnName);
                    thedt.Columns.RemoveAt(0);
                }

                

            }
            

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            
            if (dr.HasRows)
            {
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    thedt.Columns.Add(dr.GetName(i));
                }
                thedt.Rows.Clear();
            }
            while (dr.Read())
            {
                DataRow row = thedt.NewRow();
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    row[i] = dr[i];

                }
                thedt.Rows.Add(row);
            }
            cmd.Dispose();
            conn.Close();
            return thedt;
        }


        public Boolean SaveData(ClassData theData)
        {
            String connStr = "";
            if ( theData.thePropID <= 0)
            { connStr = "" ;
            return false;
            }
            else
            { connStr = "UPDATE TheMeetingRecord SET "; }

            connStr = connStr + "starttime = '" + theData.thePropStartTime.ToString() + "', ";
            connStr = connStr + "endtime = '" + theData.thePropEndTime.ToString() + "', ";

            connStr = connStr + "address = '" + theData.thePropAddress + "', ";
            connStr = connStr + "projectname = '" + theData.thePropProjectname + "', ";

            connStr = connStr + "meetingtype = '" + theData.thePropMeetingtype + "', ";
            connStr = connStr + "content = '" + theData.thePropContent + "', ";

            connStr = connStr + "member = '" + theData.thePropMember + "', ";
            connStr = connStr + "other = '" + theData.thePropOther + "', ";

            connStr = connStr + "comment = '" + theData.thePropComment + "', ";
            connStr = connStr + "containfile = " + theData.thePropContainfile + ", ";

            connStr = connStr + "tname = '" + theData.thePropTname + "' ";
            connStr = connStr + "where ID = " + theData.thePropID ;


            cmd = conn.CreateCommand();

            cmd.CommandText = connStr;// "select * from TheMeetingRecord";
            conn.Open();
            cmd.ExecuteNonQuery();

            cmd.Dispose();
            conn.Close();

            return true;
        }




        ~ClassConData()
        {
            cmd.Dispose();
            conn.Close();
        }


    }
}
