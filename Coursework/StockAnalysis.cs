using System;
using System.Diagnostics.Contracts;

namespace CS0603;

public static class StockAnalysis
{
    public static void StockYearlyAnalysis()
    {
        string filePath = "AMD.csv";

        if (!File.Exists(filePath))
        {
            Console.WriteLine("CSV file not found. Make sure AMD.csv is in the right folder.");
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

        for (int i = 1; i < lines.Length; i++)
        {
            string line = lines[i];
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(',');

            if (parts.Length < 6) continue;

            double open, high, low, close;
            long volume;

            if (!double.TryParse(parts[1], out open)) open = 0;
            if (!double.TryParse(parts[2], out high)) high = 0;
            if (!double.TryParse(parts[3], out low)) low = 0;
            if (!double.TryParse(parts[4], out close)) close = 0;
            if (!long.TryParse(parts[5], out volume)) volume = 0;

            if (i == 1) openingPrice = open;
            closingPrice = close;

            totalHigh += high;
            totalLow += low;
            count++;

            if (volume > maxVolume)
            {
                maxVolume = volume;
                highestVolumeDate = parts[0];
            }
        }

        double avgHigh = count > 0 ? totalHigh / count : 0;
        double avgLow = count > 0 ? totalLow / count : 0;

        Console.WriteLine("\nYearly Stock Summary:");
        Console.WriteLine($"Opening Price: {openingPrice:F2}");
        Console.WriteLine($"Closing Price: {closingPrice:F2}");
        Console.WriteLine($"Average High Price: {avgHigh:F2}");
        Console.WriteLine($"Average Low Price: {avgLow:F2}");
        Console.WriteLine($"Highest Volume Day: {highestVolumeDate}");

        Console.WriteLine("Press Enter to return...");
        Console.ReadLine(); 

        Console.WriteLine("\nYearly Stock Summary:");
        Console.WriteLine($"Opening Price: {openingPrice:F2}");
        Console.WriteLine($"Closing Price: {closingPrice:F2}");
        Console.WriteLine($"Average High Price: {avgHigh:F2}");
        Console.WriteLine($"Average Low Price: {avgLow:F2}");
        Console.WriteLine($"Highest Volume Day: {highestVolumeDate}");

        Console.WriteLine("Press Enter to return...");
        Console.ReadLine();
    }
}