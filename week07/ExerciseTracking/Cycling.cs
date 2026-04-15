using System;

namespace FitnessCenter
{
    public class Cycling : Activity//aplying inheritance to the Activity class
    {
        private double _speed;//exclusive attribute for the Cycling class
        public Cycling(string date, int minutes, double speed, bool isMetric) : base(date, minutes, isMetric) //a correct order to call the base constructor
        {
            _speed = speed;
        }
        //applying polymorphism to the methods of the base class
        public override double GetSpeed()
        {
            return _speed;
        }
        public override double GetDistance()
        {
            return (_speed * GetMinutes()) / 60.0;
        }
        public override double GetPace()
        {
            return 60.0 / _speed;
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