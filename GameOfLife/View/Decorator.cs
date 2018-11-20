using GameOfLife.Model;
using SFML.Graphics;
using SFML.System;

namespace GameOfLife.View
{
    /*
     * Classe tranformant une grille en une matrice drawable
     */
    class Decorator
    {
        public static DrawableObject Decorate(Grid g, int pixelSize = 5)
        {
            VertexArray matrice = new VertexArray(PrimitiveType.Quads, 4 * (uint)g.Size * (uint)g.Size);
            for (uint i = 0; i < g.Size; ++i)
                for (uint j = 0; j < g.Size; ++j)
                { 
                    //Récupération des vertex
                    Vertex v0 = matrice[(i + j * (uint)g.Size) * 4];
                    Vertex v1 = matrice[(i + j * (uint)g.Size) * 4 + 1];
                    Vertex v2 = matrice[(i + j * (uint)g.Size) * 4 + 2];
                    Vertex v3 = matrice[(i + j * (uint)g.Size) * 4 + 3];

                    // on définit ses quatre coins
                    v0.Position = new Vector2f(i * pixelSize, j * pixelSize);
                    v1.Position = new Vector2f((i + 1) * pixelSize, j * pixelSize);
                    v2.Position = new Vector2f((i + 1) * pixelSize, (j + 1) * pixelSize);
                    v3.Position = new Vector2f(i * pixelSize, (j + 1) * pixelSize);

                    //Setup de la couleur
                    Color pixelColor = Color.Black;
                    if (g.Cells[i, j].Alive)
                        pixelColor = Color.White;
                    else
                        pixelColor = Color.Black;

                    v0.Color = pixelColor;
                    v1.Color = pixelColor;
                    v2.Color = pixelColor;
                    v3.Color = pixelColor;

                    //Mise en place des vertex
                    matrice[(i + j * (uint)g.Size) * 4] = v0;
                    matrice[(i + j * (uint)g.Size) * 4 + 1] = v1;
                    matrice[(i + j * (uint)g.Size) * 4 + 2] = v2;
                    matrice[(i + j * (uint)g.Size) * 4 + 3] = v3;

                }
            return new DrawableObject(matrice);
        }

    }
}
