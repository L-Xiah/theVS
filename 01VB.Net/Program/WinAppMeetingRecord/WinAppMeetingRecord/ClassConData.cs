using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Data;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinAppMeetingRecord
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



        ~ClassConData()
        {
            cmd.Dispose();
            conn.Close();
        }


    }
}
