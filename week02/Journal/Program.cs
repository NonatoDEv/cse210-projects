using System;
using System.Collections.Generic;
using System.IO;
public class Entry
{
    public string _date;
    public string _promptText;
    public string _entryText;
    public string _mood;
    public Entry(string date, string promptText, string entryText, string mood)
    {
        _date = date;
        _promptText = promptText;
        _entryText = entryText;
        _mood = mood;
    }
    public void DisplayEntry()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Mood: {_mood}");
        Console.WriteLine($"Prompt: {_promptText}");
        Console.WriteLine($"Entry: {_entryText}");
        
    }
}

public class PromptGenerator
{
    public List<string>_prompts = new List<string>
    {
        "what did you smile about today?",
        "what was the best part of your day?",
        "what was the most challenging part of your day?",
        "what did you learn today?",
        "what are you grateful for today?"
        
    };
    public string GetRandomPrompt()
    {
        Random random = new Random();
        int index = random.Next(_prompts.Count);
        return _prompts[index];
    }
}
class Journal
{
    public List<Entry> _entries = new List<Entry>();
    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }
    public void DisplayEntries()
    {
        foreach (Entry entry in _entries)
        {
            entry.DisplayEntry();
            Console.WriteLine();
        }
    }
     public string EscapeCsvField(string field)
    {
        if (field.Contains(",") || field.Contains("\"") || field.Contains("\n"))
        {
            field = field.Replace("\"", "\"\"");
            return $"\"{field}\"";
        }
        return field;
    }
    public void SaveToFile(string file)
    {
        using (StreamWriter writer = new StreamWriter(file))
        {
            writer.WriteLine("Date,Mood,Prompt,Entry"); 
            foreach (Entry entry in _entries)
            {
                string date    = EscapeCsvField(entry._date);
                string mood    = EscapeCsvField(entry._mood);
                string prompt  = EscapeCsvField(entry._promptText);
                string text    = EscapeCsvField(entry._entryText);

                writer.WriteLine($"{date},{mood},{prompt},{text}");
            }
        }
    }
    public void LoadFromFile(string file)
    {
        _entries.Clear();
        string[] lines = File.ReadAllLines(file);
        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = ParseCsvLine(lines[i]);
            if (parts.Length < 4) continue;

            Entry entry = new Entry(parts[0], parts[2], parts[3], parts[1]);
            _entries.Add(entry);
        }
        
    }
    private string[] ParseCsvLine(string line)
    {
        List<string> fields = new List<string>();
        bool inQuotes = false;
        string current = "";

        for (int i = 0; i < line.Length; i++)
        {
            char c = line[i];

            if (inQuotes)
            {
                if (c == '"')
                {
                    if (i + 1 < line.Length && line[i + 1] == '"')
                    {
                        current += '"';
                        i++;
                    }
                    else
                    {
                        inQuotes = false;
                    }
                }
                else
                {
                    current += c;
                }
            }
            else
            {
                if (c == '"')
                {
                    inQuotes = true;
                }
                else if (c == ',')
                {
                    fields.Add(current);
                    current = "";
                }
                else
                {
                    current += c;
                }
            }
        }

        fields.Add(current);
        return fields.ToArray();
    }
}
// Exceeds requirements by: (1) saving/loading journal entries as a proper CSV file
// following RFC 4180 standard, including correct escaping of commas and quotation marks,
// with a header row readable in Excel; (2) adding a mood field to each entry,
// addressing the common journaling barrier of not capturing emotional context.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the Journal Project.");
        Journal journal = new Journal();
        while (true)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display all entries");
            Console.WriteLine("3. Load entries from a file");
            Console.WriteLine("4. Save entries to a file");
            Console.WriteLine("5. Exit");
            Console.Write("What would you like to do?: ");
            string choice = Console.ReadLine();
            
            if (choice == "1")
             {
                Console.WriteLine("\nHow are you feeling today?");
                Console.WriteLine("1. Happy ");
                Console.WriteLine("2. Neutral ");
                Console.WriteLine("3. Sad ");
                Console.Write("Choose your mood (1-3): ");
                string moodChoice = Console.ReadLine();
                string mood = moodChoice switch
                {
                    "1" => "Happy ",
                    "2" => "Neutral ",
                    "3" => "Sad ",
                    _   => "Unknown"
                };
                PromptGenerator promptGenerator = new PromptGenerator();
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\n{prompt}");
                string entryText = Console.ReadLine();
                DateTime theCurrentTime = DateTime.Now;
                string date = theCurrentTime.ToShortDateString();
                Entry entry = new Entry(date, prompt, entryText, mood);
                journal.AddEntry(entry);
            }
            else if (choice == "2")
            {
                journal.DisplayEntries();
            }
            else if (choice == "3")
            {
                Console.Write("Enter the filename to load from: ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter the filename to save (e. g., journal.csv): ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "5")
            {
                break;
            }
        }
    }
    
}