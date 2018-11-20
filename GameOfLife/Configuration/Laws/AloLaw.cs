using GameOfLife.Model;
using GameOfLife.Model.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Laws
{
    class AloLaw:LawStrategy
    {

        public Grid Update(Grid g)
        {
            Grid newgrid = GridFactory.GetGrid(g.Size);
            //penser a faire les cotés :)
            for (uint i = 1; i < g.Size - 1; ++i)
                for (uint j = 1; j < g.Size - 1; ++j)
                {
                    
                    int nbAlive = 0;
                    if (i != 0 && i != g.Size && j != 0 && j != g.Size)
                    {
                        if (g.Cells[i - 1, j - 1].Alive) nbAlive++; // check uppperLeft
                        if (g.Cells[i, j - 1].Alive) nbAlive++;
                        if (g.Cells[i + 1, j - 1].Alive) nbAlive++;
                        if (g.Cells[i - 1, j].Alive) nbAlive++;
                        if (g.Cells[i + 1, j].Alive) nbAlive++;
                        if (g.Cells[i + 1, j + 1].Alive) nbAlive++;
                        if (g.Cells[i + 1, j - 1].Alive) nbAlive++;
                        if (g.Cells[i, j + 1].Alive) nbAlive++;
                    }
                    if (g.Cells[i, j].Alive){
                        if (nbAlive<2 || nbAlive>3)
                        {
                            newgrid.Cells[i, j] = CellFactory.GetDead();
                        }
                        else
                        {
                            newgrid.Cells[i, j] = CellFactory.GetAlive();

                        }
                    }
                    else
                    {
                        if (nbAlive == 3)
                        {
                            newgrid.Cells[i, j] = CellFactory.GetAlive();
                        }
                    }
                }
            return newgrid;
        }
    }
}
