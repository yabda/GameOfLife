using System;
using SFML.Graphics;
using SFML.Window;
using SFML.System;
using GameOfLife.View;
using GameOfLife.Configuration.Initialisation;
using GameOfLife.Model;
using GameOfLife.Configuration.Laws;
using GameOfLife.Model.Factory;

namespace GameOfLife
{
    static class Program
    {
        static void Main()
        {
            Screen app = new Screen();
            app.Init(new Configuration.Configuration());

            app.Run();
            
        } 
    } 
}