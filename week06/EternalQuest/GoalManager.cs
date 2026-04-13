using System;
using System.Collections.Generic;
using System.IO;
public class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }
    public void Start()
    {
        string input  = "";
        while (input != "6")
        {
            Console.WriteLine();
            DisplayPlayerInfo();
            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("  1. Create New Goal");
            Console.WriteLine("  2. List Goals");
            Console.WriteLine("  3. Save Goals");
            Console.WriteLine("  4. Load Goals");
            Console.WriteLine("  5. Record Event");
            Console.WriteLine("  6. Quit");
            Console.Write("Select a choice from the menu: ");
            
            input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    CreateGoal();
                    break;
                case "2":
                    ListGoalDetails();
                    break;
                case "3":
                    SaveGoals();
                    break;
                case "4":
                    LoadGoals();
                    break;
                case "5":
                    RecordEvent();
                    break;
                case "6":
                    Console.WriteLine("¡Thanks for working today, see ya!");
                    break;
                default:
                    Console.WriteLine("Invalid option, please try again.");
                    break;
            }
        } 
    }
    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"You have {_score} points.");
    }
    public void ListGoalNames()
    {
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].ShortName}");
        }
    }
    public void ListGoalDetails()
    {
        Console.WriteLine("The goals are:");
        foreach (Goal goal in _goals)
        {
            // Polymorphism in action: each goal type can have its own details string
            Console.WriteLine(goal.GetDetailsString());
        }
    }
    public void CreateGoal()
    {
    }

    public void SaveGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        using (StreamWriter outputFile = new StreamWriter(fileName))
        {
            outputFile.WriteLine(_score);
            foreach (Goal goal in _goals)
            {
                outputFile.WriteLine(goal.GetStringRepresentation());
            }
        }
    Console.WriteLine("Goals saved successfully!");
    }
    public void LoadGoals()
    {
        Console.Write("What is the filename for the goal file? ");
        string fileName = Console.ReadLine();
        if (!File.Exists(fileName))
        {
            Console.WriteLine("File not found.");
            return;
        }
        string[] lines = File.ReadAllLines(fileName);
        //the first line is the score
        _score = int.Parse(lines[0]);
        //clean the current goals list before loading new ones
        _goals.Clear();
        // start from 1 to skip the score line
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            //divide the line into type and data
            //EG: "SimpleGoal:Kill the dragon,Slay the mighty dragon,100,true"
            string[] parts = line.Split(':');
            string goalType = parts[0];
            string goalData = parts[1];
            //now, we divide the data by commas to get the individual fields
            string[] data = goalData.Split(',');
            // logic to create the correct goal type based on the first part of the line
            if (goalType == "SimpleGoal")
            {
            // SimpleGoal(name, desc, points, isComplete)
                SimpleGoal sg = new SimpleGoal(data[0], data[1], int.Parse(data[2]));
                if (bool.Parse(data[3])) sg.RecordEvent(); //if the saved state is complete, we record the event to set it as complete
                _goals.Add(sg);
            }
            else if (goalType == "EternalGoal")
            {
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (goalType == "ChecklistGoal")
            {
                // ChecklistGoal(name, desc, points, bonus, target, amountCompleted)
                ChecklistGoal cg = new ChecklistGoal(data[0], data[1], int.Parse(data[2]), int.Parse(data[3]), int.Parse(data[4]));
                cg.AmountCompleted = int.Parse(data[5]);
                _goals.Add(cg);
                
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
    public void RecordEvent()
    {
    }
}