using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Initialisation
{
    class DamierInit:InitStrategy
    {
        public Grid Init(Grid g) {
            
            for (int i = 0; i < 150; i++)
            {
                for (int j = 0; j < 150; j++)
                {
                    if (j % 2 == 0 && i % 2 ==0)
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
