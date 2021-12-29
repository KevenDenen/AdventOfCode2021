﻿//string[] dayOneInput = File.ReadAllLines("./Day01Input.txt");
//var dayOnePuzzle = new Day01(dayOneInput);
//Console.WriteLine($"Day 01 Part 01 Solution - {dayOnePuzzle.SolvePartOne()}");
//Console.WriteLine($"Day 01 Part 02 Solution - {dayOnePuzzle.SolvePartTwo()}");
//string[] dayTwoInput = File.ReadAllLines("./Day02Input.txt");
//var dayTwoPuzzle = new Day02(dayTwoInput);
//Console.WriteLine($"Day 02 Part 01 Solution - {dayTwoPuzzle.SolvePartOne()}");
//Console.WriteLine($"Day 02 Part 02 Solution - {dayTwoPuzzle.SolvePartTwo()}");
//string[] dayThreeInput = File.ReadAllLines("./Day03Input.txt");
//var dayThreePuzzle = new Day03(dayThreeInput);
//Console.WriteLine($"Day 03 Part 01 Solution - {dayThreePuzzle.SolvePartOne()}");
//Console.WriteLine($"Day 03 Part 02 Solution - {dayThreePuzzle.SolvePartTwo()}");
//string daySixInput = File.ReadAllText("./Day06Input.txt");
//var daySixPuzzle = new Day06();
//Console.WriteLine($"Day 06 Part 01 Solution - {daySixPuzzle.SolvePartOne(daySixInput)}");
//Console.WriteLine($"Day 06 Part 02 Solution - {daySixPuzzle.SolvePartTwo(daySixInput)}");
//string daySevenInput = File.ReadAllText("./Day07Input.txt");
//var daySevenPuzzle = new Day07(daySevenInput);
//Console.WriteLine($"Day 07 Part 01 Solution - {daySevenPuzzle.SolvePartOne()}");
//Console.WriteLine($"Day 07 Part 02 Solution - {daySevenPuzzle.SolvePartTwo()}");
//string dayEightTestInput = "acedgfb cdfbe gcdfa fbcad dab cefabd cdfgeb eafb cagedb ab |cdfeb fcadb cdfeb cdbaf";
//string dayEightInput = File.ReadAllText("./Day08Input.txt");
//var dayEightPuzzle = new Day08(dayEightInput);
//Console.WriteLine($"Day 08 Part 01 Solution - {dayEightPuzzle.SolvePartOne()}");
//Console.WriteLine($"Day 08 Part 02 Solution - {dayEightPuzzle.SolvePartTwo()}");
//string dayNineInput = File.ReadAllText("./Day09Input.txt");
//var dayNinePuzzle = new Day09(dayNineInput);
//Console.WriteLine($"Day 09 Part 01 Solution - {dayNinePuzzle.SolvePartOne()}");
//Console.WriteLine($"Day 09 Part 02 Solution - {dayNinePuzzle.SolvePartTwo()}");
//var dayElevenInput = File.ReadAllLines("./Day11Input.txt");
//var dayElevenPuzzle = new Day11(dayElevenInput);
//Console.WriteLine($"Day 11 Part 01 Solution - {dayElevenPuzzle.SolvePartOne()}");
//dayElevenPuzzle = new Day11(dayElevenInput);
//Console.WriteLine($"Day 11 Part 02 Solution - {dayElevenPuzzle.SolvePartTwo()}");
var dayThirteenTestInput = @"6,10
0,14
9,10
0,3
10,4
4,11
6,0
6,12
4,1
0,13
10,12
3,4
3,0
8,4
1,10
2,14
8,10
9,0

fold along y=7
fold along x=5".Split(Environment.NewLine);
var dayThirteenTestPuzzle = new Day13(dayThirteenTestInput);
var dayThirteenInput = File.ReadAllLines("./Day13Input.txt");
var dayThirteenPuzzle = new Day13(dayThirteenInput);
Console.WriteLine($"Day 13 Part 01 Solution - {dayThirteenPuzzle.SolvePartOne()}");
Console.WriteLine($"Day 13 Part 02 Solution - {dayThirteenPuzzle.SolvePartTwo()}");
