namespace EscapeFromTheMazeRGZ;

public enum Decision
{
    Agree,
    Disagree
}

public enum Move
{
    Upward,
    Downward,
    None
}

public abstract class Level
{
    public bool IsNoneMoveAvailable { get; private set; }
    public abstract Move MakeMove(Decision decision, Move move);

    public Level(bool IsNoneMoveAvailable)
    {
        this.IsNoneMoveAvailable = IsNoneMoveAvailable;
    }
}
