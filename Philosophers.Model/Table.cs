namespace Philosophers.Model;

public class Table
{
    private readonly List<Philosopher> _philosophers;
    private readonly List<Fork> _forks;
    private readonly IStrategy _strategy;

    public Table(List<string> namesPhilosophers)
    {
        _strategy = new NaiveStrategy();
        _philosophers = new List<Philosopher>();
        _forks = new List<Fork>();
        for (var i = 0; i < namesPhilosophers.Count; i++)
        {
            _forks.Add(new Fork());
        }

        for (var i = 0; i < namesPhilosophers.Count; i++)
        {
            _philosophers.Add(new Philosopher(
                namesPhilosophers[i], 
                _forks[i],
                _forks[(i + 1) % namesPhilosophers.Count]));
        }
    }

    public void Run(int steps = Const.StepsInSimulation)
    {
        for (var i = 0; i < steps; i++)
        {
            foreach (var philosopher in _philosophers)
            {
                _strategy.RunStep(philosopher);
            }

            if (i % 50_000 == 0)
            {
                PrintState(i);
            }
        }
    }

    private void PrintState(int step)
    {
        Console.WriteLine($"===== ШАГ {step} =====");
        Console.WriteLine("Философы:");
        foreach (var p in _philosophers)
        {
            string extra = p.State switch
            {
                PhilosopherState.Thinking => $"(осталось: {p.TimeToNextAction})",
                PhilosopherState.Hungry   => $"(Action =)",
                PhilosopherState.Eating   => $"({p.TimeLeft} steps left)",
                _ => ""
            };
            Console.WriteLine($"  {p.Name}: {p.State} {extra}");
        }
        Console.WriteLine("\nВилки:");
        for (var i = 0; i < _forks.Count; i++)
        {
            if (_forks[i].State == ForkState.Available)
                Console.WriteLine($"  Fork-{i}: Available");
            else
                Console.WriteLine($"  Fork-{i}: InUse (используется)");
        }
        Console.WriteLine();
    }
}