using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Initialisation
{
    class RandomInit:InitStrategy
    {
        public Grid Init(Grid g)
        {
            Random rand = new Random();
            int size = g.Cells.GetLength(1);

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (rand.Next(0, 99) <=2)
                    {
                        g.Cells[i, j] = new Cell(true);
                    }
                    else
                    {
                        g.Cells[i, j] = new Cell(false);
                    }
                }
            }
            return g;
        }

    }
}
