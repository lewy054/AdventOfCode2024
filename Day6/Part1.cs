namespace Day6;

public class Part1(string[] map)
{
    private readonly char ObstructionsSymbol = '#';
    private readonly char GuardSymbol = '^';

    public int Resolve()
    {
        var guardPositionY = Array.FindIndex(map, e => e.Any(c => c == GuardSymbol));
        var guardPositionX = map[guardPositionY].IndexOf(GuardSymbol);
        var guardPosition = new Position()
        {
            X = guardPositionX,
            Y = guardPositionY
        };
        var guard = new Guard(guardPosition);
        var visitedPositions = GetVisitedPositions(guard);
        return visitedPositions.Count;
        
    }

    private List<Position> GetVisitedPositions(Guard guard)
    {
        var visitedPositions = new List<Position>()
        {
            new()
            {
                X = guard.Position.X,
                Y = guard.Position.Y
            }
        };

        while (true)
        {
            switch (guard.Direction)
            {
                case Guard.MovementDirection.North:
                {
                    if (guard.Position.Y == 0)
                    {
                        return visitedPositions;
                    }


                    if (map[guard.Position.Y - 1][guard.Position.X] == ObstructionsSymbol)
                    {
                        guard.Direction = Guard.MovementDirection.East;
                        break;
                    }

                    guard.Position.Y -= 1;

                    var wasVisited = visitedPositions
                        .Any(e => e.X == guard.Position.X && e.Y == guard.Position.Y);
                    if (!wasVisited)
                    {
                        visitedPositions.Add(new Position()
                        {
                            X = guard.Position.X,
                            Y = guard.Position.Y
                        });
                    }

                    break;
                }
                case Guard.MovementDirection.East:
                {
                    if (guard.Position.X == map[guard.Position.Y].Length - 1)
                    {
                        return visitedPositions;
                    }


                    if (map[guard.Position.Y][guard.Position.X + 1] == ObstructionsSymbol)
                    {
                        guard.Direction = Guard.MovementDirection.South;
                        break;
                    }

                    guard.Position.X += 1;
                    var wasVisited = visitedPositions
                        .Any(e => e.X == guard.Position.X && e.Y == guard.Position.Y);
                    if (!wasVisited)
                    {
                        visitedPositions.Add(new Position()
                        {
                            X = guard.Position.X,
                            Y = guard.Position.Y
                        });
                    }

                    break;
                }
                case Guard.MovementDirection.South:
                {
                    if (guard.Position.Y == map.Length - 1)
                    {
                        return visitedPositions;
                    }


                    if (map[guard.Position.Y + 1][guard.Position.X] == ObstructionsSymbol)
                    {
                        guard.Direction = Guard.MovementDirection.West;
                        break;
                    }

                    guard.Position.Y += 1;
                    var wasVisited = visitedPositions
                        .Any(e => e.X == guard.Position.X && e.Y == guard.Position.Y);
                    if (!wasVisited)
                    {
                        visitedPositions.Add(new Position()
                        {
                            X = guard.Position.X,
                            Y = guard.Position.Y
                        });
                    }

                    break;
                }
                case Guard.MovementDirection.West:
                {
                    if (guard.Position.X == 0)
                    {
                        return visitedPositions;
                    }


                    if (map[guard.Position.Y][guard.Position.X - 1] == ObstructionsSymbol)
                    {
                        guard.Direction = Guard.MovementDirection.North;
                        break;
                    }

                    guard.Position.X -= 1;
                    var wasVisited = visitedPositions
                        .Any(e => e.X == guard.Position.X && e.Y == guard.Position.Y);
                    if (!wasVisited)
                    {
                        visitedPositions.Add(new Position()
                        {
                            X = guard.Position.X,
                            Y = guard.Position.Y
                        });
                    }

                    break;
                }
                default:
                    throw new InvalidDataException();
            }
        }
    }
}