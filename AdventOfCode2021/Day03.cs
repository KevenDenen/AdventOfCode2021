internal class Day03
{
  private readonly string[] reportLines;

  public Day03(string[] dayThreeInput)
  {
    reportLines = dayThreeInput;
  }

  public int SolvePartOne()
  {
    string gamma = "";
    string epsilon = "";
    int lineLength = reportLines[0].Length;
    for (int i = 0; i < lineLength; i++)
    {
      if (MostCommon(reportLines, i) == '1')
      {
        gamma += "1";
        epsilon += "0";
      }
      else
      {
        gamma += "0";
        epsilon += "1";
      }
    }
    return Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
  }

  public int SolvePartTwo()
  {
    List<string> o2Rating = reportLines.ToList();
    int lineLength = reportLines[0].Length;
    for (int i = 0; i < lineLength; i++)
    {
      if (MostCommon(o2Rating, i) == '0')
      {
        o2Rating = o2Rating.Where(o => o[i] == '0').ToList();
      }
      else
      {
        o2Rating = o2Rating.Where(o => o[i] == '1').ToList();
      }
      if (o2Rating.Count == 1) break;
    }
    int o2Rate = Convert.ToInt32(o2Rating.First(), 2);
    List<string> co2Rating = reportLines.ToList();
    for (int i = 0; i < lineLength; i++)
    {
      if (MostCommon(co2Rating, i) == '0')
      {
        co2Rating = co2Rating.Where(o => o[i] == '1').ToList();
      }
      else
      {
        co2Rating = co2Rating.Where(o => o[i] == '0').ToList();
      }
      if (co2Rating.Count == 1) break;
    }
    int co2Rate = Convert.ToInt32(co2Rating.First(), 2);
    return o2Rate * co2Rate;
  }

  private static char MostCommon(IEnumerable<string> list, int position)
  {
    int ones = 0;
    int zeros = 0;
    foreach (string item in list)
    {
      if (item[position] == '1') 
        ones++;
      else
        zeros++;
    }
    if (ones > zeros)
      return '1';
    else if (zeros > ones)
      return '0';
    else
      return '2';
  }
}