var list1 = new List<int>();
var list2 = new List<int>();

var count2 = new Dictionary<int, int>();

var filePath = "/Users/olulodeolatunbosun/RiderProjects/AdventOfCode2024/Day01_2/input.txt";

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
        
        count2[number2] = count2.ContainsKey(number2) ? count2[number2] + 1 : 1;
    }
    
    var addtion = 0;
    
    for (int i = 0; i < list1.Count; i++)
    {
        if (count2.ContainsKey(list1[i]))
        {
            addtion += list1[i] * count2[list1[i]];
        }
    }
    
    
    Console.WriteLine(addtion);
    //Console.ReadKey();

}