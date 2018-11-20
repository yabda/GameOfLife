using GameOfLife.View;

namespace GameOfLife
{
    static class Program
    {
        static void Main()
        {
            Configuration.Configuration config = new Configuration.Configuration();

            Screen app = new Screen();
            app.Init(config);
            app.Run();
        } 
    } 
}