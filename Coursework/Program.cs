using System;
using System.IO;
using System.Net.WebSockets;
using System.Security.Cryptography;
using System.Globalization;
using static CS0603.CubicFunction;
using static CS0603.StockAnalysis;
using static CS0603.MonthAnalysis;

namespace CS0603;

class Program
{
    static void Main(string[] args)
    {
        string userChoice = "";

        // loop until user selects option 3 (exit)
        while (userChoice != "3")
        {
            Console.WriteLine("\nMain Menu");
            Console.WriteLine("1. Find the Minimum/Maximum of a cubic Function");
            Console.WriteLine("2. Stock Analysis");
            Console.WriteLine("3. Exit");
            Console.WriteLine("Enter your choice: ");
            userChoice = Console.ReadLine();

            // checlk which option the user picked
            if (userChoice == "1")
            {
                FindCubicMinMax();
                Console.WriteLine("Press enter to return to the menu");
                Console.ReadLine();
            }
            else if (userChoice == "2")
            {
                StockYearlyAnalysis();
                ShowMonthlySubmenu();
                Console.WriteLine("Press enter to return to the menu");
                Console.ReadLine();
            }
            else if (userChoice == "3")
            {
                Console.WriteLine("\nExiting the Program...");
            }
            else
            {
                Console.WriteLine("\n Invalid input. Please select 1, 2, or 3");
                Console.WriteLine("Press enter to return to the menu");
                Console.ReadLine();
            }
        }
    }
}




