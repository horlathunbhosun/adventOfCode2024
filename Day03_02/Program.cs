using System.Text.RegularExpressions;

var filePath = "/Users/olulodeolatunbosun/RiderProjects/AdventOfCode2024/Day03_02/input.txt";

var input = File.ReadAllText(filePath);

string pattern = @"mul\((\d+),(\d+)\)|do\(\)|don't\(\)";
var matches = Regex.Matches(input, pattern);
bool mulEnabled = true; 
int totalSum = 0;
foreach (Match match in matches)
{
    if (match.Groups[0].Value == "do()")
    {
        mulEnabled = true;
    }
    else if (match.Groups[0].Value == "don't()")
    {
        mulEnabled = false;
    }
    else if (int.TryParse(match.Groups[1].Value, out var num1 ) && int.TryParse(match.Groups[2].Value, out var num2))
    {
        if (mulEnabled)
        {
            totalSum += num1 * num2;
        }
    }
}

Console.WriteLine(totalSum);    






