using Philosophers.Model.Interfaces;

namespace Philosophers.Strategy;

public class NaiveStrategy : IStrategy
{
    public void RunStep(IPhilosopher philosopher)
    {
        philosopher.CountTime();
        if (philosopher.IsThinking())
        {
            philosopher.TryMakeHungry();
        }
        else if (philosopher.IsHungry())
        {
            philosopher.TryMakeEating();
            if (philosopher.Id % 2 == 0)
            {
                if (!philosopher.HasLeftFork)
                {
                    philosopher.TryTakeLeftFork();
                }
                else if (philosopher.HasLeftFork)
                {
                    philosopher.TryTakeRightFork();
                }
            }
            else
            {
                if (!philosopher.HasRightFork)
                {
                    philosopher.TryTakeRightFork();
                }
                if (philosopher.HasRightFork)
                {
                    philosopher.TryTakeLeftFork();
                }
            }
        }
        else if (philosopher.IsEating())
        {
            philosopher.TryPutForks();
            philosopher.TryMakeThinking();
        }
    }
}