namespace EscapeFromTheMazeRGZ;

public class LevelCenter : Level
{
    public LevelCenter(bool IsNoneMoveAvailable = false) : base(IsNoneMoveAvailable) { }

    public override Move MakeMove(Decision decision, Move move)
    {
        CheckMove(move);
        return Move.Upward;
    }

    private void CheckMove(Move move)
    {
        if (move == Move.Downward || move == Move.None)
            throw new Exception("None and Downward moves are unavailable at this level");
    }
}
