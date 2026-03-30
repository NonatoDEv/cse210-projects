using System;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello World! This is the YouTubeVideos Project.");
        List<Video> videos = new List<Video>();
        // --- Video 1 ---
        Video v1 = new Video("C# for Beginners", "Tech Academy", 600);
        v1.AddComment(new Comment("Abel", "This is like Russian Dolls!"));
        v1.AddComment(new Comment("Maria", "Great explanation of OOP."));
        v1.AddComment(new Comment("BroReading", "Clean code is happy code."));
        videos.Add(v1);
        // --- Video 2 ---
        Video v2 = new Video("Osaka Food Tour", "Japan Travel", 1200); 
        v2.AddComment(new Comment("Pikachu", "Pika pika! (Delicious!)"));
        v2.AddComment(new Comment("Ash", "Need to catch all these recipes."));
        v2.AddComment(new Comment("Brock", "The ramen looks amazing."));
        videos.Add(v2);
        // --- Video 3 ---
        Video v3 = new Video("How to build a Pokedex", "Code Masters", 900);
        v3.AddComment(new Comment("Oak", "A great resource for trainers."));
        v3.AddComment(new Comment("Gary", "I could do it faster, but it's okay."));
        v3.AddComment(new Comment("Misty", "Finally a good tutorial."));
        videos.Add(v3);
        Console.WriteLine("Youtube Monitoring Report");
        foreach(Video video in videos)
        {
            video.DisplayVideoDetails();
        }
    }
}