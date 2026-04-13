using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the EternalQuest Project.");
        GoalManager manager = new GoalManager();
        //just call the start method to run the program, the manager will handle all the user interaction and logic from there
        manager.Start();
    }
}