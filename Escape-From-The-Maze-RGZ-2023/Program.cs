namespace EscapeFromTheMazeRGZ;

public static class Program
{
    public static void Main()
    {
        Run(1_000_000);
    }

    public static Maze CreateMaze()
    {
        Maze maze = new Maze(
                new int[] { +5, -6, +2, -4, +4, -1, +1, -2 },
                0.5, 0.3, 0.2,
                0,
                new LevelCenter(),
                new LevelMiddle(true),
                new LevelMiddle(false),
                new LevelMiddle(false),
                new LevelMiddle(false),
                new LevelEdge()
                );
        return maze;
    }

    public static void Run(int k)
    {
        int Player1Win = 0, Player2Win = 0;

        for (int i = 0; i < k; i++)
        {
            Maze maze = CreateMaze();
            switch (maze.Play())
            {
                case GameResult.Player1:
                    Player1Win++;
                    break;
                case GameResult.Player2:
                    Player2Win++;
                    break;
            }
        }

        DescribeTheResult(Player1Win, Player2Win, k);
    }

    private static void DescribeTheResult(int player1Win, int player2Win, int numberOfGames)
    {
        Console.WriteLine("Игрок 1 - тот, кто дает подсказки\nИгрок 2 - тот, кто получает подсказки\n");
        Console.WriteLine($"Количество сыгранных игр: {numberOfGames}\n");
        
        Console.WriteLine($"Количество побед:\nИгрок 1: {player1Win}\nигрок 2: {player2Win}\n");
        Console.WriteLine($"Проценты побед:\nИгрок 1: {Math.Round((double)player1Win / (player1Win + player2Win) * 100, 1)}%\nИгрок 2: {Math.Round((double)player2Win / (player1Win + player2Win) * 100, 1)}%");
    }
}