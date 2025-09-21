using Philosophers.Model.Interfaces;

namespace Philosophers.Implementations;

public class Coordinator(List<IPhilosopher> philosophers, List<IFork> forks) : IObservable
{
    private List<IFork> _forks = forks;
    private List<(IPhilosopher, IFork)> _philosophersToForks = new();
}