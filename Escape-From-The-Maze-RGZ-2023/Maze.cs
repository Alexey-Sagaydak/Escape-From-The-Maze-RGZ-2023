namespace EscapeFromTheMazeRGZ;

public enum GameResult
{
    /// <summary>
    /// The player who gives hints.
    /// </summary>
    Player1,

    /// <summary>
    /// The player who gets hints.
    /// </summary>
    Player2
}

public class Maze
{
	public Level[] Levels { get; private set; }
	public int CurrentLevelIndex { get; private set; }
	public double ProbabilityOfUpwardMove { get; private set; }
	public double ProbabilityOfDownwardMove { get; private set; }
	public double ProbabilityOfNoneMove { get; private set; }
	public int[] Steps { get; private set; }
	public int CurrentStep { get; private set; }
	public int GameLength { get; private set; }

	private int MaxLevelIndex;
	private int MinLevelIndex;

	public Maze(int[] steps, double probabilityOfUpwardMove, double probabilityOfDownwardMove, double probabilityOfNoneMove, int startLevelIndex = 0, params Level[] levels)
	{
		Levels = levels;

		MinLevelIndex = 0;
		CurrentLevelIndex = startLevelIndex;
		MaxLevelIndex = levels.Length - 1;

		Steps = steps;
		CurrentStep = 0;

		for (int i = 0; i < Steps.Length; i++)
			GameLength += Math.Abs(steps[i]);

		ProbabilityOfUpwardMove = probabilityOfUpwardMove;
		ProbabilityOfDownwardMove = probabilityOfDownwardMove;
		ProbabilityOfNoneMove = probabilityOfNoneMove;

		CheckProbabilities();
	}

	public GameResult Play()
	{
		for (int i = 0; i < Steps.Length; i++)
		{
			Decision decision = (Steps[i] > 0) ? Decision.Agree : Decision.Disagree;

			for (int j = 0; j < Math.Abs(Steps[i]); j++)
			{
				Move move = Levels[CurrentLevelIndex].MakeMove(decision, DecideMove());
				CurrentLevelIndex += (int)move;
				CurrentStep++;

				if (CurrentLevelIndex == MaxLevelIndex)
					return GameResult.Player2;

				if (CurrentStep == GameLength)
					return GameResult.Player1;
			}
		}
		return new();
	}
	
	private void CheckProbabilities()
	{
		if (Math.Abs(1 - (ProbabilityOfUpwardMove + ProbabilityOfDownwardMove + ProbabilityOfNoneMove)) > 0.001)
			throw new Exception("Incorrect probability values");
	}

	private Move DecideMove()
	{
		// 0.0 Downward ... None ... Upward ... 1.0
		Move move = Move.Upward;
		Random rnd = new Random();
		double number = rnd.NextDouble();

		if (CurrentLevelIndex == MinLevelIndex)
			return Move.Upward;

        if (CurrentLevelIndex == MaxLevelIndex)
            return Move.Downward;

		if (number < ProbabilityOfNoneMove + ProbabilityOfDownwardMove)
		{
			move = Move.Downward;

			if (Levels[CurrentLevelIndex].IsNoneMoveAvailable && number > ProbabilityOfDownwardMove)
				move = Move.None;
		}

        return move;
	}
}
