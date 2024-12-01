
var list1 = new List<int>();

var list2 = new List<int>();

var filePath = "/Users/olulodeolatunbosun/RiderProjects/AdventOfCode2024/Day01_1/input.txt";

var lines = File.ReadAllLines(filePath);

foreach (var line in lines )
{
    
    var part = line.Split(" ", StringSplitOptions.RemoveEmptyEntries);
    if (int.TryParse(part[0], out var number ))
    {
        list1.Add(number);
    }
    
    if (int.TryParse(part[1], out var number2 ))
    {
        list2.Add(number2);
    }
    
    list1.Sort();
    list2.Sort();
    
    var addtionDiff = 0;
    for (int i = 0; i < list1.Count; i++)
    {
        addtionDiff += Math.Abs(list1[i] - list2[i]);
    }
    Console.WriteLine(addtionDiff);
}