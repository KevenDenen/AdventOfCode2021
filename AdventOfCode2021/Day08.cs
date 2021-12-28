internal class Day08
{
  private string entries;

  public Day08(string dayEightTestInput)
  {
    entries = dayEightTestInput;
  }

  internal int SolvePartOne()
  {
    int count = 0;
    foreach (var entry in entries.Split(Environment.NewLine))
    {
      string output = entry.Split('|')[1];
      string[] digits = output.Split(' ');
      count += digits.Count(s => s.Length == 2 || s.Length == 3 || s.Length == 4 || s.Length == 7);
    }
    return count;
  }

  internal int SolvePartTwo()
  {
    return 0;
  }
}