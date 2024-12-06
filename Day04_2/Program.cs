
var filePath = "/Users/olulodeolatunbosun/RiderProjects/AdventOfCode2024/Day04_2/input.txt";

var lines = File.ReadAllLines(filePath);

var result = 0;

var mas = "MAS";


var directions = new (int, int)[]
{
    (1, 1),  // down-right
    (1, -1), // down-left
    (-1, 1), // up-right
    (-1, -1) // up-left
};

bool[,] visited = new bool[lines.Length, lines[0].Length];

for (int i = 0; i < lines.Length - 2 ; i++)
{
    for (int j = 0; j < lines[i].Length - 2; j++)
    {
        foreach (var (dx, dy) in directions)
        {
            bool found = true;
            for (int k = 0; k < mas.Length; k++)
            {
                int x = i + k * dx;
                int y = j + k * dy;
                if (x < 0 || x >= lines.Length || y < 0 || y >= lines[i].Length || lines[x][y] != mas[k] || visited[x, y])
                {
                    found = false;
                    break;
                }
            }
            if (found)
            {
                for (int k = 0; k < mas.Length; k++)
                {
                    int x = i + k * dx;
                    int y = j + k * dy;
                    visited[x, y] = true;
                }
                result++;
            }
        }
    }
}
Console.WriteLine(result);