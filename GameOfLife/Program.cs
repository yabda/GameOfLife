using GameOfLife.View;
using System;

namespace GameOfLife
{
    static class Program
    {
        static void Main()
        {
            Configuration.Configuration config = new Configuration.Configuration();
            config.ReadConfiguration();

            Screen app = new Screen();
            app.Init(config);
            app.Run();

            Console.Read();
            
        } 
    } 
}