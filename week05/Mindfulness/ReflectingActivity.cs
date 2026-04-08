using System;
using System.Collections.Generic;
public class ReflectingActivity : Activity
{
   private List<string> _prompts = new List<string>
{
    "Think of a time when you did something truly difficult.",
    "Think of a time when you helped someone in need.",
    "Think of a time when you overcame self-doubt or a great challenge.",
    "Think of a time when you stood up for someone else."
};

private List<string> _questions = new List<string>
{
    "Why was this experience meaningful to you?",
    "Have you ever done anything like this before?",
    "How did you get started?",
    "How did you feel when it was complete?",
    "What made this time different than other times when you were not as successful?",
    "What is your favorite thing about this experience?",
    "What could you learn from this experience that applies to other situations?",
    "What did you learn about yourself through this experience?",
    "How can you keep this experience in mind in the future?"
};
    public ReflectingActivity() : base("Reflecting Activity", 
        "This activity will help you reflect on times of strength and resilience.")
    {
    }
    public void Run()
    {
        DisplayStartingMessage();
        string prompt = GetRandomPrompt();
        Console.WriteLine("\nConsider the following prompt:");
        Console.WriteLine($"--- {prompt} ---");
        Console.WriteLine("\nWhen you have something in mind, press enter to continue.");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they relate to this experience.");
        Console.Write("You may begin in: ");
        ShowCountDown(5);
        DateTime endTime = DateTime.Now.AddSeconds(_duration);
        while (DateTime.Now < endTime)
        {
            string question = GetRandomQuestion();
            Console.Write($"> {question} ");
            ShowSpinner(10);
            Console.WriteLine();
        }
        DisplayEndingMessage();
    }
    private string GetRandomPrompt()
    {
        Random random = new Random();
        return _prompts[random.Next(_prompts.Count)];
    }
    private string GetRandomQuestion()
    {
        Random random = new Random();
        return _questions[random.Next(_questions.Count)];
    }
}