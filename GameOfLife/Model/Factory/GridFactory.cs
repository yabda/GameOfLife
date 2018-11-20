using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.Factory
{
    static class GridFactory
    {
        public static Grid GetGrid(int size = 150)
        {
            if (size < 0)
                return new Grid();
            return new Grid(size);
        }
    }
}
