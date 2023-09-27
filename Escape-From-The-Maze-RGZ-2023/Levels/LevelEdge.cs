namespace EscapeFromTheMazeRGZ;

public class LevelEdge : Level
{
    public LevelEdge(bool IsNoneMoveAvailable = false) : base(IsNoneMoveAvailable) { }

    public override Move MakeMove(Decision decision, Move move)
    {
        CheckMove(move);
        return Move.Downward;
    }

    private void CheckMove(Move move)
    {
        if (move == Move.Upward || move == Move.None)
            throw new Exception("None and Upward moves are unavailable at this level");
    }
}
