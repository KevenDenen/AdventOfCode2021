internal class Day09
{
  private readonly int[,] mapDepths;
  private readonly int height;
  private readonly int width;

  public Day09(string dayNineTestInput)
  {
    string[] lines = dayNineTestInput.Split(Environment.NewLine);
    int lineCount = lines.Length;
    int lineLength = lines[0].Length;

    mapDepths = new int[lineCount, lineLength];
    for (int i = 0; i < lineCount; i++)
    {
      for (int j = 0; j < lineLength; j++)
      {
        mapDepths[i, j] = int.Parse(lines[i][j].ToString());
      }
    }
    height = mapDepths.GetLength(0);
    width = mapDepths.GetLength(1);
  }

  internal long SolvePartOne()
  {
    long result = 0;

    for (int y = 0; y < height; y++)
    {
      for (int x = 0; x < width; x++)
      {
        if (mapDepths[y, x] == 9)
        {
          // 9 can never be a low point, short circuit
          continue;
        }
        if (mapDepths[y, x] == 0)
        {
          // 0 is always a low point, short circuit
          result++;
          continue;
        }

        if (y > 0)
        {
          // Not in the first row, look up
          if (mapDepths[y - 1, x] < mapDepths[y, x])
          {
            continue;
          }
        }
        if (x > 0)
        {
          // Not in the first column, look left
          if (mapDepths[y, x - 1] < mapDepths[y, x])
          {
            continue;
          }
        }
        if (y < height - 1)
        {
          // Not in the last row, look down
          if (mapDepths[y + 1, x] < mapDepths[y, x])
          {
            continue;
          }
        }
        if (x < width - 1)
        {
          // Not in the last column, look right
          if (mapDepths[y, x + 1] < mapDepths[y, x])
          {
            continue;
          }
        }

        // We're at a low point
        result += mapDepths[y, x] + 1;
      }
    }
    return result;
  }

  internal long SolvePartTwo()
  {
    List<int> basinSizes = new();

    for (int y = 0; y < height; y++)
    {
      for (int x = 0; x < width; x++)
      {
        if (mapDepths[y, x] == 9)
        {
          // 9 can never be a low point, short circuit
          continue;
        }

        if (y > 0)
        {
          // Not in the first row, look up
          if (mapDepths[y - 1, x] < mapDepths[y, x])
          {
            continue;
          }
        }
        if (x > 0)
        {
          // Not in the first column, look left
          if (mapDepths[y, x - 1] < mapDepths[y, x])
          {
            continue;
          }
        }
        if (y < height - 1)
        {
          // Not in the last row, look down
          if (mapDepths[y + 1, x] < mapDepths[y, x])
          {
            continue;
          }
        }
        if (x < width - 1)
        {
          // Not in the last column, look right
          if (mapDepths[y, x + 1] < mapDepths[y, x])
          {
            continue;
          }
        }

        // We're at a low point
        bool[,] visited = new bool[height, width];
        basinSizes.Add(GetSize(mapDepths, visited, y, x));
      }
    }
    return basinSizes
      .OrderByDescending(i => i)
      .Take(3)
      .Aggregate((current, previous) => current * previous);
  }

  private int GetSize(int[,] mapDepths, bool[,] visited, int y, int x)
  {
    int depth = mapDepths[y, x];
    if (depth == 9)
    {
      return 0;
    }
    int count = 1;
    visited[y, x] = true;

    if (y > 0 && !visited[y - 1, x])
    {
      count += GetSize(mapDepths, visited, y - 1, x);
    }
    if (x > 0 && !visited[y, x - 1])
    {
      count += GetSize(mapDepths, visited, y, x - 1);
    }
    if (y < height - 1 && !visited[y + 1, x])
    {
      count += GetSize(mapDepths, visited, y + 1, x);
    }
    if (x < width - 1 && !visited[y, x + 1])
    {
      count += GetSize(mapDepths, visited, y, x + 1);
    }

    return count;
  }
}