using System;
using System.Collections.Generic;
using System.Threading;

namespace Develop04
{
    // Listing Activity class
    public class ListingActivity : MindfulnessActivity
    {
        private List<string> _prompts;
        private Random _random;
        
        public ListingActivity() : base("Listing", 
            "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
        {
            _random = new Random();
            
            _prompts = new List<string>
            {
                "Who are people that you appreciate?",
                "What are personal strengths of yours?",
                "Who are people that you have helped this week?",
                "When have you felt the Holy Ghost this month?",
                "Who are some of your personal heroes?"
            };
        }
        
        public override void RunActivity()
        {
            DisplayStartingMessage();
            
            // Select random prompt
            string prompt = _prompts[_random.Next(_prompts.Count)];
            Console.WriteLine($"List as many responses as you can to the following prompt:");
            Console.WriteLine($"--- {prompt} ---");
            Console.WriteLine();
            Console.Write("You have a few seconds to think... ");
            ShowCountdown(5);
            Console.WriteLine();
            Console.WriteLine("Start listing items (press Enter after each item, type 'done' when finished):");
            Console.WriteLine();
            
            List<string> items = new List<string>();
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            
            while (DateTime.Now < endTime)
            {
                Console.Write("> ");
                string input = Console.ReadLine();
                
                if (input.ToLower() == "done")
                    break;
                    
                if (!string.IsNullOrWhiteSpace(input))
                {
                    items.Add(input);
                }
            }
            
            Console.WriteLine();
            Console.WriteLine($"You listed {items.Count} items!");
            
            DisplayEndingMessage();
        }
    }
}