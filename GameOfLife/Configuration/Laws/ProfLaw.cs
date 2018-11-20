using GameOfLife.Model;
using GameOfLife.Model.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Laws
{
    /**
     * Classe de strategie de fonctionnement
     * Utilise les règles du prof
     **/
    class ProfLaw : LawStrategy
    {
        public Grid Update(Grid g)
        {
            Grid newgrid = GridFactory.GetGrid(g.Size);
            for (uint i = 1; i < g.Size - 1; ++i)
                for (uint j = 1; j < g.Size - 1; ++j)
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
                        newgrid.Cells[i, j] = CellFactory.GetAlive();
                    if (nbAlive > 5 || nbAlive == 0)
                        newgrid.Cells[i, j] = CellFactory.GetDead();
                }
            return newgrid;
        }
    }
}
