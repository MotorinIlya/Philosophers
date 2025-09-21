using Philosophers.Model.Enums;

namespace Philosophers.Model.Storages;

public class CoordEventArgs
{
    public int Id { get; }
    public Side PhilosopherSide { get; }
}