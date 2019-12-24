using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HoleInTheWall
{
    class Figure
    {
        public Figure (char[,] figureArray)
        {
            this.figureArray = figureArray;
        }

        private char[,] figureArray;

        public char[,] FigureArray { get => figureArray; set => figureArray = value; }
    
        public void Show()
        {
            if (figureArray != null)
            {
                for (int y = 0; y < figureArray.GetLength(0); ++y)
                {
                    for (int i = 0; i < figureArray.GetLength(1); ++i)
                    {
                        Console.Write(figureArray[y, i]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                throw new Exception("File Not Found");
            }
        }

        public void Rotate()
        {
            int i, z, j, k;
            char[,] y = new char[figureArray.GetLength(1), figureArray.GetLength(0)];
            for (j = 0, z = figureArray.GetLength(0) - 1; j < figureArray.GetLength(0); z--, j++)
            {
                for (i = 0, k = 0; i < figureArray.GetLength(1); k++, i++)
                {
                    y[k, z] = figureArray[j, i];
                }
            }
            figureArray = y;
        }
    }
}

