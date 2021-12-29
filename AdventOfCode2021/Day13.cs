internal class Day13
{
  private List<DotLocation> dotLocations;
  private List<FoldLine> foldLines;

  public Day13(string[] dayThirteenTestInput)
  {
    dotLocations = new();
    foldLines = new();

    foreach (string line in dayThirteenTestInput)
    {
      if (line.Contains("fold"))
      {
        var direction = char.Parse(line.Substring(line.IndexOf('=') - 1, 1));
        var lineNumber = int.Parse(line[(line.IndexOf('=') + 1)..]);
        foldLines.Add(new FoldLine(direction, lineNumber));
      }
      else if (!string.IsNullOrWhiteSpace(line))
      {
        dotLocations.Add(new DotLocation(int.Parse(line.Split(',')[0]), int.Parse(line.Split(',')[1])));
      }
    }
  }

  public int SolvePartOne()
  {
    (int, int) dimensionsPreFold = FindDimensions();
    (int, int) dimensionsPostFold = (0, 0);

    var fold = foldLines.First();
    if (fold.Direction == 'x')
    {
      dimensionsPostFold.Item1 = (dimensionsPreFold.Item1 - 1) / 2;
      dimensionsPostFold.Item2 = dimensionsPreFold.Item2;
    }
    else
    {
      dimensionsPostFold.Item1 = dimensionsPreFold.Item1;
      dimensionsPostFold.Item2 = (dimensionsPreFold.Item2 - 1) / 2;
    }
    var afterFold = new bool[dimensionsPostFold.Item2, dimensionsPostFold.Item1];
    if (fold.Direction == 'x')
    {
      for (int x = 0; x < dimensionsPostFold.Item1; x++)
      {
        foreach (var dot in dotLocations.Where(d => d.X == x || d.X == dimensionsPreFold.Item1 - x - 1))
        {
          afterFold[dot.Y, x] = true;
        }
      }
    }
    else
    {
      for (int y = 0; y < dimensionsPostFold.Item2; y++)
      {
        foreach (var dot in dotLocations.Where(d => d.Y == y || d.Y == dimensionsPreFold.Item2 - y - 1))
        {
          afterFold[y, dot.X] = true;
        }
      }
    }
    var count = 0;
    for (int y = 0; y < afterFold.GetLength(0); y++)
    {
      for (int x = 0; x < afterFold.GetLength(1); x++)
      {
        if (afterFold[y, x] == true)
        {
          count++;
        }
      }
    }
    return count;
  }

  public int SolvePartTwo()
  {
    (int, int) dimensionsPreFold = FindDimensions();
    (int, int) dimensionsPostFold = (0, 0);

    foreach (var fold in foldLines)
    {
      if (fold.Direction == 'x')
      {
        dimensionsPostFold.Item1 = (dimensionsPreFold.Item1 - 1) / 2;
        dimensionsPostFold.Item2 = dimensionsPreFold.Item2;
      }
      else
      {
        dimensionsPostFold.Item1 = dimensionsPreFold.Item1;
        dimensionsPostFold.Item2 = (dimensionsPreFold.Item2 - 1) / 2;
      }
      var afterFold = new bool[dimensionsPostFold.Item2, dimensionsPostFold.Item1];
      if (fold.Direction == 'x')
      {
        for (int x = 0; x < dimensionsPostFold.Item1; x++)
        {
          foreach (var dot in dotLocations.Where(d => d.X == x || d.X == dimensionsPreFold.Item1 - x - 1))
          {
            afterFold[dot.Y, x] = true;
          }
        }
      }
      else
      {
        for (int y = 0; y < dimensionsPostFold.Item2; y++)
        {
          foreach (var dot in dotLocations.Where(d => d.Y == y || d.Y == dimensionsPreFold.Item2 - y - 1))
          {
            afterFold[y, dot.X] = true;
          }
        }
      }
      SaveAfterFold(afterFold);
      dimensionsPreFold = (afterFold.GetLength(1), afterFold.GetLength(0));
    }
    for (int y = 0; y <= dotLocations.MaxBy(d => d.Y).Y; y++)
    {
      for (int x = 0; x <= dotLocations.MaxBy(d => d.X).X; x++)
      {
        if (dotLocations.Where(d => d.Y == y && d.X == x).Any())
        {
          Console.Write('*');
        }
        else
        {
          Console.Write(' ');
        }
      }
      Console.WriteLine();
    }
    return 0;
  }
  private void SaveAfterFold(bool[,] afterFold)
  {
    dotLocations.Clear();
    for (int y = 0; y < afterFold.GetLength(0); y++)
    {
      for (int x = 0; x < afterFold.GetLength(1); x++)
      {
        if (afterFold[y, x] == true)
        {
          dotLocations.Add(new DotLocation(x, y));
        }
      }
    }
  }

  private (int, int) FindDimensions()
  {
    var xMax = dotLocations.MaxBy(l => l.X).X + 1;
    var yMax = dotLocations.MaxBy(l => l.Y).Y + 1;
    return (xMax, yMax);
  }

  private record struct DotLocation(int X, int Y);
  private record struct FoldLine(char Direction, int LineNumber);
}