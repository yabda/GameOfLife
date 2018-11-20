namespace GameOfLife.Model.Factory
{
    /**
     * Factory permettant de générer des grilles
     **/
    static class GridFactory
    {
        public static Grid GetGrid(int size = 150)
        {
            if (size < 0)
                return new Grid();
            return new Grid(size);
        }
    }
}
