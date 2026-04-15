using System;

namespace FitnessCenter
{
    public class Running : Activity//inheriting from the Activity class
    {
        private double _distance;
        public Running(string date, int minutes, double distance) : base(date, minutes)// a correct order to call the base constructor
        {
            _distance = distance;
        }
        //aplying polymorphism to the methods of the base class
        public override double GetDistance()
        {
            return _distance;
        }
        public override double GetSpeed()
        {
            return (_distance/GetMinutes()) * 60.0;
        }
        public override double GetPace()
        {
            return GetMinutes() / _distance;
        }
    }
}