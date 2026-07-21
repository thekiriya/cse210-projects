// Program.cs
using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        //  list to hold videos
        List<Video> videos = new List<Video>();

        // vid 1
        Video video1 = new Video("Python Tutorial", "TechGuru", 1800);
        video1.AddComment(new Comment("Alice", "Great video!"));
        video1.AddComment(new Comment("Bob", "Very helpful"));
        video1.AddComment(new Comment("Carol", "Thanks!"));
        videos.Add(video1);

        // vid 2
        Video video2 = new Video("Pasta Recipe", "ChefMaria", 320);
        video2.AddComment(new Comment("Dave", "Yummy!"));
        video2.AddComment(new Comment("Eve", "Trying this tonight"));
        video2.AddComment(new Comment("Frank", "Delicious"));
        videos.Add(video2);

        // vid 3
        Video video3 = new Video("Boss Fight", "GamingPro", 245);
        video3.AddComment(new Comment("Grace", "Amazing!"));
        video3.AddComment(new Comment("Henry", "How did you do that?"));
        video3.AddComment(new Comment("Ivy", "Wow!"));
        videos.Add(video3);

        // === CREATE VIDEO 4 ===
        Video video4 = new Video("Science Experiments", "ScienceMom", 600);
        video4.AddComment(new Comment("Jack", "So cool!"));
        video4.AddComment(new Comment("Karen", "My kids loved this"));
        video4.AddComment(new Comment("Leo", "We tried it at home"));
        videos.Add(video4);

        // display vids
        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.LengthSeconds} seconds");
            Console.WriteLine($"Comments: {video.GetCommentCount()}");
            
            foreach (Comment comment in video.GetComments())
            {
                Console.WriteLine($"  {comment.CommenterName}: {comment.Text}");
            }
            Console.WriteLine();
        }
    }
}