using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Laws
{
    class ProfLaw:LawStrategy
    {
        public Grid Update(Grid g)
        {
            Grid newgrid = new Grid(g.size);
            //penser a faire les cotés
            for (uint i = 1; i < g.size - 1; ++i)
                for (uint j = 1; j < g.size - 1; ++j)
                {
                    int nbAlive = 0;
                    if (g.Cells[i - 1, j - 1].Alive) nbAlive++;
                    if (g.Cells[i - 1, j].Alive) nbAlive++;
                    if (g.Cells[i - 1, j + 1].Alive) nbAlive++;
                    if (g.Cells[i, j - 1].Alive) nbAlive++;
                    if (g.Cells[i, j + 1].Alive) nbAlive++;
                    if (g.Cells[i + 1, j - 1].Alive) nbAlive++;
                    if (g.Cells[i + 1, j].Alive) nbAlive++;
                    if (g.Cells[i + 1, j + 1].Alive) nbAlive++;

                    if (0 < nbAlive && nbAlive < 3)
                    {
                        newgrid.Cells[i, j] = new Cell(true);
                    }
                    if (nbAlive > 5 || nbAlive == 0)
                    {
                        newgrid.Cells[i, j] = new Cell(false);

                    }
                }


            return newgrid;
        }
    }
}
