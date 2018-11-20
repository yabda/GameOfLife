using GameOfLife.Configuration.Initialisation;
using GameOfLife.Configuration.Laws;
using GameOfLife.Model.Factory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration
{
    class Configuration
    {
        public InitStrategy InitStrategy { get; set; }
        public LawStrategy LawStrategy { get; set; }
        public int Size { get; set; }
        public int Speed { get; set; }

        public Configuration()
        {
            InitStrategy = InitStrategyFactory.GetStrategy(InitType.Random);
            LawStrategy = LawStrategyFactory.GetStrategy(LawType.Conway);
            Size = 250;
            Speed = 15;
        }

    }
}
