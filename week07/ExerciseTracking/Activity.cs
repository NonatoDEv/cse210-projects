using System;
namespace FitnessCenter
{
    public abstract class Activity
    {
        private string _date;
        private int _minutes;
        protected bool _isMetric;
        public Activity(string date, int minutes, bool isMetric)//the constructor method
        {
            _date = date;
            _minutes = minutes;
            _isMetric = isMetric;
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
        private string GetDistanceUnit() => _isMetric ? "km" : "miles";
        private string GetSpeedUnit() => _isMetric ? "kph" : "mph";
        private string GetPaceUnit() => _isMetric ? "min per km" : "min per mile";
        public virtual string GetSummary()//applying formatting to the summary
        {
            return $"{_date} {this.GetType().Name} ({_minutes} min): " +
                   $"Distance {GetDistance():0.1} {GetDistanceUnit()}, " +
                   $"Speed {GetSpeed():0.1} {GetSpeedUnit()}, " +
                   $"Pace: {GetPace():0.2} {GetPaceUnit()}";
        }
    }
}