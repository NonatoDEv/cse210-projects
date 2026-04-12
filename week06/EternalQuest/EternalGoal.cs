public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {
    }
    public override void RecordEvent()
    {
        // Eternal goals are never completed, so we do nothing here.
    }
    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete.
    }
    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{ShortName}|{Description}|{Points}";
    }
}
