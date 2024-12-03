using System.Text.RegularExpressions;

var filePath = "/Users/olulodeolatunbosun/RiderProjects/AdventOfCode2024/Day03_01/input.txt";

var lines = File.ReadAllLines(filePath);

var result = 0;

var regex = new Regex(@"mul\((\d+),(\d+)\)");

foreach (var line in lines)
{
    //Console.WriteLine(line);

    var parts = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    var matches = regex.Matches(line);
    foreach (Match match in matches)
    {
        if (int.TryParse(match.Groups[1].Value, out var num1 ) && int.TryParse(match.Groups[2].Value, out var num2))
        {
            result += num1 * num2;
        }
        
    }
}
Console.WriteLine(result);