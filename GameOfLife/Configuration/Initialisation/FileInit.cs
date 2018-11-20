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
        public Grid Init(Grid g)
        {
            var fileName = "InitFull";
            var path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"../../Configuration/Initialisation/"+fileName+".txt");
            string[] lines; lines = File.ReadAllLines(path);
            int i = 0, j = 0;

            foreach (var line in lines)
            {
                for (var k = 0; k < line.Length; k++)
                {
                    char c = line[k];
                    if (c == '1')
                    {
                        g.Cells[j, i] = CellFactory.GetAlive();

                    }
                    else
                    {
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
