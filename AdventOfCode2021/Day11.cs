internal class Day11
{
  private readonly DumboOctopus[,] dumboOctopusMap;
  private readonly int height;
  private readonly int width;

  public Day11(string[] dayElevenTestInput)
  {
    int lineCount = dayElevenTestInput.Length;
    int lineLength = dayElevenTestInput[0].Length;

    dumboOctopusMap = new DumboOctopus[lineCount, lineLength];
    for (int y = 0; y < lineCount; y++)
    {
      for (int x = 0; x < lineLength; x++)
      {
        dumboOctopusMap[y, x] = new DumboOctopus(int.Parse(dayElevenTestInput[y][x].ToString()), dumboOctopusMap, y, x);
      }
    }
    height = dumboOctopusMap.GetLength(0);
    width = dumboOctopusMap.GetLength(1);
  }

  internal int SolvePartOne()
  {
    int result = 0;
    int numberOfSteps = 100;
    for (int i = 0; i < numberOfSteps; i++)
    {
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          dumboOctopusMap[y, x].StepOne();
        }
      }
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          dumboOctopusMap[y, x].StepTwo();
        }
      }
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          if (dumboOctopusMap[y, x].Flashed)
          {
            result++;
            dumboOctopusMap[y, x].Reset();
          }
        }
      }
    }
    return result;
  }

  public int SolvePartTwo()
  {
    int step = 0;
    while (!Synchronized())
    {
      step++;
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          dumboOctopusMap[y, x].StepOne();
        }
      }
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          dumboOctopusMap[y, x].StepTwo();
        }
      }
      for (int y = 0; y < height; y++)
      {
        for (int x = 0; x < width; x++)
        {
          dumboOctopusMap[y, x].StepThree();
        }
      }
    }    
    return step;
  }

  private bool Synchronized()
  {
    for (int y = 0; y < height; y++)
    {
      for (int x = 0; x < width; x++)
      {
        if (dumboOctopusMap[y,x].EnergyLevel != 0)
        {
          return false;
        }  
      }
    }
    return true;
  }

  private class DumboOctopus
  {
    public int EnergyLevel { get; private set; }
    public bool Flashed { get; private set; }

    private readonly DumboOctopus[,] dumboOctopusMap;
    private readonly int y;
    private readonly int x;
    private readonly int height;
    private readonly int width;

    public DumboOctopus(int energyLevel, DumboOctopus[,] dumboOctopi, int y, int x)
    {
      EnergyLevel = energyLevel;
      dumboOctopusMap = dumboOctopi;
      this.y = y;
      this.x = x;
      height = dumboOctopi.GetLength(0);
      width = dumboOctopi.GetLength(1);
    }

    public void StepOne()
    {
      Flashed = false;
      EnergyLevel++;
    }

    public void StepTwo()
    {
      if (!Flashed && (EnergyLevel > 9))
      {
        Flashed = true;
        FlashSurrounding(y, x);
      }
    }

    internal void StepThree()
    {
      if (Flashed)
      {
        Reset();
      }
    }

    public void Flash()
    {
      EnergyLevel++;
      StepTwo();
    }

    public void Reset()
    {
      EnergyLevel = 0;
    }

    private void FlashSurrounding(int y, int x)
    {
      if (y > 0)
      {
        dumboOctopusMap[y - 1, x].Flash();
        if (x > 0)
        {
          dumboOctopusMap[y - 1, x - 1].Flash();
        }
        if (x < width - 1)
        {
          dumboOctopusMap[y - 1, x + 1].Flash();
        }
      }
      if (y < height - 1) // Bottom three
      {
        dumboOctopusMap[y + 1, x].Flash();
        if (x > 0)
        {
          dumboOctopusMap[y + 1, x - 1].Flash();
        }
        if (x < width - 1)
        {
          dumboOctopusMap[y + 1, x + 1].Flash();
        }
      }
      if (x > 0) // Middle left
      {
        dumboOctopusMap[y, x - 1].Flash();        
      }
      if (x < width - 1) // Middle right
      {
        dumboOctopusMap[y, x + 1].Flash();
      }
    }
    public override string ToString()
    {
      return EnergyLevel.ToString();
    }
  }
}