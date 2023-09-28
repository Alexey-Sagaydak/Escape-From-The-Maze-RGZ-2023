namespace EscapeFromTheMazeRGZ;

public enum Decision
{
    Agree,
    Disagree
}

public enum Move
{
    Upward = +1,
    Downward = -1,
    None = 0
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
