using GameOfLife.Configuration.Initialisation;

namespace GameOfLife.Model.Factory
{
    public enum InitType
    {
        Random = 1,
        Damier = 2,
        Table = 3,
        File = 4
    }

    /**
     * Factory permettant de générer des stratégies d'initialisation
     **/
    static class InitStrategyFactory
    {
        public static InitStrategy GetStrategy(InitType type)
        {
            switch(type)
            {
                case InitType.Damier:
                    return new DamierInit();
                case InitType.Random:
                    return new RandomInit();
                case InitType.Table:
                    return new TableInit();
                case InitType.File:
                    return new FileInit();
                default:
                    return new RandomInit();
            }
        }
    }
}
