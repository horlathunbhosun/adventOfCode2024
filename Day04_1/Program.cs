using System;
using System.IO;
using System.Linq;

var filePath = "/Users/olulodeolatunbosun/RiderProjects/AdventOfCode2024/Day04_1/input.txt";

var lines = File.ReadAllLines(filePath);

var result = 0;

var xmas = "XMAS";

var directions = new (int, int)[] 
{
    (0, 1),  // right
    (1, 0),  // down
    (1, 1),  // down-right
    (1, -1), // down-left
    (0, -1), // left
    (-1, 0), // up
    (-1, -1),// up-left
    (-1, 1)  // up-right
};

for (int i = 0; i < lines.Length; i++)
{
    for (int j = 0; j < lines[i].Length; j++)
    {
        foreach (var (dx, dy) in directions)
        {
            bool found = true;
            for (int k = 0; k < xmas.Length; k++)
            {
                int x = i + k * dx;
                int y = j + k * dy;
                if (x < 0 || x >= lines.Length || y < 0 || y >= lines[i].Length || lines[x][y] != xmas[k])
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                result++;
            }
        }
    }
}

Console.WriteLine(result);
