using GameOfLife.Configuration.Initialisation;
using GameOfLife.Configuration.Laws;
using GameOfLife.Model.Factory;
using SFML.System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Configuration
{
    class Configuration
    {
        public InitStrategy InitStrategy { get; set; }
        public LawStrategy LawStrategy { get; set; }
        public int Size { get; set; }
        public int Speed { get; set; }
        public Vector2u WindowSize { get; set; }
        public int pixelSize { get; set; }

        public Configuration()
        {
            InitStrategy = InitStrategyFactory.GetStrategy(InitType.File);
            LawStrategy = LawStrategyFactory.GetStrategy(LawType.Intervenant);
            Size = 250;
            Speed = 1;
            WindowSize = new Vector2u(750, 750);
            pixelSize = 4;
        }

        public void ReadConfiguration()
        {
            Console.Out.WriteLine("Bienvenue dans le wizard de configuration de jeu de la vie !");


            Console.Out.WriteLine("Choix de la taille de la fenètre :");
            bool largeur = false;
            int x = 750, y = 750;
            Console.Out.Write("Largeur (défaut 750px) : ");
            while (largeur)
            {
                string ret = Console.In.ReadLine();
                if(ret == "\n")
                    largeur = true;
                else
                {
                    try
                    {
                        x = int.Parse(ret);
                    }
                    catch(Exception e)
                    {

                    }
                }
                
            }
            

            Console.Out.Write("Hauteur (défaut 750px) : ");
            y = Int32.Parse(Console.In.ReadLine());
            WindowSize = new Vector2u((uint)x, (uint)y);

            Console.Out.Write("Choix de la taille de chaque cellule en pixel : ");
            pixelSize = Int32.Parse(Console.In.ReadLine());

            Console.Out.Write("Largeur du tableau de cellule en nombre de cellule : ");
            Size = Int32.Parse(Console.In.ReadLine());

            Console.Out.Write("Vitesse du système (10 - lent, 100 - rapide) : ");
            Speed = Int32.Parse(Console.In.ReadLine());

        }

    }
}
