using GameOfLife.Configuration.Laws;
using GameOfLife.Model;
using GameOfLife.View;
using System;

namespace GameOfLife.Observer
{
    class NextStep
    {
        public void Run(object sender, EventArgs e)
        {
            Screen s = (Screen)sender;
            Grid backupGrid = s.grid;
            if (s.previousGrid == null)
                s.previousGrid = backupGrid;

            s.grid = LawStratege.Apply(s.grid, Screen.conf.LawStrategy);
            
            if(s.grid.Equals(backupGrid) || s.previousGrid.Equals(s.grid))
            {
                s.Over = true;
            }
            s.previousGrid = backupGrid;
            s.matrice = Decorator.Decorate(s.grid, Screen.conf.pixelSize);
        }
    }
}
