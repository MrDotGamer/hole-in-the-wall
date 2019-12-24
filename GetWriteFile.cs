using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HoleInTheWall
{
    class GetWriteFile
    {
        public StreamReader GetFile(string s)
        {
            FileStream file = null;
            try

            { file = new FileStream(s, FileMode.Open); }
            catch (IOException exc)
            {
                Console.WriteLine("IO ERROR:\n" + exc.Message);
            }
            StreamReader streamfile = new StreamReader(file, Encoding.Default);
            return streamfile;
        }


        public StreamWriter WriteFile(string s)
        {
            FileStream file = null;
            
            try
            {
                file = new FileStream(s, FileMode.OpenOrCreate);

            }
            catch (IOException exc)
            {
                Console.WriteLine("IO ERROR:\n" + exc.Message);
            }
            StreamWriter streamfile = new StreamWriter(file, Encoding.Default);
            return streamfile;
        }
    }
}
