using System;
using System.Collections.Generic;
using System.IO;

var filePath = "/Users/olulodeolatunbosun/RiderProjects/AdventOfCode2024/Day02_2/input.txt";

var lines = File.ReadAllLines(filePath);

var safeReports = 0;

foreach (var line in lines)
{
    var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    var levels = new List<int>();
    foreach (var part in parts)
    {
        if (int.TryParse(part, out var level))
        {
            levels.Add(level);
        }
    }
    
    
    if (levels.Count < 2)
    {
        continue;
    }
    
    bool IsSafe(List<int> levels)
    {
        var isIncreasing = levels[0] < levels[1];
        for (int i = 0; i < levels.Count - 1; i++)
        {
            var diff = levels[i + 1] - levels[i];
            if (Math.Abs(diff) > 3 || diff == 0 || (isIncreasing && diff < 0) || (!isIncreasing && diff > 0))
            {
                return false;
            }
        }
        return true;
    }
    
    if (IsSafe(levels))
    {
        safeReports++;
    }
    else
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var tempLevels = new List<int>(levels);
            tempLevels.RemoveAt(i);
            if (IsSafe(tempLevels))
            {
                safeReports++;
                break;
            }
        }
    }
}

Console.WriteLine(safeReports);