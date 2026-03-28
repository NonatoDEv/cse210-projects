using System;
//CREATIVITY AND EXCEEDING REQUIREMENTS:
//1. Intelligent Hiding Logic: The HideRandomWords method is designed to randomly select ONLY words that are not already hidden. This ensures the program remains efficient and avoids "wasted" turns where the user presses enter but no new words disappear.
//2. Dynamic Word Formatting: The Word class automatically generates a matching number of underscores based on the specific length of the hidden word, maintaining the visual structure of the scripture.
//3. Versatile Reference Handling: The Reference class includes multiple constructors and logic to intelligently format the output, handling both single verses (e.g., "John 3:16") and verse ranges (e.g., "Proverbs 3:5-6") seamlessly.
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the ScriptureMemorizer Project.");
        Reference reference = new Reference("John", 3, 16);
        string scriptureText = "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life.";
        Scripture scripture = new Scripture(reference, scriptureText);
        string userInput = "";
        while (userInput.ToLower() != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.WriteLine("Press Enter to hide a word, or type 'quit' to exit.");
            userInput = Console.ReadLine();
            if (userInput.ToLower() != "quit")
            {
                scripture.HideRandomWord(3);
            }
        }
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("You did it! You have memorized the scripture. bye bye!");
    }
}
class Word
{
    private string _text;
    private bool _isHidden;
    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }
    public void Hide() => _isHidden = true;
    public void Show()
    {
        _isHidden = false;
    }
    public bool IsHidden()
    {
        return _isHidden;
    }
    public string GetDisplayText()
    {
        if (_isHidden)
        {
            return new string ('_', _text.Length);
        }
        else
        {
            return _text;
        }
    }

}
class Scripture
{
    private List<Word> _words = new List<Word>();
    private Reference _reference;

    public Scripture(Reference reference, string scriptureText)
    {
        // Logic for the first constructor that takes a reference and a string of scripture text
        _reference = reference;
        string[] splitwords = scriptureText.Split(' ');
        foreach(string word in splitwords)
        {
            _words.Add(new Word(word));
        }

    }
    public void HideRandomWord(int numberToHide)
    {
        // Logic to hide a random word from the _words list
        Random random = new Random();
        int hiddenCount = 0;
        while (hiddenCount < numberToHide && !IsCompletelyHidden())
        {
            int index = random.Next(_words.Count);
            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hiddenCount++;
            }
        }
    }
    public string GetDisplayText()
    {
        // Logic to get the display text of the scripture, showing hidden words as blanks
        string text = "";
        foreach (Word w in _words)
        {
            text += w.GetDisplayText() + " ";
        }
        return $"{_reference.GetDisplayText()} - {text.Trim()}";
    }
    public bool IsCompletelyHidden()
    {
        // Logic to check if all words in the scripture are hidden
        foreach (Word w in _words)
        {
            if (!w.IsHidden()) return false;
        }
        return true;
        
    }
}
class Reference
{
    private string _book;
    private int _chapter;
    private int _verse;
    private int _endVerse;

    public string GetDisplayText()
    {
        // Logic to return the reference as a string (e.g., "John 3:16-17")
        if (_verse == _endVerse)
        {
            return $"{_book} {_chapter}:{_verse}";
        }
        else
        {
            return $"{_book} {_chapter}:{_verse}-{_endVerse}";
        }
    }
    public Reference(string book, int chapter, int verse)
    {
        // Logic for the first constructor that takes book, chapter, and verse
        _book = book;
        _chapter = chapter;
        _verse = verse;
        _endVerse = verse;
    }
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        // Logic for the second constructor that takes book, chapter, startVerse, and endVerse
        _book = book;
        _chapter = chapter;
        _verse = startVerse;
        _endVerse = endVerse;
    }   
}