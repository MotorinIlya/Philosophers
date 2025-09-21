using Philosophers.Model.Enums;
using Philosophers.Model.Interfaces;

namespace Philosophers.Implementations;

public class Fork(int id) : IFork
{
    public ForkState State { get; set; } = ForkState.Available;
    public int Id { get; } = id;
}