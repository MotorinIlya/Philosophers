namespace Philosophers.Model;

public class Philosopher (string name, Fork leftFork, Fork rightFork)
{
    public string Name { get; } = name;
    public int TimeToNextAction => _timeToNextAction;
    public int TimeLeft => _timeToActionNow;
    public PhilosopherState State => _state;
    
    private PhilosopherState _state = PhilosopherState.Thinking;
    private int _timeToNextAction = 5;
    private int _timeToActionNow = 0;
    private readonly Random _rand = new Random();
    
    private Fork _leftFork = leftFork;
    private Fork _rightFork = rightFork;

    private bool _hasLeftFork = false;
    private bool _hasRightFork = false;

    private int _countTimeToTakeLeftFork = 0;
    private int _countTimeToTakeRightFork = 0;
    
    public bool IsThinking() => _state == PhilosopherState.Thinking;
    public bool IsHungry() => _state == PhilosopherState.Hungry;
    public bool IsEating() => _state == PhilosopherState.Eating;

    public void TryPutForks()
    {
        if (_timeToNextAction == 0)
        {
            _leftFork.State = ForkState.Available;
            _rightFork.State = ForkState.Available;
            _hasLeftFork = false;
            _hasRightFork = false;
        }
    }

    public void TryTakeLeftFork()
    {
        if (!_hasLeftFork && _leftFork.State == ForkState.Available)
        {
            _countTimeToTakeLeftFork++;
            if (_countTimeToTakeLeftFork == Const.StepsForTakingFork)
            {
                TakeLeftFork();
                _countTimeToTakeLeftFork = 0;
            }
        }
    }

    public void TryTakeRightFork()
    {
        if (_hasLeftFork && !_hasRightFork && _rightFork.State == ForkState.Available)
        {
            _countTimeToTakeRightFork++;
            if (_countTimeToTakeRightFork == Const.StepsForTakingFork)
            {
                TakeRightFork();
                _countTimeToTakeRightFork = 0;
            }
        }
    }

    private void TakeLeftFork()
    {
        _leftFork.State = ForkState.InUse;
        _hasLeftFork = true;
    }

    private void TakeRightFork()
    {
        _rightFork.State = ForkState.InUse;
        _hasRightFork = true;
    }

    public void CountTime()
    {
        _timeToActionNow++;
        _timeToNextAction--;
    }

    public void TryMakeHungry()
    {
        if (_timeToNextAction == 0)
        {
            _state = PhilosopherState.Hungry;
            _timeToActionNow = 0;
        }
    }

    public void TryMakeThinking()
    {
        if (_timeToNextAction == 0)
        {
            _state = PhilosopherState.Thinking;
            _timeToNextAction = _rand.Next(Const.MinStepsForThinking, Const.MaxStepsForThinking);
        }
    }

    public void TryMakeEating()
    {
        if (_hasLeftFork && _hasRightFork)
        {
            _state = PhilosopherState.Eating;
            _timeToNextAction = _rand.Next(Const.MinStepsForEating, Const.MaxStepsForEating);
            _timeToActionNow = 0;
        }
    }
}