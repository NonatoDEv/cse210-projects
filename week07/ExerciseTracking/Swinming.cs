namespace FitnessCenter
{
    public class Swimming : Activity//aplying inheritance to the Activity class
    {
        private int _laps;//exclsive attribute for the Swimming class

        public Swimming(string date, int minutes, int laps) : base(date, minutes)
        {
            _laps = laps;
        }
        public override double GetDistance()
        {
            return (_laps * 50) / 1000.0;
        }
        public override double GetSpeed()
        {
            return (GetDistance() / GetMinutes()) * 60.0;
        }

        public override double GetPace()
        {
            return GetMinutes() / GetDistance();
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