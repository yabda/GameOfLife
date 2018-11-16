using System;
using SFML.Graphics;
using SFML.Window;
using SFML;
using SFML.System;

namespace SFML_Test
{
    static class Program
    {
        static void OnClose(object sender, EventArgs e)
        {
            // Close the window when OnClose event is received
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void Main()
        {
            // Create the main window
            RenderWindow app = new RenderWindow(new VideoMode(750, 750), "SFML Works!");
            app.Closed += new EventHandler(OnClose);
            uint width = 150;
            uint height = 150;
            int sizePixel = 5;
            Color windowColor = new Color(0, 150, 150);
            VertexArray matrice = new VertexArray(PrimitiveType.Quads, 4* width * height);


            for (uint i = 0; i < width; ++i)
                for (uint j = 0; j < width; ++j)
                {
                    // on récupère le numéro de tuile courant
                    Vertex v = matrice[0];


                    // on récupère un pointeur vers le quad à définir dans le tableau de vertex
                    Vertex v0 = matrice[(i + j * width) * 4];
                    Vertex v1 = matrice[(i + j * width) * 4 + 1];
                    Vertex v2 = matrice[(i + j * width) * 4 + 2];
                    Vertex v3 = matrice[(i + j * width) * 4 + 3];

                    // on définit ses quatre coins
                    v0.Position = new Vector2f(i * sizePixel, j * sizePixel);
                    v1.Position = new Vector2f((i + 1) * sizePixel, j * sizePixel);
                    v2.Position = new Vector2f((i + 1) * sizePixel, (j + 1) * sizePixel);
                    v3.Position = new Vector2f(i * sizePixel, (j + 1) * sizePixel);

                    Color pixelColor = new Color((byte)0, (byte)i , (byte)j);
                    v0.Color = pixelColor;
                    v1.Color = pixelColor;
                    v2.Color = pixelColor;
                    v3.Color = pixelColor;

                    matrice[(i + j * width) * 4] = v0;
                    matrice[(i + j * width) * 4 + 1] = v1;
                    matrice[(i + j * width) * 4 + 2] = v2;
                    matrice[(i + j * width) * 4 + 3] = v3;

                }


            //            Vertex v = matrice[0];
            //            v.Position = new Vector2f(10, 10);
            //            v.Color = Color.Red;
            //            matrice[0] = v;
            //            v = matrice[1];
            //            v.Position = new Vector2f(110, 10);
            //            v.Color = Color.Red;
            //            matrice[1] = v;
            //            v = matrice[2];
            //            v.Position = new Vector2f(110, 110);
            //            v.Color = Color.Red;
            //            matrice[2] = v;
            //            v = matrice[3];
            //            v.Position = new Vector2f(10, 110);
            //            v.Color = Color.Red;
            //            matrice[3] = v;




            // Start the game loop
            while (app.IsOpen)
            {
                // Process events
                app.DispatchEvents();

                // Clear screen
                app.Clear();

                app.Draw(matrice);

                // Update the window
                app.Display();
            } //End game loop
        } //End Main()
    } //End Program
}