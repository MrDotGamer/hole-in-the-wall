using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace HoleInTheWall
{
    class Patikrinimas
    {
        static void Main()
        {
            bool answer = false;
            int startPoint = 0;
            string filename = "figure.txt";

            GetFigureArray figureReader = new GetFigureArray();
            Figure figure = new Figure(figureReader.GetPinHole(filename));

            figure.Show();

            filename = "pinhole.txt";
            Figure hole = new Figure(figureReader.GetPinHole(filename));
            Console.WriteLine("========");
            hole.Show();

            ArrayUtils cutter = new ArrayUtils();

            figure.FigureArray = cutter.CutRow(figure.FigureArray);
            figure.Rotate();
            figure.FigureArray = cutter.CutRow(figure.FigureArray);

            for (int i = 0; i < 4; i++)
            {
                answer = cutter.FitFigureToHole(hole.FigureArray, figure.FigureArray);
                startPoint++;
                if (answer)
                {
                    break;
                }
                figure.Rotate();
            }
            Console.WriteLine("========");
            Console.WriteLine("Answer: " + answer);
            Console.ReadKey();
        }
    }
}
