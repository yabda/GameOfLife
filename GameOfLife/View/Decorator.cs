using SFML.Graphics;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    class Decorator
    {

        public static DrawableObject Decorate(Grid g)
        {

            int sizePixel = 5;
            VertexArray matrice = new VertexArray(PrimitiveType.Quads, 4 * (uint)g.size * (uint)g.size);
            for (uint i = 0; i < g.size; ++i)
                for (uint j = 0; j < g.size; ++j)
                {
                    // on récupère le numéro de tuile courant


                    // on récupère un pointeur vers le quad à définir dans le tableau de vertex
                    Vertex v0 = matrice[(i + j * (uint)g.size) * 4];
                    Vertex v1 = matrice[(i + j * (uint)g.size) * 4 + 1];
                    Vertex v2 = matrice[(i + j * (uint)g.size) * 4 + 2];
                    Vertex v3 = matrice[(i + j * (uint)g.size) * 4 + 3];

                    // on définit ses quatre coins
                    v0.Position = new Vector2f(i * sizePixel, j * sizePixel);
                    v1.Position = new Vector2f((i + 1) * sizePixel, j * sizePixel);
                    v2.Position = new Vector2f((i + 1) * sizePixel, (j + 1) * sizePixel);
                    v3.Position = new Vector2f(i * sizePixel, (j + 1) * sizePixel);

                    Color pixelColor = Color.Black;

                    if (g.Cells[i, j].Alive)
                    {
                        pixelColor = Color.White;
                    }
                    else
                    {
                        pixelColor = Color.Black;
                    }


                    v0.Color = pixelColor;
                    v1.Color = pixelColor;
                    v2.Color = pixelColor;
                    v3.Color = pixelColor;

                    matrice[(i + j * (uint)g.size) * 4] = v0;
                    matrice[(i + j * (uint)g.size) * 4 + 1] = v1;
                    matrice[(i + j * (uint)g.size) * 4 + 2] = v2;
                    matrice[(i + j * (uint)g.size) * 4 + 3] = v3;

                }
            return new DrawableObject(matrice);
        }

    }
}
