using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create the reference and scripture
            Reference reference = new Reference("John", 3, 16);
            string text = "For God so loved the world that he gave his only begotten Son that whosoever believeth in him should not perish but have everlasting life";
            
            Scripture scripture = new Scripture(reference, text);

            while (!scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                
                Console.WriteLine("\nPress enter to continue or type 'quit' to finish:");
                string input = Console.ReadLine();

                if (input.ToLower() == "quit")
                {
                    break;
                }

                // Hide 3 random words each time
                scripture.HideRandomWords(3);
            }

            // Show final state
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine("\nProgram ended.");
        }
    }
}
