using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        List<Video> videoList = new List<Video>();
        // --- Video 1 ---
        Video v1 = new Video("C# for Beginners", "Tech Academy", 600);
        v1.AddComment(new Comment("Abel", "This is like Russian Dolls!"));
        v1.AddComment(new Comment("Maria", "Great explanation of OOP."));
        v1.AddComment(new Comment("BroReading", "Clean code is happy code."));
        videoList.Add(v1);
        // --- Video 2 ---
        Video v2 = new Video("Osaka Food Tour", "Japan Travel", 1200); 
        v2.AddComment(new Comment("Pikachu", "Pika pika! (Delicious!)"));
        v2.AddComment(new Comment("Ash", "Need to catch all these recipes."));
        v2.AddComment(new Comment("Brock", "The ramen looks amazing."));
        videoList.Add(v2);
        // --- Video 3 ---
        Video v3 = new Video("How to build a Pokedex", "Code Masters", 900);
        v3.AddComment(new Comment("Oak", "A great resource for trainers."));
        v3.AddComment(new Comment("Gary", "I could do it faster, but it's okay."));
        v3.AddComment(new Comment("Misty", "Finally a good tutorial."));
        videoList.Add(v3);
        Console.WriteLine("Youtube Monitoring Report");
        foreach(Video video in videoList)
        {
            video.DisplayInfo();
        }
    }
}
class Video
{
    //only put the attributes
    private string _title;
    private string _author;
    private int _videoLength;
    //only puts the constructor
    private List<Comment> _videoComments = new List<Comment>();
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _videoLength = length;
    }
    //only put the methods
    public void AddComment(Comment comment){
        _videoComments.Add(comment);
    }
    public int GetCommentCount(){
        return _videoComments.Count;
    }
    public void DisplayInfo(){
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_videoLength}");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        foreach(Comment comment in _videoComments)
        {
            Console.WriteLine($"DEBUG -> Contenido: {comment.GetDisplayText()}");
        }
    }
}
class Comment
{
    //once again put only the attributes
    private string _commenterName;
    private string _commentText;
    //put the constructor
    public Comment(string name, string text)
    {
        _commenterName = name;
        _commentText = text;
    }
    //put the methods
    public string GetDisplayText()
    {
        return $"{_commenterName}: {_commentText}";
    }
}