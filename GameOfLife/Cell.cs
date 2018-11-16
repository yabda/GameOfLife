
namespace GameOfLife
{
    class Cell
    {
        public bool Alive { get; set; }
        
        public Cell()
        {
            Alive = false;
        }

        public Cell(bool isAlive)
        {
            this.Alive = isAlive;
        }
    }
}