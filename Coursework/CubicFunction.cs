using System;
using System.Diagnostics.Contracts;

namespace CS0603;

public static class CubicFunction
{
    public static void FindCubicMinMax()

    {
        double a = 0, b = 0, c = 0, d = 0;

        Console.WriteLine("\nEnter coefficient a (not zero): ");
        while (!double.TryParse(Console.ReadLine(), out a) || a == 0)
        {
            Console.WriteLine("Invalid input. a must be a non-zero number. Try again: ");
        }

        Console.WriteLine("Enter coefficient b:");
        double.TryParse(Console.ReadLine(), out b);

        Console.WriteLine("Enter coefficient c:");
        double.TryParse(Console.ReadLine(), out c);

        Console.WriteLine("Enter coefficient d:");
        double.TryParse(Console.ReadLine(), out d);

        // Calculate the discriminant of f'(x)
        double A = 3 * a;
        double B = 2 * b;
        double discriminant = (B * B) - (4 * A * c);

        if (discriminant < 0)
        {
            Console.WriteLine("\nNo minimum/maximum can be found.");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
            return;
        }

        double sqrtDiscriminant = Math.Sqrt(discriminant);

        // Two roots of f'(x)
        double x1 = (-B + sqrtDiscriminant) / (2 * A);
        double x2 = (-B - sqrtDiscriminant) / (2 * A);

        // Function to evaluate f(x) 
        double f(double x) => a * x * x * x + b * x * x + c * x + d;

        // Function to evaluate f''(x)
        double secondDerivative(double x) => 6 * a * x + 2 * b;

        // For each root, classify it
        void classify(double x)
        {
            double fValue = f(x);
            double f2 = secondDerivative(x);

            if (f2 > 0)
                Console.WriteLine($"Minimum at x = {x:F2}, f(x) = {fValue:F2}");

            else if (f2 < 0)
                Console.WriteLine($"Maximum at x = {x:F2}, f(x) = {fValue:F2}");

            else
                Console.WriteLine($"x = {x:F2} might be an inflection point.");
        }

        Console.WriteLine("\nResult");
        classify(x1);


        // Check if there are 2 unique roots
        if (discriminant > 0 && Math.Abs(x1 - x2) > 0.0001)
        {
            classify(x2);
        }

        Console.WriteLine("Press enter to return to the menu");
        Console.ReadLine();
    }
}
