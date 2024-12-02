// --- Part Two ---
//     The engineers are surprised by the low number of safe reports until they realize they forgot to tell you about the Problem Dampener.
//
//     The Problem Dampener is a reactor-mounted module that lets the reactor safety systems tolerate a single bad level in what would otherwise be a safe report. It's like the bad level never happened!
//
//     Now, the same rules apply as before, except if removing a single level from an unsafe report would make it safe, the report instead counts as safe.
//
//     More of the above example's reports are now safe:
//
// 7 6 4 2 1: Safe without removing any level.
// 1 2 7 8 9: Unsafe regardless of which level is removed.
// 9 7 6 2 1: Unsafe regardless of which level is removed.
// 1 3 2 4 5: Safe by removing the second level, 3.
// 8 6 4 4 1: Safe by removing the third level, 4.
// 1 3 6 7 9: Safe without removing any level.
//     Thanks to the Problem Dampener, 4 reports are actually safe!
//
//     Update your analysis by handling situations where the Problem Dampener can remove a single level from unsafe reports. How many reports are now safe?

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