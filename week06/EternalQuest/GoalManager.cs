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
                    Console.WriteLine("Thanks for your hard work today! See you later.");
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
        Console.WriteLine("The types of Goals are:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        string choice = Console.ReadLine();
        // starting data collection for all goal types
        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        int points = GetValidInt("What is the amount of points associated with this goal? ");
        //based on the goal type choice, we will collect any additional data needed and then create the appropriate goal object and add it to the list
        if (choice == "1")
        {
            _goals.Add(new SimpleGoal(name, description, points));
        }
        else if (choice == "2")
        {
            _goals.Add(new EternalGoal(name, description, points));
        }
        else if (choice == "3")
        {
            int target = GetValidInt("How many times does this goal need to be accomplished for a bonus? ");
            int bonus = GetValidInt("What is the bonus for accomplishing it that many times? ");
            _goals.Add(new ChecklistGoal(name, description, points, target, bonus));
        }   
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
        int.TryParse(lines[0], out _score);
        //clean the current goals list before loading new ones
        _goals.Clear();
        // start from 1 to skip the score line
        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            //divide the line into type and data
            //EG: "SimpleGoal:Kill the dragon,Slay the mighty dragon,100,true"
            string[] parts = line.Split(':');
            if (parts.Length <2) continue; //skip any malformed lines
            string goalType = parts[0];
            //now, we divide the data by commas to get the individual fields
            string[] data = parts[1].Split(',');
            // logic to create the correct goal type based on the first part of the line
            if (goalType == "SimpleGoal")
            {
                // SimpleGoal(name, desc, points, isComplete)
                int.TryParse(data[2], out int points);
                SimpleGoal sg = new SimpleGoal(data[0], data[1], points);
                if (bool.TryParse(data[3], out bool isComplete) && isComplete) 
                    sg.RecordEvent();
                _goals.Add(sg);
            }
            else if (goalType == "EternalGoal")
            {
                // EternalGoal(name, desc, points)
                int.TryParse(data[2], out int points);
                _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
            }
            else if (goalType == "ChecklistGoal")
            {
                // ChecklistGoal(name, desc, points, bonus, target, amountCompleted)
                int.TryParse(data[2], out int points);
                int.TryParse(data[3], out int bonus);
                int.TryParse(data[4], out int target);
                int.TryParse(data[5], out int completed);
                ChecklistGoal cg = new ChecklistGoal(data[0], data[1], points, target, bonus);
                cg.AmountCompleted = completed;
                _goals.Add(cg);
            }
        }
        Console.WriteLine("Goals loaded successfully!");
    }
    public void RecordEvent()
    {
        // 1. show the user the list of goals to choose from
        ListGoalNames();
        Console.Write("Which goal did you accomplish? ");
        int index = GetValidInt("Which goal did you accomplish? ") - 1;
        if (index >= 0 && index < _goals.Count)
        {
            Goal selectedGoal = _goals[index];
            // 2. record the event for the selected goal
            selectedGoal.RecordEvent();
            // 3. calculate the points earned for this event (including any bonus points if it's a checklist goal)
            int pointsEarned = selectedGoal.Points;
            // 4. if the goal is a checklist goal and it's now complete, add the bonus points
            if (selectedGoal is ChecklistGoal checklist && checklist.IsComplete())
            {
                pointsEarned += checklist.Bonus; // Sum the bonus points
                Console.WriteLine($"EXTRA BONUS! You have earned {checklist.Bonus} extra points for completing the checklist!");
            }
            // 5. refresh the dashboard to show the updated points and goal status
            _score += pointsEarned;
            Console.WriteLine($"Congratulations! You have earned {pointsEarned} points!");
            Console.WriteLine($"You now have {_score} points.");
        }
        else
        {
            Console.WriteLine("Invalid goal selection.");
        }
    }
    private int GetValidInt(string prompt)
    {
        int result;
        Console.Write(prompt);
        string input = Console.ReadLine();
        while (!int.TryParse(input, out result))
        {
            Console.WriteLine("Error: Please enter a valid number.");
            Console.Write(prompt);
            input = Console.ReadLine();
        }
        return result;
    }
}