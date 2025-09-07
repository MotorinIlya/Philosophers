namespace Philosophers.Model;

public class Fork
{
    public ForkState State { get; set; } = ForkState.Available;
}