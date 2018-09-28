using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinGetFileNames
{
    class ClassGetFile
    {

        public ClassGetFile()
        {
            theFullName = new List<string>();
            theName = new List<string>();
            theExtension = new List<string>();
            theFileName = new List<string>();
            theCount = 0;
         }


        private int theCount;
        public int theIntCount
        {
            get { return theCount; }
            //set { theCount = value; }
        }

        private List<String> theFullName;
        public List<String> theStrFullName 
        {
            get { return theFullName; }
            //set { }
        }

        private List<String> theName;
        public List<String> theStrName
        { get { return theName; } }

        private List<String> theExtension;
        public List<String> theStrExtension
        { get { return theExtension; } }

        private List<String> theFileName;
        public List<String> theStrFileName
        { get { return theFileName; } }


        public void ListClear()
        {
            theCount = 0;
            theFullName.Clear();
            theName.Clear();
            theExtension.Clear();
            theFileName.Clear();
        }

        public void GetFileName(DirectoryInfo theDir , String pattern = "*" ,int theFullNameIs = 0)
        {
            if (theDir.Exists == false)
            {  return;         }


            FileInfo[] fileS = theDir.GetFiles(pattern);
            String tempStrAAA = "";
            foreach (FileInfo fileT in fileS)
            {
                theFullName.Add(fileT.FullName);
                theName.Add(fileT.Name);
                theExtension.Add(fileT.Extension);
                tempStrAAA = fileT.Name;
                tempStrAAA = tempStrAAA.Replace(fileT.Extension,"");
                theFileName.Add(tempStrAAA);
                theCount = theCount + 1;

            }

            DirectoryInfo[] dirS = theDir.GetDirectories();

            foreach (DirectoryInfo dirT in dirS)
            {
                GetFileName(dirT,pattern,theFullNameIs);
            }


        }
    }
}
