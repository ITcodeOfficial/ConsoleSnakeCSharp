using System;
using System.Threading;

namespace Snake
{
    class Game
    {
        public static int Width { get; } = 26;
        public static int Height { get; } = 26;

        ConsoleKeyInfo keyInfo;
        ConsoleKey consoleKey;

        Snake snake;
        Fruit fruit;

        public int Score { set; get; }
        bool IsLost;
        bool IsWin;

        public Game()
        {
            Console.CursorVisible = false;
            Console.Title = "Console Snake C#";
            snake = new Snake();
            fruit = new Fruit();
        }

        void Restart()
        {
            Board.Write(Width, Height);
            Menu();
            Console.Clear();

            keyInfo = new ConsoleKeyInfo();
            consoleKey = new ConsoleKey();

            IsLost = false;
            IsWin = false;

            snake.Restart();
            fruit.Restart();
            Board.Write(Width, Height);
        }

        void Control()
        {
            if (Console.KeyAvailable)
            {
                keyInfo = Console.ReadKey(true);
                consoleKey = keyInfo.Key;
            }

            switch (consoleKey)
            {
                case ConsoleKey.W:
                    if ((snake.Y[0] - snake.Y[1]) == 1) goto case ConsoleKey.S;
                    else snake.Shift(Snake.Direction.Top);
                    break;
                case ConsoleKey.S:
                    if ((snake.Y[0] - snake.Y[1]) == -1) goto case ConsoleKey.W;
                    else snake.Shift(Snake.Direction.Bottom);
                    break;
                case ConsoleKey.A:
                    if ((snake.X[0] - snake.X[1]) == 1) goto case ConsoleKey.D;
                    else snake.Shift(Snake.Direction.Left);
                    break;
                case ConsoleKey.D:
                    if ((snake.X[0] - snake.X[1]) == -1) goto case ConsoleKey.A;
                    else snake.Shift(Snake.Direction.Right);
                    break;
                default:
                    if ((snake.Y[0] - snake.Y[1]) == 1) goto case ConsoleKey.S;
                    if ((snake.Y[0] - snake.Y[1]) == -1) goto case ConsoleKey.W;
                    if ((snake.X[0] - snake.X[1]) == 1) goto case ConsoleKey.D;
                    if ((snake.X[0] - snake.X[1]) == -1) goto case ConsoleKey.A;
                    break;
            }
        }

        void Logic()
        {
            Control();
            fruit.Logic(ref snake);
            snake.Logic(ref IsLost, ref IsWin);
        }

        void Menu()
        {
            ConsoleKeyInfo keyInfo = new ConsoleKeyInfo();
            ConsoleKey consoleKey = new ConsoleKey();
            Console.SetCursorPosition(Width / 2 - 6, 1);
            Console.Write("CONSOL SNAKE C#");
            Console.SetCursorPosition(Width / 2 - 11, 2);
            Console.Write("Press 1 to start new game");
            Console.SetCursorPosition(Width / 2 - 11, 3);
            Console.Write("Press Esc to quit a game");
        chooseButton:
            keyInfo = Console.ReadKey(true);
            consoleKey = keyInfo.Key;
            switch (consoleKey)
            {
                case ConsoleKey.D1:
                    break;
                case ConsoleKey.Escape:
                    Environment.Exit(0);
                    break;
                default:
                    goto chooseButton;
            }
        }

        public void Play()
        {
            while (true)
            {
                Restart();
                while (IsLost == false && IsWin == false)
                {
                    Logic();
                    Thread.Sleep(100);
                }
                if (IsWin == true)
                {
                    Console.SetCursorPosition(Height / 2 - 4, Width / 2);
                    Console.Write("You win!!!");
                }
                else if (IsLost == true)
                {
                    Console.SetCursorPosition(Height / 2 - 4, Width / 2);
                    Console.Write("Game Over!");
                }
            }
        }
    }
}
