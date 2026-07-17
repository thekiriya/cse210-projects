using System;

namespace Develop04
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Mindfulness Program!");
            Console.WriteLine();
            
            bool exit = false;
            
            while (!exit)
            {
                Console.WriteLine("Please select an activity:");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. Exit");
                Console.Write("Your choice: ");
                
                string choice = Console.ReadLine();
                Console.WriteLine();
                
                MindfulnessActivity activity = null;
                
                switch (choice)
                {
                    case "1":
                        activity = new BreathingActivity();
                        break;
                    case "2":
                        activity = new ReflectionActivity();
                        break;
                    case "3":
                        activity = new ListingActivity();
                        break;
                    case "4":
                        exit = true;
                        continue;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        Console.WriteLine();
                        continue;
                }
                
                if (activity != null)
                {
                    activity.RunActivity();
                    Console.WriteLine();
                    Console.WriteLine("Press any key to return to menu...");
                    Console.ReadKey();
                    Console.Clear();
                }
            }
            
            Console.WriteLine("Thank you for using the Mindfulness Program. Have a peaceful day!");
        }
    }
}