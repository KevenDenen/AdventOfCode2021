internal class Day06
{
  private readonly List<Fish> population;

  public Day06(string daySixInput)
  {
    population = new List<Fish>();
    foreach (var fishTimer in daySixInput.Split(','))
      population.Add(new Fish(int.Parse(fishTimer)));
  }

  public int SolvePartOne()
  {
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

  public int SolvePartTwo()
  {
    return 0;
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