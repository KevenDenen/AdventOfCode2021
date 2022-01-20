internal class Day14
{
  private string initialLine = "";
  private List<Insertion> insertions;
  private Dictionary<string, long> pairs;

  public Day14(string[] dayFourteenTestInput)
  {
    initialLine = dayFourteenTestInput[0];
    insertions = new List<Insertion>(dayFourteenTestInput.Skip(2).Select(i => new Insertion(i.Split(" -> ")[0], i.Split(" -> ")[1])));
    pairs = GetPairsInLine();
  }

  internal int SolvePartOne()
  {
    var line = initialLine;
    for (int step = 0; step < 10; step++)
    {
      var newLine = "";
      for (int i = 0; i < line.Length - 1; i++)
      {
        string pair = line.Substring(i, 2);
        var insertion = insertions.First(i => i.Pair == pair);
        if (i == 0)
          newLine = pair[0] + insertion.Inserted + pair[1];
        else
          newLine += insertion.Inserted + pair[1];
      }
      line = newLine;
    }
    Dictionary<char, int> letterFrequency = new();
    foreach (var character in line)
    {
      if (letterFrequency.ContainsKey(character))
        letterFrequency[character]++;
      else
        letterFrequency.Add(character, 1);
    }
    return letterFrequency.MaxBy(kvp => kvp.Value).Value - letterFrequency.MinBy(kvp => kvp.Value).Value;
  }
  internal long SolvePartTwo()
  {
    for (int i = 0; i < 40; i++)
    {
      Dictionary<string, long> newPairs = new();
      foreach (var pair in insertions)
      {
        if (pairs.ContainsKey(pair.Pair))
        {
          var firstNewPair = pair.Pair[0] + pair.Inserted;
          var secondNewPair = pair.Inserted + pair.Pair[1];

          if (newPairs.ContainsKey(firstNewPair))
            newPairs[firstNewPair]+=pairs[pair.Pair];
          else
            newPairs.Add(firstNewPair, pairs[pair.Pair]);
          if (newPairs.ContainsKey(secondNewPair))
            newPairs[secondNewPair]+=pairs[pair.Pair];
          else
            newPairs.Add(secondNewPair, pairs[pair.Pair]);
        }
      }
      pairs = newPairs;
    }
    Dictionary<char, long> letterFrequency = new();
    foreach (var pair in pairs)
    {
      // The first letter of each pair gets counted
      // The second letter is the first letter in a different pair
      if (letterFrequency.ContainsKey(pair.Key[0]))
        letterFrequency[pair.Key[0]] += pair.Value;
      else
        letterFrequency.Add(pair.Key[0], pair.Value);
    }
    // Except for the very last letter pair, so we need to add the very last letter of the initial line
    letterFrequency[initialLine.Last()]++;
    return letterFrequency.MaxBy(kvp => kvp.Value).Value - letterFrequency.MinBy(kvp => kvp.Value).Value;
  }

  private Dictionary<string, long> GetPairsInLine()
  {
    Dictionary<string, long> pairsInLine = new();
    for (int i = 0; i < initialLine.Length - 1; i++)
    {
      var pair = initialLine.Substring(i, 2);
      if (pairsInLine.ContainsKey(pair))
        pairsInLine[pair]++;
      else
        pairsInLine.Add(pair, 1);
    }
    return pairsInLine;
  }

  private record struct Insertion(string Pair, string Inserted);
}