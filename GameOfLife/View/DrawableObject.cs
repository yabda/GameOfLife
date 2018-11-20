using SFML.Graphics;

namespace GameOfLife.View
{
    /*
     * Objet drawable
     */
    class DrawableObject : Drawable
    {
        private VertexArray matrice;

        public DrawableObject(VertexArray matrice)
        {
            this.matrice = matrice;
        }

        public void Draw(RenderTarget target, RenderStates states)
        {
            // on dessine le tableau de vertex
            target.Draw(matrice, states);
        }
    }
}
