internal class Day06
{
  public int SolvePartOne(string daySixInput)
  {
    var population = new List<Fish>();
    foreach (var fishTimer in daySixInput.Split(','))
      population.Add(new Fish(int.Parse(fishTimer)));

    int daysToModel = 80;
    List<Fish> newFish;
    for (int i = 0; i < daysToModel; i++)
    {
      newFish = new();
      foreach(var fish in population)
      {
        if (fish.Update())
        {
          newFish.Add(new Fish());
        }
      }
      population.AddRange(newFish);
    }
    return population.Count;
  }

  public long SolvePartTwo(string daySixInput)
  {
    int daysToModel = 256;
    long[] population = new long[9];
    foreach (var fishTimer in daySixInput.Split(','))
      population[long.Parse(fishTimer)]++;

    for (int day = 0; day < daysToModel; day++)
    {
      long newFishAndFishGivingBirth = population[0];
      for (int fishGroup = 1; fishGroup <= 8; fishGroup++)
      {
        population[fishGroup - 1] = population[fishGroup];
      }
      population[6] += newFishAndFishGivingBirth;
      population[8] = newFishAndFishGivingBirth;
    }
    return population.Sum();
  }

  private class Fish
  {
    private int timer;

    public Fish()
    {
      timer = 8;
    }
    public Fish(int timer)
    {
      this.timer = timer;
    }

    public bool Update()
    {
      bool result = false;
      if (timer == 0)
      {
        result = true;
        timer = 6;
      }
      else
      {
        timer--;
      }
      return result;
    }

    public override string ToString()
    {
      return timer.ToString();
    }
  }
}