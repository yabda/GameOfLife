using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Initialisation
{
    interface InitStrategy
    {
        Grid Init(Grid g);

    }
}
