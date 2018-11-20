
using GameOfLife.Model.Factory;
using System;
using System.Collections.Generic;

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

        public override bool Equals(object obj)
        {
            var grid = obj as Grid;
            for(int i = 0; i < Size; i++)
            {
                for(int j = 0; j < Size; j++)
                {
                    if (!(Cells[i, j].Alive == grid.Cells[i, j].Alive))
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}