using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Initialisation
{
    class InitStratege
    {
        public static Grid Init(InitStrategy strat, Grid g)
        {
            g = strat.Init(g);
            return g;
        }

    }
}
