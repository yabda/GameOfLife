using GameOfLife.Configuration.Initialisation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.Factory
{
    public enum InitType
    {
        Damier,
        Random,
        Table,
        File
    }

    static class InitStrategyFactory
    {
        public static InitStrategy GetStrategy(InitType type)
        {
            switch(type)
            {
                case InitType.Damier:
                    return new DamierInit();
                case InitType.Random:
                    return new RandomInit();
                case InitType.Table:
                    return new TableInit();
                case InitType.File:
                    return new FileInit();
                default:
                    return new RandomInit();
            }
        }
    }
}
