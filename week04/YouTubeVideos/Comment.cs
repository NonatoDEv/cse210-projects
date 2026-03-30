using System;
using System.Collections.Generic;
public class Comment
{
    //once again put only the attributes
    private string _name;
    private string _text;
    //put the constructor
    public Comment(string name, string text)
    {
        _name = name;
        _text = text;
    }
    //put the methods
    public string GetDisplayText()
    {
        return $"{_name}: {_text}";
    }
}