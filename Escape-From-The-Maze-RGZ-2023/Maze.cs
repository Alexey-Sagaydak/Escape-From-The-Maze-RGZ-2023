namespace EscapeFromTheMazeRGZ;

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

    private void CheckProbabilities()
    {
        if (Math.Abs(1 - (ProbabilityOfUpwardMove + ProbabilityOfDownwardMove + ProbabilityOfNoneMove)) > 0.001)
            throw new Exception("Incorrect probability values");
    }

    public void Play()
    {
        throw new NotImplementedException();
    }
}
