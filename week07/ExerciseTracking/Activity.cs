using System;
namespace FitnessCenter
{
    public abstract class Activity
    {
        private string _date;
        private int _minutes;
        public Activity(string date, int minutes)//the constructor method
        {
            _date = date;
            _minutes = minutes;
        }
        protected int GetMinutes()//method to get the minutes of the activity for the derived classes
        {
            return _minutes;
        }
        protected string GetDate()//method to get the date of the activity for the derived classes
        {
            return _date;
        }
        public abstract double GetDistance();
        public abstract double GetSpeed();
        public abstract double GetPace();
        public virtual string GetSummary()//applying formatting to the summary
        {
            return $"{_date} {this.GetType().Name} ({_minutes} min): " +
                   $"Distance {GetDistance():0.0}, Speed {GetSpeed():0.0}, " +
                   $"Pace: {GetPace():0.0}";
        }
    }
}