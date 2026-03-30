using System;
using System.Collections.Generic;
public class Video
{
    //only put the attributes
    private string _title;
    private string _author;
    private int _length;
    //only puts the constructor
    private List<Comment> _comments = new List<Comment>();
    public Video(string title, string author, int length)
    {
        _title = title;
        _author = author;
        _length = length;
    }
    //only put the methods
    public void AddComment(Comment comment){
        _comments.Add(comment);
    }
    public int GetCommentCount(){
        return _comments.Count;
    }
    public void DisplayVideoDetails(){
        Console.WriteLine($"Title: {_title}");
        Console.WriteLine($"Author: {_author}");
        Console.WriteLine($"Length: {_length}");
        Console.WriteLine($"Number of Comments: {GetCommentCount()}");
        foreach(Comment comment in _comments)
        {
            Console.WriteLine(comment.GetDisplayText());
            Console.WriteLine();
        }
    }
}