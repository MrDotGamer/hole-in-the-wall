using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;


namespace HoleInTheWall
{
    class ArrayUtils
    {
        char emptyChar = '0';
        private char[] GetRow(char[,] figure, int rowNumber)
        {
            if (rowNumber > figure.GetLength(0))
                return null;
            else
            {
                char[] result = new char[figure.GetLength(1)];
                for (int i = 0; i < figure.GetLength(1); i++)
                {
                    result[i] = figure[rowNumber, i];
                }
                return result;
            }
        }
        static Boolean HasChar(char[] array, char symbol)
        {
            Boolean result = false;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] != symbol)
                {

                    result = false;
                    return result;
                }
                else
                    result = true;
            }
            return result;
        }
        static char[,] GetArray(char[,] figure)
        {
            char[,] temp = new char[figure.GetLength(0), figure.GetLength(1)];
            for (int i = 0; i < figure.GetLength(0); i++)
            {
                for (int j = 0; j < figure.GetLength(1); j++)
                {
                    temp[i, j] = figure[i, j];
                }
            }
            return temp;
        }
        public char[,] CutRow(char[,] temp)
        {
            Boolean hasEmptyRow = true;
            while (hasEmptyRow)
            {
                for (int i = 0; i < temp.GetLength(0); i++)
                {
                    char[] s = GetRow(temp, i);
                    string charsStr = new string(s);
                    if (HasChar(s, emptyChar))
                    {
                        temp = RemoveRow(temp, i);
                        i--;
                    }
                }
                hasEmptyRow = false;
            }
            return temp;
        }
        public bool FitFigureToHole(char[,] hole, char[,] figure)
        {
            if (hole.GetLength(0) >= figure.GetLength(0) && hole.GetLength(1) >= figure.GetLength(1))
            {
                for (int j = 0; j < hole.GetLength(0) - figure.GetLength(0); j++)
                {
                    for (int i = 0; i < hole.GetLength(1) - figure.GetLength(1); i++)
                    {
                        if (CompareMatrix(hole, figure, j, i))
                            return true;
                    }
                }
            }
                return false;
        }

        private bool CompareMatrix(char[,] hole, char[,] figure, int startx, int starty)
        {
                for (int j = 0; j < figure.GetLength(0); j++)
                {
                    for (int i = 0; i < figure.GetLength(1); i++)
                    {
                        if ((figure[j, i] != emptyChar) && (hole[startx + j, starty + i] != emptyChar))
                        {
                             return false;
                        }
                    }
                }
                return true;
        }

        private char[,] RemoveRow(char[,] c, int deleteRow)
        {
            char[,] temp = new char[c.GetLength(0) - 1, c.GetLength(1)];
            int index = 0;
            for (int i = 0; i < c.GetLength(0); i++)
            {
                if (i == deleteRow)
                {
                    continue;
                }
                else
                {
                    for (int j = 0; j < c.GetLength(1); j++)
                    {
                        temp[index, j] = c[i, j];
                    }
                    index++;
                }
            }
            return temp;
        }
    }
}
