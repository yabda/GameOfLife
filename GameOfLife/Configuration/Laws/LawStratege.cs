﻿using GameOfLife.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration.Laws
{
    /**
     * Classe du Stratège de fonctionnement
     * Applique l'update selon la stratégie passée en paramètre
     **/
    class LawStratege
    {
        public static Grid Apply(Grid g, LawStrategy strat)
        {
            return g = strat.Update(g);
        }
    }
}
