using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace WinGetFileNames
{
    class ClassFileStream :FileStream
    {

        private static FileMode theBase(String funcPath)
        {
            FileMode tempFileMode;
            if (File.Exists(funcPath) == true)
            { tempFileMode = FileMode.Open; }
            else
            { tempFileMode = FileMode.Create; }
            return tempFileMode;
        }

        public ClassFileStream(String funcPath)
            :base(funcPath,theBase(funcPath))
        {
        
        }


        //public ClassFileStream(FileStream funcFileStream)
            
        //{
        //    theFileStream = funcFileStream;
        //}

        //private FileStream theFileStream;



        public void Write(String funcStr)
        {

            byte[] value0 = new System.Text.UnicodeEncoding().GetBytes(funcStr);

            base.Position = base.Length;

            base.Write(value0, 0, value0.Length);

        }

        



    }
}
