using System;
using System.Threading;

namespace Develop04
{
    // Base class for all mindfulness activities
    public abstract class MindfulnessActivity
    {
        private string _name;
        private string _description;
        private int _duration;
        
        
        public string Name 
        { 
            get { return _name; }
            private set { _name = value; }
        }
        
        public string Description 
        { 
            get { return _description; }
            private set { _description = value; }
        }
        
        public int Duration 
        { 
            get { return _duration; }
            private set { _duration = value; }
        }
        
        // Constructor
        public MindfulnessActivity(string name, string description)
        {
            Name = name;
            Description = description;
        }
        
        
        public void DisplayStartingMessage()
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the {Name} Activity");
            Console.WriteLine();
            Console.WriteLine(Description);
            Console.WriteLine();
            
            Console.Write("How many seconds would you like your activity to last? ");
            Duration = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            Console.WriteLine("Get ready to begin...");
            ShowSpinner(3);
        }
        
       
        public void DisplayEndingMessage()
        {
            Console.WriteLine();
            Console.WriteLine("Good job! You've completed the activity.");
            ShowSpinner(2);
            Console.WriteLine();
            Console.WriteLine($"You completed the {Name} Activity for {Duration} seconds.");
            ShowSpinner(3);
        }
        
        
        public void ShowSpinner(int seconds)
        {
            string[] spinnerChars = { "|", "/", "-", "\\" };
            int spinnerIndex = 0;
            DateTime endTime = DateTime.Now.AddSeconds(seconds);
            
            while (DateTime.Now < endTime)
            {
                Console.Write(spinnerChars[spinnerIndex % spinnerChars.Length]);
                Thread.Sleep(200);
                Console.Write("\b");
                spinnerIndex++;
            }
        }
        
        
        public void ShowCountdown(int seconds)
        {
            for (int i = seconds; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }
        
        
        public abstract void RunActivity();
    }
}