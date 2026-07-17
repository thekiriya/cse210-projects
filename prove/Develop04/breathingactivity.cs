using System;
using System.Threading;

namespace Develop04
{
    // Breathing Activity class
    public class BreathingActivity : MindfulnessActivity
    {
        public BreathingActivity() : base("Breathing", 
            "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
        {
        }
        
        public override void RunActivity()
        {
            DisplayStartingMessage();
            
            DateTime endTime = DateTime.Now.AddSeconds(Duration);
            while (DateTime.Now < endTime)
            {
                Console.Write("Breathe in...");
                ShowCountdown(4);
                Console.WriteLine();
                
                if (DateTime.Now >= endTime) break;
                
                Console.Write("Breathe out...");
                ShowCountdown(4);
                Console.WriteLine();
                Console.WriteLine();
            }
            
            DisplayEndingMessage();
        }
    }
}