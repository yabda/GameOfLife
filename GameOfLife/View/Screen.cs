using GameOfLife.Configuration.Initialisation;
using GameOfLife.Configuration.Laws;
using GameOfLife.Model;
using GameOfLife.Model.Factory;
using GameOfLife.Observer;
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
        public Grid grid { get; set; }
        public LawStrategy strat { get; set; }
        int Speed;
        static event EventHandler Observable;
        public DrawableObject matrice { get; set; }


        public void Init(Configuration.Configuration conf)
        {
            App = new RenderWindow(new VideoMode(750, 750), "LA VIE");
            App.Closed += new EventHandler(OnClose);

            grid = GridFactory.GetGrid(conf.Size);
            grid = InitStratege.Init(conf.InitStrategy,grid);
            this.strat = conf.LawStrategy;
            this.Speed = conf.Speed;

            var next = new NextStep();
            Observable += new EventHandler(next.Run);
        }
        
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public void Run()
        {

            Clock c = new Clock();
            matrice = Decorator.Decorate(grid);

            while (App.IsOpen)
            {
                // Process events
                App.DispatchEvents();

                if (c.ElapsedTime.AsMilliseconds() > 1/Speed)
                {
                    Observable(this, new TickEvent());
                    c.Restart();
                }

                App.Clear();

                App.Draw(matrice);
                App.Display();
            } 
        }
    }
}
