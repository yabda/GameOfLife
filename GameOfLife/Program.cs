using System;
using SFML.Graphics;
using SFML.Window;

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
            RenderWindow app = new RenderWindow(new VideoMode(800, 600), "SFML Works!");
            app.Closed += new EventHandler(OnClose);

            //init grid
            int size = 150;
            Grid g = new Grid(size);
            g = InitStratege.Init(0, g);

            
            /*Print grid */
            for(int i = 0; i < size; i++)
            {
                for (int j = 0; j < size; j++)
                {
                    String value = g.Cells[i, j].Alive ? "1" : "0";
                    Console.Write(value+"  ");
                }
                Console.WriteLine("");
            }


            Color windowColor = new Color(0, 255, 0);
            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                // Clear screen
                app.Clear(windowColor);

                // Update the window
                app.Display();
            } //End game loop
        } //End Main()
    } //End Program
}