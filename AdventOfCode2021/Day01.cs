internal class Day01
{
  // Store converted depths data from the input fule
  private readonly IEnumerable<int> depths;

  // Constructor
  public Day01(string[] inputDepths)
  {
    depths = inputDepths.Select(i => int.Parse(i));
  }

  public int SolvePartOne()
  {
    return CountIncreases(depths);
  }

  public int SolvePartTwo()
  {
    var depthsSliding = depths.Zip(depths.Skip(1), depths.Skip(2)) // Zips the data into a list of tuples of (depths[i], depths[i+1], depths[i+2])
                              .Select(t => t.First + t.Second + t.Third); // Sums the tuples
    return CountIncreases(depthsSliding);
  }

  
  private static int CountIncreases(IEnumerable<int> depths)
  {
    int numberOfIncreases = 0;
    numberOfIncreases = depths.Zip(depths.Skip(1)) // Zips the data into a list of tuples of (depths[i], depths[i+1])
                              .Where(t => t.First < t.Second)
                              .Count();
    return numberOfIncreases;
  }
}
