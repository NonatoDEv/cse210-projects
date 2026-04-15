using System;

namespace FitnessCenter
{
    public class Running : Activity//inheriting from the Activity class
    {
        private double _distance;//exclusive attribute for the Running class
        public Running(string date, int minutes, double distance, bool isMetric) : base(date, minutes, isMetric)// a correct order to call the base constructor
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
//Math Hints:
//Distance (km) = swimming laps * 50 / 1000
//Distance (miles) = swimming laps * 50 / 1000 * 0.62
//Speed (mph or kph) = (distance / minutes) * 60
//Pace (min per mile or min per km)= minutes / distance
//Speed = 60 / pace
//Pace = 60 / speed