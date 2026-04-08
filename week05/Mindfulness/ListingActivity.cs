using System;
using System.Collections.Generic;
public class ListingActivity : Activity
{
    private int _count;
    private List<string> _prompts = new List<string>
    {
    "Who are people that you appreciate?",
    "What are personal strengths of yours?",
    "Who are people that you have helped this week?",
    "When have you felt the influence of the Spirit this month?",
    "Who are some of your personal heroes?"
    };
    public ListingActivity() : base("Listing Activity", 
        "This activity will help you reflect on the good things in your life by asking you to list as many things as you can in a certain area.")
    {
    }
    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nList as many responses as you can to the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        Console.WriteLine();
        List<string> userList = GetListFromUser();
        _count = userList.Count;
        Console.WriteLine($"You listed {_count} items!");
        DisplayEndingMessage();
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
    private List<string> GetListFromUser()
    {
        List<string> inputs = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string input = Console.ReadLine();
            if (!string.IsNullOrEmpty(input))
            {
                inputs.Add(input);
            }
        }
        return inputs;
    }
}