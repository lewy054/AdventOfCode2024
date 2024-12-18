namespace Day6;

public class Guard(Position position)
{
    public Position Position { get; set; } = new Position()
    {
        X = position.X,
        Y = position.Y
    };
    public MovementDirection Direction { get; set; } = MovementDirection.North;


    public enum MovementDirection
    {
        North,
        East,
        South,
        West,
    }
}


