public class ChecklistGoal : Goal
{
    private int _amountCompleted;
    private int _target;
    private int _bonus;
    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _amountCompleted = 0;
        _target = target;
        _bonus = bonus;
    }
    public override void RecordEvent()
    {
        _amountCompleted++;
    }
    public override bool IsComplete()
    {
        return _amountCompleted >= _target;
    }
    public int AmountCompleted 
    { 
        get
        {
            return _amountCompleted; //the goal manager can read or get
        } 
        set
        {
            _amountCompleted = value;//the goal manager can write or set
        } 
    }
    public override string GetDetailsString()
    {
        return $"{base.GetDetailsString()} -- Currently completed: {_amountCompleted}/{_target}";
    }
    public override string GetStringRepresentation()
    {
     return $"ChecklistGoal:{ShortName}|{Description}|{Points}|{_amountCompleted}|{_target}|{_bonus}";   
    }
}