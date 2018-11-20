using GameOfLife.Configuration.Laws;
using GameOfLife.Model;
using GameOfLife.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
