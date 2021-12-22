// See https://aka.ms/new-console-template for more information

string[] dayOneInput = File.ReadAllLines("./Day01Input.txt");
var dayOnePuzzle = new Day01(dayOneInput);
Console.WriteLine($"Day 01 Part 01 Solution - {dayOnePuzzle.SolvePartOne()}");
Console.WriteLine($"Day 01 Part 02 Solution - {dayOnePuzzle.SolvePartTwo()}");
string[] dayTwoInput = File.ReadAllLines("./Day02Input.txt");
var dayTwoPuzzle = new Day02(dayTwoInput);
Console.WriteLine($"Day 02 Part 01 Solution - {dayTwoPuzzle.SolvePartOne()}");
Console.WriteLine($"Day 02 Part 02 Solution - {dayTwoPuzzle.SolvePartTwo()}");