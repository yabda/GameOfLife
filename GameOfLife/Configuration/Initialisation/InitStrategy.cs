using GameOfLife.Model;

namespace GameOfLife.Configuration.Initialisation
{
    /**
     * Interface de strategie
     * Rend obligatoire la méthode Init
     **/
    interface InitStrategy
    {
        Grid Init(Grid g);
    }
}
