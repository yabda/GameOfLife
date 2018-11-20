using GameOfLife.Configuration.Initialisation;
using GameOfLife.Model;
using GameOfLife.Model.Factory;
using GameOfLife.Observer;
using SFML.Graphics;
using SFML.System;
using SFML.Window;
using System;

namespace GameOfLife.View
{
    /*
     *  Classe incorporant la logique du programme 
     */
   class Screen
    {
        private RenderWindow App; //Fenetre visible
        public Grid grid { get; set; } //Grille de cellule
        static event EventHandler Observable; //Handler d'évènements
        public DrawableObject matrice { get; set; } //Matrice de cellule à draw
        public Configuration.Configuration conf { get; set; } //Configuration du système

        //Fonction d'initialisation du système
        public void Init(Configuration.Configuration conf)
        {
            this.conf = conf;

            App = new RenderWindow(new VideoMode(conf.WindowSize.X, conf.WindowSize.Y), "LA VIE"); //Construction de la fenetre
            App.Closed += new EventHandler(OnClose); //Ajout de l'évènement de fermeture

            //Construction de la grille
            grid = GridFactory.GetGrid(conf.Size); 
            grid = InitStratege.Init(conf.InitStrategy,grid);

            //Ajout de l'écoute de l'évenement de tick
            var next = new NextStep();
            Observable += new EventHandler(next.Run);
        }
        
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        public void Run()
        {
            //Construction de la première matrice
            Clock c = new Clock();
            matrice = Decorator.Decorate(grid, conf.pixelSize);

            //Boucle d'affichage
            while (App.IsOpen)
            {
                //Gestion des évènements fenêtre
                App.DispatchEvents();

                if (c.ElapsedTime.AsMilliseconds() > 1.0 / conf.Speed) //Tous les X temps
                {
                    Observable(this, new TickEvent()); //Envoit d'un event de tick
                    c.Restart(); //Restart de l'horloge
                }

                //CDD
                App.Clear();
                App.Draw(matrice);
                App.Display();
            } 
        }
    }
}
