using GameOfLife.Configuration.Initialisation;
using GameOfLife.Configuration.Laws;
using GameOfLife.Model.Factory;
using SFML.System;
using System;

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

        private int GetInteger(string text, int defaut)
        {
            int x = defaut;
            while (true)
            {
                Console.Out.Write(text);
                string ret = Console.ReadLine();
                if (string.IsNullOrEmpty(ret))
                    break;
                else
                {
                    try
                    {
                        x = int.Parse(ret);
                        if (x > 0)
                            return x;
                        else
                            Console.Out.WriteLine("Mauvaise entrée ! ");
                    }
                    catch (FormatException e)
                    {
                        Console.Out.WriteLine("Mauvaise entrée ! ");
                    }
                }
            }
            return x;
        }

        public void ReadConfiguration()
        {
            Console.Out.WriteLine("Bienvenue dans le wizard de configuration de jeu de la vie !");

            Console.Out.WriteLine("Choix de la taille de la fenêtre :");
            WindowSize = new Vector2u((uint)GetInteger("Largeur (défaut 750px) : ", 750), (uint)GetInteger("Hauteur (défaut 750px) : ", 750));
            this.pixelSize = GetInteger("Choix de la taille de chaque cellule en pixel (défaut 5) : ", 5);
            this.Size = GetInteger("Largeur du tableau de cellule en nombre de cellule (défaut 150) : ", 150);
            this.Speed = GetInteger("Vitesse du système (1 - lent, 100 - rapide) : ", 50);

            Console.Out.WriteLine("");
            Console.Out.WriteLine("Initialisation : ");
            Console.Out.WriteLine("Type disponible : ");
            Console.Out.WriteLine("Random (1) - défaut");
            Console.Out.WriteLine("Damier (2)");
            Console.Out.WriteLine("Table (3)");
            Console.Out.WriteLine("File (4)");
            int initType = GetInteger("Choix de l'initialisation : ", 1);
            if (initType > 4) initType = 1;
            this.InitStrategy = InitStrategyFactory.GetStrategy((InitType)initType);

            Console.Out.WriteLine("");
            Console.Out.WriteLine("Algorithme de fonctionnement : ");
            Console.Out.WriteLine("Type disponible : ");
            Console.Out.WriteLine("Conway (1) - défaut");
            Console.Out.WriteLine("Alo (2)");
            Console.Out.WriteLine("Prof (3)");
            Console.Out.WriteLine("intervenant (4)");
            int lawType = GetInteger("Choix de fonctionnement : ", 1);
            if (lawType > 4) lawType = 1;
            this.LawStrategy = LawStrategyFactory.GetStrategy((LawType)lawType);
        }

    }
}
