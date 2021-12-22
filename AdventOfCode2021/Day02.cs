internal class Day02
{
  // Store directions from input
  private readonly IEnumerable<DirectionCommand> commands;

  public Day02(string[] inputDirections)
  {
    commands = inputDirections.Select(s => s.Split(' ')) 
                                .Select(s => new DirectionCommand(s[0], int.Parse(s[1])));
  }

  public int SolvePartOne()
  {
    int horizontal = 0;
    int vertical = 0;
    foreach (var command in commands)
    {
      switch (command.Direction)
      {
        case "forward":
          horizontal += command.Units;
          break;
        case "up":
          vertical -= command.Units;
          break;
        case "down":
          vertical += command.Units;
          break;
        default:
          break;
      }
    }
    return horizontal * vertical;
  }

  public int SolvePartTwo()
  {
    var horizontal = 0;
    var vertical = 0;
    var aim = 0;
    foreach (var direction in commands)
    {
      switch (direction.Direction)
      {
        case "forward":
          horizontal += direction.Units;
          vertical += aim * direction.Units;
          break;
        case "up":
          aim -= direction.Units;
          break;
        case "down":
          aim += direction.Units;
          break;
        default:
          break;
      }
    }
    return vertical * horizontal;
  }

  private record DirectionCommand(string Direction, int Units);
}
