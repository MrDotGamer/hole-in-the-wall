using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
namespace HoleInTheWall
{
    class GetFigureArray
    {
        private int lineCount = 0;
        private int longestLine = 0;
        private char[,] pinhole;

        private char[,] pinHoleArray;
        public char[,] GetPinHole(string n)     
        {
            StreamReader streamfile = null;
            string arrayline;
            FileStream file = null;
            try
            {
                file = new FileStream(n, FileMode.Open);
                streamfile = new StreamReader(file, Encoding.Default);
                lineCount = 0;
                while ((arrayline = streamfile.ReadLine()) != null)
                {
                    if (arrayline.Length > longestLine)
                    {
                        longestLine = arrayline.Length;
                    }
                    lineCount++;
                }
                streamfile.Close();
                StreamReader streamPinHole;
                GetWriteFile fileUtils = new GetWriteFile();
                streamPinHole = fileUtils.GetFile(n);
                pinhole = new char[lineCount, longestLine];
                pinHoleArray = new char[lineCount, longestLine];
                int j = 0;
                while ((arrayline = streamPinHole.ReadLine()) != null)
                {
                    for (int i = 0; i < arrayline.Length; i++)
                    {
                        pinHoleArray[j, i] = arrayline[i];
                    }
                    j++;
                }
                streamPinHole.Close();
            }
            catch (IOException exc)
            {
                Console.WriteLine("IO ERROR:\n" + exc.Message);
            }
            return pinHoleArray;

        }
    }
}
