namespace Philosophers.Model;

public class NaiveStrategy : IStrategy
{
    public void RunStep(Philosopher philosopher)
    {
        philosopher.CountTime();
        if (philosopher.IsThinking())
        {
            philosopher.TryMakeHungry();
        }
        else if (philosopher.IsHungry())
        {
            philosopher.TryMakeEating();
            philosopher.TryTakeLeftFork();
            philosopher.TryTakeRightFork();
        }
        else if (philosopher.IsEating())
        {
            philosopher.TryPutForks();
            philosopher.TryMakeThinking();
        }
    }
}