using System;
//EXCEEDING REQUIREMENTS
//I implemented the following features:
//1.-Defensive Programming & Robust Input Validation:
//  I developed a private 'GetValidInt' helper method in the GoalManager class. 
//  This method uses 'int.TryParse' in a loop to handle invalid user inputs (like letters or 
//  symbols) without crashing the program, ensuring a smooth User Experience.
//2.-Advanced Data Loading Integrity:
//  In the 'LoadGoals' method, I applied 'int.TryParse' and 'bool.TryParse' to all fields 
//  coming from the external file. This prevents the application from throwing exceptions 
//  if the save file is corrupted or manually edited incorrectly.
//3.-Polimorphic Bonus Handling:
//  I used advanced type checking (is/as) in 'RecordEvent' to dynamically identify 
//  Checklist goals and process complex bonus logic while maintaining a clean, 
//  modular structure in the main manager.
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