﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class InitStratege
    {
        public static Grid Init(int stratID, Grid g)
        {
            InitStrategy strategy = null;
            
            if(stratID == 0)  //random
            {
                strategy = new RandomInit();
               
            }
            if(stratID == 1)
            {
                strategy = new DamierInit();
            }
            if (stratID == 2)
            {
                strategy = new TableInit();
            }
            else //default
            {
                strategy = new RandomInit();
            }


            g = strategy.Init(g);
            return g;
        }

    }
}
