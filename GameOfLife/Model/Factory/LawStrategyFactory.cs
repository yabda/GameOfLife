using GameOfLife.Configuration.Laws;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife.Model.Factory
{
    public enum LawType
    {
        Alo,
        Conway,
        Prof,
        Intervenant
    }

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
