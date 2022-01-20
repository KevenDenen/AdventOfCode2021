internal class Day21
{
  private Player player1;
  private Player player2;

  public Day21(string[] dayTwentyOneInput)
  {
    int player1Days = int.Parse(dayTwentyOneInput[0].Split(':')[1]);
    int player2Days = int.Parse(dayTwentyOneInput[1].Split(':')[1]);
    player1 = new Player(player1Days);
    player2 = new Player(player2Days);
  }

  internal int SolvePartOne()
  {
    var die = new DeterministicDie();
    while (true)
    {
      for (int i = 0; i < 3; i++)
      {
        player1.Move(die.Roll());
      }
      player1.ScoreTurn();
      if (player1.Score >= 1000)
      {
        return player2.Score * die.Rolls;
      }
      for (int i = 0; i < 3; i++)
      {
        player2.Move(die.Roll());
      }
      player2.ScoreTurn();
      if (player2.Score >= 1000)
      {
        return player1.Score * die.Rolls;
      }
    }
  }
}

internal class Player
{
  public int Position { get; set; }
  public int Score { get; private set; } = 0;

  public Player(int startingPosition)
  {
    Position = startingPosition;
  }

  public void Move(int spaces)
  {
    Position = (Position + spaces) % 10;
    if (Position == 0)
    {
      Position = 10;
    }
  }
  public void ScoreTurn()
  {
    Score += Position;
  }
}

internal interface IDie
{
  public int Rolls { get; }
  public int Roll();
}
internal class DeterministicDie : IDie
{
  int current = 1;
  public int Rolls { get; private set; } = 0;
  public int Roll()
  {
    Rolls++;
    if (current == 101)
    {
      current = 1;
    }
    return current++;
  }
}