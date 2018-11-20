
using GameOfLife.Model.Factory;
using System;

namespace GameOfLife.Model
{
    class Grid : IGrid
    {
        public Cell[,] Cells { get; set; }
        public int Size { get; set; }

        public Grid(int size)
        {
            Cells = new Cell[size, size];
            this.Size = size;
            for (uint i = 0; i < size; ++i)
                for (uint j = 0; j < size; ++j)
                    Cells[i, j] = CellFactory.GetDead();
        }

        public Grid() : this(150)
        {}
    }
}