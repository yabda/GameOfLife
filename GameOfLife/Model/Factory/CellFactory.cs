using System;

namespace GameOfLife.Model.Factory
{
    static class CellFactory
    {
        public static Cell GetAlive()
        {
            return new Cell(true);
        }

        public static Cell GetDead()
        {
            return new Cell(false);
        }

        public static Cell RandomCell(int percentDead = 50)
        {
            if (percentDead >= 100)
                return new Cell(false);
            if (percentDead <= 0)
                return new Cell(true);
            Random m = new Random();
            if (m.Next(0, 100) > percentDead)
                return new Cell(true);
            return new Cell(false);
        }

        public static Cell GetCell()
        {
            return RandomCell();
        }
    }
}
