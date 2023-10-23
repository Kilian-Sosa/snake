using System.Timers;
using Timer = System.Timers.Timer;

namespace Snake {
    public class Program {
        static Game game = new Game(28, 61);
        static Snake snake = new Snake(3, new int[] { 3, 14 }, 1);
        static Timer gameTimer;
        static int initTimer = 800;
        static int timerUpdate = 100;

        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // For the symbols to work
            Run();
        }

        public static void Run() {
            ConsoleKeyInfo keyInfo;
            game.Draw();
            game.SpawnFruit();
            gameTimer = new Timer(initTimer); // One second interval
            gameTimer.Elapsed += HandleTimerElapsed;
            gameTimer.Start();
            do {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key) {
                    case ConsoleKey.UpArrow:
                        snake.ChangeDirection(0);
                        break;
                    case ConsoleKey.DownArrow:
                        snake.ChangeDirection(2);
                        break;
                    case ConsoleKey.LeftArrow:
                        snake.ChangeDirection(3);
                        break;
                    case ConsoleKey.RightArrow:
                        snake.ChangeDirection(1);
                        break;
                }
                Eat();
            } while (keyInfo.Key != ConsoleKey.Escape);
        }

        public static bool HasLost() {
            if (snake.body[0, 0] == 0 || snake.body[0, 0] == game.width - 1 || snake.body[0, 1] == 0 || snake.body[0, 1] == game.height - 1) return true;
            for (int i = 1; i < snake.size; i++) 
                if (snake.body[0, 0] == snake.body[i, 0] && snake.body[0, 1] == snake.body[i, 1]) return true;
            return false;
        }

        public static void Eat() {
            if (snake.body[0, 0] == game.fruit[0] && snake.body[0, 1] == game.fruit[1]) {
                snake.Grow();
                game.score++;
                game.SpawnFruit();
            }
            if (game.score % 10 == 0 && gameTimer.Interval >= 400) gameTimer.Interval -= timerUpdate;
        }

        public static void HandleTimerElapsed(object sender, ElapsedEventArgs e) {
            game.MoveSnake(snake);
            Console.Clear();
            game.Draw();
            if (HasLost()) {
                Console.WriteLine("You lost!");
                Console.WriteLine("Score: " + game.score);
                gameTimer.Stop();
            }
            Eat();
        }
    }
}