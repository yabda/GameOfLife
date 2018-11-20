using GameOfLife.Configuration.Laws;

namespace GameOfLife.Model.Factory
{
    public enum LawType
    {
        Alo,
        Conway,
        Prof,
        Intervenant
    }

    /**
     * Factory permettant de générer des stratégies de fonctionnement
     **/
    static class LawStrategyFactory
    {
        public static LawStrategy GetStrategy(LawType type)
        {
            switch (type)
            {
                case LawType.Alo:
                    return new AloLaw();
                case LawType.Conway:
                    return new ConwayLaw();
                case LawType.Prof:
                    return new ProfLaw();
                case LawType.Intervenant:
                    return new IntervenantLaw();
                default:
                    return new ConwayLaw();
            }
        }
    }
}
