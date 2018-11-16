
using System;

namespace GameOfLife
{
    class Grid
    {
               
        public Cell[,] Cells { get; set; }
        private int size;

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

        }
    }
}