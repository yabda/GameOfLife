using GameOfLife.Configuration.Initialisation;
using GameOfLife.Configuration.Laws;
using GameOfLife.Model;
using GameOfLife.Model.Factory;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.View
{
   class Screen
    {
        private RenderWindow App;
        Grid g;
        LawStrategy strat;
        int Speed;

        public void Init(Configuration.Configuration conf)
        {
            App = new RenderWindow(new VideoMode(750, 750), "LA VIE");
            App.Closed += new EventHandler(OnClose);

            g = GridFactory.GetGrid(conf.Size);
            g = InitStratege.Init(conf.InitStrategy,g);
            this.strat = conf.LawStrategy;
            this.Speed = conf.Speed;
        }
        
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public void Run()
        {

            Clock c = new Clock();
            DrawableObject matrice = Decorator.Decorate(g);

            while (App.IsOpen)
            {
                // Process events
                App.DispatchEvents();

                if (c.ElapsedTime.AsMilliseconds() > Speed)
                {
                    g = LawStratege.Apply(g,strat);
                    matrice = Decorator.Decorate(g);
                    c.Restart();
                }

                // Clear screen
                App.Clear();

                App.Draw(matrice);
                // Update the window
                App.Display();
            } //End game loop
        }

    }
}
