using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheClass
{
   public class ClassData
    {
        public ClassData()
        { }

        public void Clear()
        {
            theID = int.MinValue;
            theStartTime = DateTime.MinValue;
            theEndTime = DateTime.MinValue;
            theAddress = null;
            theProjectname = null;
            theMeetingtype = null;
            theContent = null;
            theMember = null;

            theOther = null;
            theComment = null;
            theContainfile = false ;
            theTname = null;
        }

        public Boolean Data(System.Windows.Forms.DataGridViewRow param)
        {

            //System.Diagnostics.Debug.Print("--param.longlength---" + param.LongLength.ToString());
            int i = 0;
            if (param.Cells[i].Value.ToString() == "")
            { theID = int.MinValue; }
            else
            { theID = int.Parse(param.Cells[i].Value.ToString()); }
            i += 1;

            if (param.Cells[i].Value.ToString() == "")
            { theStartTime = DateTime.MinValue; }
            else
            { theStartTime = DateTime.Parse(param.Cells[i].Value.ToString()); }
            i += 1;

            if (param.Cells[i].Value.ToString() == "")
            { theEndTime = DateTime.MinValue; }
            else
            { theEndTime = DateTime.Parse(param.Cells[i].Value.ToString()); }
            i += 1;


            if (param.Cells[i].Value.ToString() != "")
            { theAddress = (String)param.Cells[i].Value; }
            i += 1;
            if (param.Cells[i].Value.ToString() != "")
            { theProjectname = (String)param.Cells[i].Value; }
            i += 1;
            if (param.Cells[i].Value.ToString() != "")
            { theMeetingtype = (String)param.Cells[i].Value; }
            i += 1;

            if (param.Cells[i].Value.ToString() != "")
            { theContent = (String)param.Cells[i].Value; }
            i += 1;
            if (param.Cells[i].Value.ToString() != "")
            { theMember = (String)param.Cells[i].Value; }
            i += 1;
            if (param.Cells[i].Value.ToString() != "")
            { theOther = (String)param.Cells[i].Value; }
            i += 1;

            if (param.Cells[i].Value.ToString() != "")
            { theComment = (String)param.Cells[i].Value; }
            i += 1;
            if (param.Cells[i].Value.ToString().ToUpper() == "TRUE")
            { theContainfile = true; }
            i += 1;
            if (param.Cells[i].Value.ToString() != "")
            { theTname = (String)param.Cells[i].Value; }
            i += 1;

            return true;
        }



        private int theID;
        public int thePropID
        {
            get { return theID; }
            set { theID = value; }
        }

        private DateTime theStartTime;
        public DateTime thePropStartTime
        {
            get { return theStartTime; }
            set { theStartTime = value; }
        }

        private DateTime theEndTime;
        public DateTime thePropEndTime
        {
            get { return theEndTime; }
            set { theEndTime = value; }
        }

        private String theAddress;
        public String thePropAddress
        {
            get { return theAddress; }
            set { theAddress = value; }
        }

        private String theProjectname;
        public String thePropProjectname
        {
            get { return theProjectname; }
            set { theProjectname = value;}
        }

        private String theMeetingtype;
        public String thePropMeetingtype
        {
            get { return theMeetingtype; }
            set { theMeetingtype = value; }
        }

        private String theContent;
        public String thePropContent
        {
            get { return theContent; }
            set { theContent = value; }
        }

        private String theMember;
        public String thePropMember
        {
            get { return theMember; }
            set { theMember = value; }
        }

        private String theOther;
        public String thePropOther
        {
            get { return theOther; }
            set { theOther = value; }
        }

        private String theComment;
        public String thePropComment
        {
            get { return theComment; }
            set { theComment = value; }
        }

        private Boolean theContainfile;
        public Boolean thePropContainfile
        {
            get { return theContainfile; }
            set { theContainfile = value; }
        }

        private String theTname;
        public String thePropTname
        {
            get { return theTname; }
            set { theTname = value; }
        }

    }
}
