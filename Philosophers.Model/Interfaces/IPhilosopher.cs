using Philosophers.Model.Enums;

namespace Philosophers.Model.Interfaces;

public interface IPhilosopher
{
    public int Id { get; }
    public string Name { get; }
    public bool HasLeftFork { get; }
    public bool HasRightFork { get; }
    public int CountEat { get; }
    public PhilosopherState State { get; }
    public int TimeLeft { get; }
    public int TimeToNextAction { get; }
    public bool IsThinking();
    public bool IsHungry();
    public bool IsEating();
    public void TryPutForks();
    public void TryTakeLeftFork();
    public void TryTakeRightFork();
    public void TryMakeHungry();
    public void TryMakeThinking();
    public void TryMakeEating();
    public void CountTime();
}