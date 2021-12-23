internal class Day07
{
  private int[] positions;

  public Day07(string daySevenInput)
  {
    positions = daySevenInput.Split(',').Select(s => int.Parse(s)).OrderBy(i => i).ToArray();
  }

  internal int SolvePartOne()
  {
    // The cheapest position is the median of the data?
    int size = positions.Length;
    int mid = size / 2;
    int target = positions[mid];
    // Calculate fuel cost to get to the median
    int fuelCost = positions.Aggregate(0, (previous, current) => previous + Math.Abs(target - current));
    return fuelCost;
    //Not sure if this will work for all instances, but it worked for the sample and the final puzzle.
  }

  internal long SolvePartTwo()
  {
    long best = long.MaxValue;
    for (int target = positions.Min(); target <= positions.Max(); target++)
    {
      long cost = 0;
      foreach (int position in positions)
      {
        int distance = Math.Abs(position - target);
        cost += TriangularNumber(distance);
      }
      if (cost < best)
      {
        best = cost;
      }
    }
    return best;
  }

  internal long TriangularNumber(int distance)
  {
    return distance * (distance + 1) / 2;
  }
}