namespace Philosophers.Model;

public interface IStrategy
{
    void RunStep(Philosopher philosopher);
}