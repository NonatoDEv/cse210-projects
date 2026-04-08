using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Mindfulness Project.");
        string userChoice = "";
        while (userChoice != "4")
        {
            Console.Clear();
            Console.WriteLine("Menu Options:");
            Console.WriteLine("  1. Start breathing activity");
            Console.WriteLine("  2. Start reflecting activity");
            Console.WriteLine("  3. Start listing activity");
            Console.WriteLine("  4. Quit");
            Console.Write("Select a choice from the menu: ");
            userChoice = Console.ReadLine();
            if (userChoice == "1")
            {
                BreathingActivity breathing = new BreathingActivity();
                breathing.Run();
            }
            else if (userChoice == "2")
            {
                ReflectingActivity reflecting = new ReflectingActivity();
                reflecting.Run();
            }
            else if (userChoice == "3")
            {
                ListingActivity listing = new ListingActivity();
                listing.Run();
            }
        }

        Console.WriteLine("\nKeep coding and stay resilient, Abel. Goodbye!");
    }
}