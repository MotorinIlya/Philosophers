using Philosophers.Model.Enums;

namespace Philosophers.Model.Interfaces;

public interface IFork
{
    public ForkState State { get; set; }
    public int Id { get; }
}