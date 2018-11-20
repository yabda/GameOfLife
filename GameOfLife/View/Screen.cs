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
        public Grid previousGrid { get; set; }
        static event EventHandler Observable; //Handler d'évènements
        public DrawableObject matrice { get; set; } //Matrice de cellule à draw
        public static Configuration.Configuration conf { get; set; } //Configuration du système
        public bool Over;

        //Fonction d'initialisation du système
        public void Init(Configuration.Configuration conf)
        {
            Screen.conf = conf;

            App = new RenderWindow(new VideoMode(conf.WindowSize.X, conf.WindowSize.Y), "LA VIE"); //Construction de la fenetre
            App.Closed += new EventHandler(OnClose); //Ajout de l'évènement de fermeture
            App.KeyPressed += OnKeyPressed;

            //Construction de la grille
            grid = InitStratege.Init(conf.InitStrategy,conf.Size);

            //Ajout de l'écoute de l'évenement de tick
            var next = new NextStep();
            Observable += new EventHandler(next.Run);
        }
        
        static void OnClose(object sender, EventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;
            window.Close();
        }

        static void OnKeyPressed(object sender, KeyEventArgs e)
        {
            RenderWindow window = (RenderWindow)sender;

            SFML.Graphics.View v = window.GetView();

            if (Keyboard.IsKeyPressed(Keyboard.Key.Add))
                v.Zoom(0.75f);
            if (Keyboard.IsKeyPressed(Keyboard.Key.Subtract))
                v.Zoom(1.25f);

            if (Keyboard.IsKeyPressed(Keyboard.Key.Return))
                conf.Speed += 50;
            if (Keyboard.IsKeyPressed(Keyboard.Key.Space) && conf.Speed - 50 > 0)
                conf.Speed -= 50;

            window.SetView(v);

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
                SFML.Graphics.View v = App.GetView();

                if (Keyboard.IsKeyPressed(Keyboard.Key.Up))
                    v.Move(new Vector2f(0.0f, -0.5f));
                if (Keyboard.IsKeyPressed(Keyboard.Key.Down))
                    v.Move(new Vector2f(0.0f, 0.5f));
                if (Keyboard.IsKeyPressed(Keyboard.Key.Right))
                    v.Move(new Vector2f(0.5f, 0.0f));
                if (Keyboard.IsKeyPressed(Keyboard.Key.Left))
                    v.Move(new Vector2f(-0.5f, 0.0f));
                App.SetView(v);

                if (c.ElapsedTime.AsMilliseconds() > conf.Speed && !Over) //Tous les X temps
                {
                    Observable(this, new TickEvent()); //Envoit d'un event de tick
                    c.Restart(); //Restart de l'horloge
                }
                if (Over)
                {
                    Console.Out.WriteLine("Fin du Game");
                    App.Close();
                }

                //CDD
                App.Clear(Color.Cyan);
                App.Draw(matrice);
                App.Display();
            } 
        }
    }
}
