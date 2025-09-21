using Philosophers.Model.Storages;

namespace Philosophers.Model.Interfaces;

public abstract class IObservable
{
    protected List<IObserver> _observers = new List<IObserver>();
    public event EventHandler<CoordEventArgs> GetDirection;
}