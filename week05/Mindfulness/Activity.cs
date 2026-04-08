using System;
using System.Collections.Generic;
using System.Threading;
public class Activity
{
    //Attributes protected,so they can be used in the derived classes
    protected string _name;
    protected string _description;
    protected int _duration;
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {_name}.");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        _duration = int.Parse(Console.ReadLine());
        
        Console.Clear();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }
    public void ShowCountDown(int seconds)
{
    for (int i = seconds; i > 0; i--)
    {
        Console.Write(i);
        Thread.Sleep(1000);
        Console.Write("\b \b");
    }
}
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!!");
        ShowSpinner(3);
        Console.WriteLine($"You have completed another {_duration} seconds of the {_name}.");
        ShowSpinner(3);
    }
    public void ShowSpinner(int seconds)
    {
        List<string> animationCharacters = new List<string> { "|", "/", "-", "\\" };
        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(seconds);
        int i = 0;
        while (DateTime.Now < endTime)
        {
            string s = animationCharacters[i];
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
            i++;
            if (i >= animationCharacters.Count) i = 0;
        }
    }
}