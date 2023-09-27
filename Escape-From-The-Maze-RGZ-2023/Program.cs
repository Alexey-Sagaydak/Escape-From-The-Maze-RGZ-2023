namespace EscapeFromTheMazeRGZ;

public static class Program
{
    public static void Run()
    {
        Maze maze = new Maze(
            new int[] { +5, -6, +2, -4, +4, -1, +1, -2 },
            0.3, 0.5, 0.2,
            0,
            new LevelCenter(),
            new LevelMiddle(true),
            new LevelMiddle(false),
            new LevelMiddle(false),
            new LevelMiddle(false),
            new LevelEdge()
            );
    }

    public static void Main()
    {
        Run();
    }
}