public abstract class Goal
{
    private string _shortName;
    private string _description;
    private int _points;
    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
    }
    public string ShortName => _shortName;
    public string Description => _description;
    public int Points => _points;
    public abstract void RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStringRepresentation();
    public virtual string GetDetailsString()
    {
        return $"[{ (IsComplete() ? "X" : " ") }] {_shortName} ({_description})";
    }
}