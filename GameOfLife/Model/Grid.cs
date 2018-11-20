
using System;

namespace GameOfLife.Model
{
    class Grid
    {
               
        public Cell[,] Cells { get; set; }
        public int size { get; set; }

        public Grid(int size)
        {
            Cells = new Cell[size, size];
            this.size = size;
            for (uint i = 0; i < size; ++i)
                for (uint j = 0; j < size; ++j)
                {
                    Cells[i, j] = new Cell();
                }
        }

        public Grid()
        {
            Cells = new Cell[150, 150];
            size = 150;
        }


        /*Initialise la grille avec {proba}% de chance pour que chaque cellule soit en vie*/
        public void InitRandom(int proba)
        {

        }
    }
}