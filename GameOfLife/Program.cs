using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using GameOfLife.View;
using GameOfLife.Configuration.Initialisation;
using GameOfLife.Model;

namespace GameOfLife
{
    static class Program
    {
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
         
        public static Grid Calculnextstep(Grid g)
        {
            Grid newgrid = new Grid(g.size);
            //penser a faire les cotés
            for (uint i = 1; i < g.size-1; ++i)
                for (uint j = 1; j < g.size-1; ++j)
                {
                    int vivant = 0;
                    if (g.Cells[i - 1, j - 1].Alive) vivant++;
                    if (g.Cells[i, j - 1].Alive) vivant++;
                    if (g.Cells[i + 1, j - 1].Alive) vivant++;
                    if (g.Cells[i - 1 , j].Alive) vivant++;
                    if (g.Cells[i + 1, j].Alive) vivant++;
                    if (g.Cells[i + 1, j + 1].Alive) vivant++;
                    if (g.Cells[i + 1, j - 1].Alive) vivant++;
                    if (g.Cells[i , j + 1].Alive) vivant++;
                       
                    if (0 < vivant && vivant < 3)
                    {
                        newgrid.Cells[i, j] = new Cell(true);
                    }
                    if( vivant > 5 || vivant == 0)
                    {
                        newgrid.Cells[i, j] = new Cell(false);

                    }
                }

            
            return newgrid;
        }


        static void Main()
        {
            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(750, 750), "LA VIE");
            app.Closed += new EventHandler(OnClose);
                
           
            //init grid
            int size = 150;
            Grid g = new Grid(size);

            g = InitStratege.Init(new TableInit(), g);


            
            //creation of drawable object
            DrawableObject matrice = Decorator.Decorate(g);
            Clock c = new Clock();

            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                if (c.ElapsedTime.AsMilliseconds() > 5)
                {
                    g = Calculnextstep(g);
                    matrice=Decorator.Decorate(g);
                    c.Restart();
                }
                
                // Clear screen
                app.Clear();

                app.Draw(matrice);
                

                // Update the window
                app.Display();
            } //End game loop
        } //End Main()
    } //End Program
}