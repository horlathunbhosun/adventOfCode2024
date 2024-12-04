// --- Day 4: Ceres Search ---
//     "Looks like the Chief's not here. Next!" One of The Historians pulls out a device and pushes the only button on it. After a brief flash, you recognize the interior of the Ceres monitoring station!
//
//     As the search for the Chief continues, a small Elf who lives on the station tugs on your shirt; she'd like to know if you could help her with her word search (your puzzle input). She only has to find one word: XMAS.
//
//     This word search allows words to be horizontal, vertical, diagonal, written backwards, or even overlapping other words. It's a little unusual, though, as you don't merely need to find one instance of XMAS - you need to find all of them. Here are a few ways XMAS might appear, where irrelevant characters have been replaced with .:
//
//
// ..X...
//     .SAMX.
//     .A..A.
//     XMAS.S
//     .X....
//     The actual word search will be full of letters instead. For example:
//
// MMMSXXMASM
//     MSAMXMSMSA
// AMXSXMAAMM
//     MSAMASMSMX
// XMASAMXAMM
//     XXAMMXXAMA
// SMSMSASXSS
//     SAXAMASAAA
// MAMMMXMMMM
//     MXMXAXMASX
// In this word search, XMAS occurs a total of 18 times; here's the same word search again, but where letters not involved in any XMAS have been replaced with .:
//
// ....XXMAS.
//     .SAMXMS...
// ...S..A...
// ..A.A.MS.X
// XMASAMX.MM
// X.....XA.A
// S.S.S.S.SS
//         .A.A.A.A.A
//     ..M.M.M.MM
//         .X.X.XMASX
// Take a look at the little Elf's word search. How many times does XMAS appear?


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

// for (int i = 0; i < lines.Length; i++)
// {
//     var line = lines[i];
//     for (int j = 0; j < line.Length; j++)
//     {
//         if (line[j] == 'X')
//         {
//             if (j + 4 < line.Length && line[j + 1] == 'M' && line[j + 2] == 'A' && line[j + 3] == 'S')
//             {
//                 result++;
//             }
//         }
//     }
// }
//
// Console.WriteLine(result);