using System;
using System.Collections.Generic;

namespace FitnessCenter
{
    class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ExerciseTracking Project.");
        List<Activity> activities = new List<Activity>();
            activities.Add(new Running("03 Nov 2022", 60, 10.0, false));
            activities.Add(new Running("03 Nov 2022", 54, 8.7, true));
            activities.Add(new Cycling("05 Nov 2022", 45, 25.5, true));
            activities.Add(new Cycling("06 Nov 2022", 55, 15.5, false));
            activities.Add(new Swimming("07 Nov 2022", 40, 40, true));
            activities.Add(new Swimming("07 Nov 2022", 20, 20, false));
            
            Console.WriteLine("===============================================================");
            Console.WriteLine("          FITNESS CENTER - ACTIVITY TRACKING REPORT            ");
            Console.WriteLine("===============================================================\n");
            foreach (Activity act in activities)
            {
                Console.WriteLine(act.GetSummary());
            }
            Console.WriteLine("\n===============================================================");
        }
}
}