﻿using GameOfLife.Configuration.Laws;
using GameOfLife.View;
using System;

namespace GameOfLife.Observer
{
    class NextStep
    {
        public void Run(object sender, EventArgs e)
        {
            Screen s = (Screen)sender;
            s.grid = LawStratege.Apply(s.grid, s.strat);
            s.matrice = Decorator.Decorate(s.grid);
        }
    }
}
