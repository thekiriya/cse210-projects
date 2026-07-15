using System;

class Program
{
    static void Main(string[] args)
    {
        // Test Constructor 1: No parameters (defaults to 1/1)
        Fraction fraction1 = new Fraction();
        Console.WriteLine(fraction1.GetFractionString());  // Output: 1/1
        Console.WriteLine(fraction1.GetDecimalValue());    // Output: 1

        // Test Constructor 2: One parameter (top only, bottom = 1)
        Fraction fraction2 = new Fraction(5);
        Console.WriteLine(fraction2.GetFractionString());  // Output: 5/1
        Console.WriteLine(fraction2.GetDecimalValue());    // Output: 5

        // Test Constructor 3: Two parameters (top and bottom)
        Fraction fraction3 = new Fraction(3, 4);
        Console.WriteLine(fraction3.GetFractionString());  // Output: 3/4
        Console.WriteLine(fraction3.GetDecimalValue());    // Output: 0.75

        // Test with 1/3
        Fraction fraction4 = new Fraction(1, 3);
        Console.WriteLine(fraction4.GetFractionString());  // Output: 1/3
        Console.WriteLine(fraction4.GetDecimalValue());    // Output: 0.3333333333333333

        // Test getters and setters
        Console.WriteLine("\nTesting Getters and Setters:");
        Fraction fraction5 = new Fraction(2, 3);
        Console.WriteLine($"Before: {fraction5.GetFractionString()}");  // Output: 2/3
        
        fraction5.SetTop(4);
        fraction5.SetBottom(5);
        Console.WriteLine($"After: {fraction5.GetFractionString()}");   // Output: 4/5
        Console.WriteLine($"Top: {fraction5.GetTop()}");                 // Output: 4
        Console.WriteLine($"Bottom: {fraction5.GetBottom()}");           // Output: 5
    }
}