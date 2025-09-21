using Philosophers.Model.Interfaces;

namespace Philosophers.Strategy;

public class CoordinatorStrategy(ICoordinator coordinator) : IStrategy
{
    private ICoordinator _coordinator = coordinator;
    public void RunStep(IPhilosopher philosopher)
    {
        philosopher.CountTime();
        if (philosopher.IsThinking())
        {
            philosopher.TryMakeHungry();
        }
        else if (philosopher.IsHungry())
        {
            
        }
    }
}