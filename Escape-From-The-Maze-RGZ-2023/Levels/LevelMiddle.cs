namespace EscapeFromTheMazeRGZ;

public class LevelMiddle : Level
{
    public LevelMiddle(bool IsNoneMoveAvailable) : base(IsNoneMoveAvailable) { }

    public override Move MakeMove(Decision decision, Move move)
    {
        CheckMove(move);

        if (decision == Decision.Agree)
        {
            return move;
        }
        else
        {
            if (IsNoneMoveAvailable)
            {
                if (move == Move.None)
                    return Move.Upward;

                if (move == Move.Upward)
                    return Move.None;
            }

            if (move == Move.Downward)
                return Move.Upward;

            if (move == Move.Upward)
                return Move.Downward;

            return Move.None;
        }
    }

    private void CheckMove(Move move)
    {
        if (!IsNoneMoveAvailable && move == Move.None)
            throw new Exception("None move is unavailable at this level");
    }
}
