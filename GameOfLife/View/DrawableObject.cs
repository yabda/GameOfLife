using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SFML;
using SFML.Graphics;
using SFML.System;

namespace GameOfLife.View
{
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
