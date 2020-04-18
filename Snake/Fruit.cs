using System;

namespace Snake
{
    class Fruit
    {
        int X { set; get; }
        int Y { set; get; }
        int Score { set; get; }

        Random rnd = new Random();

        public void Restart()
        {
            X = Game.Width / 2;
            Y = Game.Height / 2 - 5;
            Score = 0;
        }
        void Rand(int width, int height, Snake snake)
        {
            X = rnd.Next(1, width);
            Y = rnd.Next(1, height);

            for (int i = snake.Length; i >= 1; i--)
            {
                if (snake.X[i - 1] == X && snake.Y[i - 1] == Y)
                {
                    Rand(width, height, snake);
                }
            }
        }
        void Draw()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(X, Y);
            Console.Write("■");
            Console.ForegroundColor = ConsoleColor.White;
        }
        public void Logic(ref Snake snake)
        {
            Draw();
            if (snake.X[0] == X)
            {
                if (snake.Y[0] == Y)
                {
                    snake.Length++;
                    Score += 100;
                    Console.SetCursorPosition(Game.Width / 2 - 4, Game.Height + 2);
                    Console.Write($"Score: {Score}");
                    Rand(Game.Width, Game.Height, snake);
                }
            }
        }
    }
}
