
namespace GameOfLife.Model
{
    class Cell : ICell
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

        public override bool Equals(object obj)
        {
            var cell = obj as Cell;
            return cell != null && Alive == cell.Alive;
        }
    }
}