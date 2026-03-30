using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
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
            Console.WriteLine($"{comment.GetDisplayText()}");
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