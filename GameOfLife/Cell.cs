namespace SFML_Test
{
    static class Cell
    {
        Tuple<int, int> position { get;set; }
        bool isAlive { get; set; }

        Cell()
        {
            position = (0, 0);
            isAlive = false;
        }
        Cell(Tuple<int,int> pos, bool isAlive)
        {
            position = pos;
            this.isAlive = isAlive;
        }

    }
}