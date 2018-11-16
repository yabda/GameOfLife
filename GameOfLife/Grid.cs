
using System;

namespace GameOfLife
{
    class Grid
    {
               
        public Cell[,] Cells { get; set; }
        public int size { get; set; }

        public Grid(int size)
        {
            Cells = new Cell[size, size];
            this.size = size;
        }

        public Grid()
        {
            Cells = new Cell[150, 150];
            this.size = 150;
        }


        /*Initialise la grille avec {proba}% de chance pour que chaque cellule soit en vie*/
        public void InitRandom(int proba)
        {
            Random rand = new Random();

            for (int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    if (rand.Next(0, 99) <= proba-1)
                    {
                        Cells[i, j] = new Cell(true);
                    }
                    else
                    {
                        Cells[i, j] = new Cell(false);
                    }

                }
            }
        }
    }
}