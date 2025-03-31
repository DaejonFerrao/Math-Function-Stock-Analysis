using System;
using System.Diagnostics.Contracts;

namespace CS0603;

public static class MonthAnalysis
{
    public static void AnalyzeMonth(string monthCode, string monthName)
    {
        string filePath = "AMD.csv";
        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found.");
            Console.WriteLine("Press enter to return to the menu");
            Console.ReadLine();
            return;
        }

        string[] lines = File.ReadAllLines(filePath);
        double openingPrice = 0;
        double closingPrice = 0;

        double totalHigh = 0;
        double totalLow = 0;
        int count = 0;

        long maxVolume = 0;
        string highestVolumeDate = "";

        bool firstMatchFound = false;

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');

            if (parts.Length < 6) continue;

            string date = parts[0];
            DateTime dateValue;

            if (!DateTime.TryParseExact(date, "dd/MM/yyyy", null, System.Globalization.DateTimeStyles.None, out dateValue))
                continue;

            if (dateValue.Month != int.Parse(monthCode))
                continue;

            double open, high, low, close;
            long volume;

            if (!double.TryParse(parts[1], out open)) open = 0;
            if (!double.TryParse(parts[2], out high)) high = 0;
            if (!double.TryParse(parts[3], out low)) low = 0;
            if (!double.TryParse(parts[4], out close)) close = 0;
            if (!long.TryParse(parts[5], out volume)) volume = 0;

            if (!firstMatchFound)
            {
                openingPrice = open;
                firstMatchFound = true;
            }

            closingPrice = close;

            totalHigh += high;
            totalLow += low;
            count++;

            if (volume > maxVolume)
            {
                maxVolume = volume;
                highestVolumeDate = date;
            }
        }

        if (count == 0)
        {
            Console.WriteLine($"No data found for {monthName}.");
        }
        else
        {
            double avgHigh = totalHigh / count;
            double avgLow = totalLow / count;

            Console.WriteLine($"\n{monthName} Stock Summary:");
            Console.WriteLine($"Opening Price: {openingPrice:F2}");
            Console.WriteLine($"Closing Price: {closingPrice:F2}");
            Console.WriteLine($"Average High: {avgHigh:F2}");
            Console.WriteLine($"Average Low: {avgLow:F2}");
            Console.WriteLine($"Highest Volume Day: {highestVolumeDate}");
        }

        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }
    public static void ShowMonthlySubmenu()
    {
        string choice = "";

        while (choice != "3")
        {
            Console.WriteLine("\nMonthly Stock Summary");
            Console.WriteLine("1. January");
            Console.WriteLine("2. May");
            Console.WriteLine("3. December");
            Console.WriteLine("4. Back to Main Menu");
            Console.WriteLine("Enter your choice:");
            choice = Console.ReadLine();

            if (choice == "1")
                AnalyzeMonth("1", "January");
            else if (choice == "2")
                AnalyzeMonth("5", "May");
            else if (choice == "3")
                AnalyzeMonth("12", "December");
            else if (choice == "4")
                Console.WriteLine("Returning to main menu...");
            else
                Console.WriteLine("Invalid input. Try again.");
        }
    }
}