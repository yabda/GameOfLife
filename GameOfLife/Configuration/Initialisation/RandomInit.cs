using GameOfLife.Model;
using GameOfLife.Model.Factory;
using System;

namespace GameOfLife.Configuration.Initialisation
{
    /**
     * Classe de strategie d'initialisation
     * Renvoit une grille aléatoire
     **/
    class RandomInit : InitStrategy
    {
        public Grid Init(Grid g)
        {
            Random rand = new Random();

            for (int i = 0; i < g.Size; i++)
                for (int j = 0; j < g.Size; j++)
                {
                    if (rand.Next(0, 99) <= rand.Next(0, 99))
                        g.Cells[i, j] = CellFactory.GetAlive();
                    else
                        g.Cells[i, j] = CellFactory.GetDead();
                }
            return g;
        }

    }
}
