using GameOfLife.Model;

namespace GameOfLife.Configuration.Initialisation
{
    /**
     * Classe gérant la stratégie d'initialisation
     * Renvoit la grille selon la stratégie utilisée
     **/
    class InitStratege
    {
        public static Grid Init(InitStrategy strat, int Size)
        {
            return strat.Init(Size);
        }

    }
}
