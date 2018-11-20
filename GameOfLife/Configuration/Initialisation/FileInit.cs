using GameOfLife.Model;
using GameOfLife.Model.Factory;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Initialisation
{
    class FileInit : InitStrategy
    {
        public Grid Init(int Size)
        {

            var fileName = "InitYanis";
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"../../Configuration/Initialisation/" + fileName + ".txt");
            string[] lines;
            lines = File.ReadAllLines(path);
            Size = 0;

            foreach (var line in lines)
            {
                Size = Size < line.Length ? line.Length : Size;
            }

            Size = Size < lines.Length ? lines.Length : Size;


            Grid g = GridFactory.GetGrid(Size);

            int i = 0, j = 0;

            for (var k = 0; k < Size; k++)
            { 
                for (var l = 0; l < Size; l++)
                {
                    char c = '0';
                    try
                    {
                        c = lines[k][l];
                        if (c == '1')
                        {
                            g.Cells[j, i] = CellFactory.GetAlive();

                        }
                        else
                        {
                            g.Cells[j, i] = CellFactory.GetDead();
                        }
                        //Console.WriteLine("bonjour");
                    }
                    catch(Exception e)
                    {
                        //Console.WriteLine("coucou");
                        g.Cells[j, i] = CellFactory.GetDead();
                    }

                    j++;
                }
                i++;
                j = 0;
            }
            return g;
        }
    }
}
