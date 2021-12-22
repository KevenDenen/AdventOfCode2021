// See https://aka.ms/new-console-template for more information

string[] dayOneInput = File.ReadAllLines("./Day01Input.txt");
var dayOnePuzzle = new Day01(dayOneInput);
Console.WriteLine($"Day 01 Part 01 Solution - {dayOnePuzzle.SolvePartOne()}");
Console.WriteLine($"Day 01 Part 02 Solution - {dayOnePuzzle.SolvePartTwo()}");
