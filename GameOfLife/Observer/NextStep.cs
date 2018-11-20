using GameOfLife.Configuration.Laws;
using GameOfLife.View;
using System;

namespace GameOfLife.Observer
{
    class NextStep
    {
        public void Run(object sender, EventArgs e)
        {
            Screen s = (Screen)sender;
            s.grid = LawStratege.Apply(s.grid, Screen.conf.LawStrategy);
            s.matrice = Decorator.Decorate(s.grid, Screen.conf.pixelSize);
        }
    }
}
