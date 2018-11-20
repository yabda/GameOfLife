using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using GameOfLife.View;
using GameOfLife.Configuration.Initialisation;
using GameOfLife.Model;
using GameOfLife.Configuration.Laws;

namespace GameOfLife
{
    static class Program
    {
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }
         
        


        static void Main()
        {
            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(750, 750), "LA VIE");
            app.Closed += new EventHandler(OnClose);
                
           
            //init grid
            int size = 150;
            Grid g = new Grid(size);

            g = InitStratege.Init(new RandomInit(), g);


            
            //creation of drawable object
            DrawableObject matrice = Decorator.Decorate(g);
            Clock c = new Clock();

            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                if (c.ElapsedTime.AsMilliseconds() > 100)
                {
                    g = LawStratege.Apply(g, new ConwayLaw());
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