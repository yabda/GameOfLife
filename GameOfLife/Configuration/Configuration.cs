using GameOfLife.Configuration.Initialisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration
{
    class Configuration
    {
        public InitStrategy initStrategy { get; set; }

        public Configuration()
        {
            initStrategy = new RandomInit();
        }

    }
}
