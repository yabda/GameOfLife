using GameOfLife.Model;
using GameOfLife.Model.Factory;

namespace GameOfLife.Configuration.Initialisation
{
    /**
     * Classe de strategie d'initialisation
     * Renvoit une grille initialisée avec une table
     **/
    class TableInit : InitStrategy
    {
        public Grid Init(Grid g)
        {
            for (int i = 0; i < g.Size; i++)
                for (int j = 0; j < g.Size; j++)
                {
                    if (j % 6 == 0 || i % 6 == 0)
                        g.Cells[i, j] = CellFactory.GetAlive();
                    else
                        g.Cells[i, j] = CellFactory.GetDead();
                }
            return g;
        }

    }
}
