using GameOfLife.Configuration.Initialisation;

namespace GameOfLife.Model.Factory
{
    public enum InitType
    {
        Damier,
        Random,
        Table
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
                default:
                    return new RandomInit();
            }
        }
    }
}
