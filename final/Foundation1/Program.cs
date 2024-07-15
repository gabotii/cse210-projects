using System;
using System.Collections.Generic;

public class Video
{
    private string title;
    private string author;
    private int length;
    private List<Comment> comments;

    public Video(string title, string author, int length)
    {
        this.title = title;
        this.author = author;
        this.length = length;
        this.comments = new List<Comment>();
    }

    public void AddComment(Comment comment)
    {
        comments.Add(comment);
    }

    public int GetNumberOfComments()
    {
        return comments.Count;
    }

    public void DisplayInfo()
    {
        Console.WriteLine($"Title: {title}");
        Console.WriteLine($"Author: {author}");
        Console.WriteLine($"Length: {length} seconds");
        Console.WriteLine($"Number of Comments: {GetNumberOfComments()}");
        Console.WriteLine("Comments:");
        foreach (var comment in comments)
        {
            Console.WriteLine($"\t{comment.CommenterName}: {comment.Text}");
        }
    }
}

public class Comment
{
    public string CommenterName { get; private set; }
    public string Text { get; private set; }

    public Comment(string commenterName, string text)
    {
        CommenterName = commenterName;
        Text = text;
    }
}

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("Cool Cats Compilation", "CatLover123", 120);
        video1.AddComment(new Comment("JohnDoe", "This is so funny!"));
        video1.AddComment(new Comment("JaneSmith", "Loved it!"));
        video1.AddComment(new Comment("CoolCatFan", "Can't stop watching this."));

        Video video2 = new Video("Top 10 Programming Tips", "CodeMaster", 300);
        video2.AddComment(new Comment("DevDude", "Great tips! Thanks."));
        video2.AddComment(new Comment("ProgrammerGal", "Very useful information."));
        video2.AddComment(new Comment("CodeNewbie", "This helped me a lot."));

        Video video3 = new Video("Travel Vlog: Japan", "WorldTraveler", 450);
        video3.AddComment(new Comment("Traveler1", "Beautiful places!"));
        video3.AddComment(new Comment("TravelFan", "I want to go to Japan now."));
        video3.AddComment(new Comment("AdventureSeeker", "Great vlog!"));

        List<Video> videos = new List<Video> { video1, video2, video3 };

        foreach (var video in videos)
        {
            video.DisplayInfo();
            Console.WriteLine();
        }
    }
}