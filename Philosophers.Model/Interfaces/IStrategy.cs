namespace Philosophers.Model.Interfaces;

public interface IStrategy
{
    void RunStep(IPhilosopher philosopher);
}