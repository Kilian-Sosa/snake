using System.Timers;
using Timer = System.Timers.Timer;

namespace Snake {
    public class Program {
        static Game Game = new Game(28, 60);
        static Snake Snake = new Snake(3, new int[] { 3, 14 }, 1);
        static Timer GameTimer;
        static int InitTimer = 600;
        static int TimerUpdate = 100;

        public static void Main(string[] args) {
            Console.OutputEncoding = System.Text.Encoding.UTF8; // For the symbols to work
            Run();
        }

        public static void Run() {
            ConsoleKeyInfo keyInfo;
            Game.Draw();
            GameTimer = new Timer(InitTimer); // One second interval
            GameTimer.Elapsed += HandleTimerElapsed;
            GameTimer.Start();
            do {
                keyInfo = Console.ReadKey(true);
                switch (keyInfo.Key) {
                    case ConsoleKey.UpArrow:
                        Snake.ChangeDirection(0);
                        break;
                    case ConsoleKey.DownArrow:
                        Snake.ChangeDirection(2);
                        break;
                    case ConsoleKey.LeftArrow:
                        Snake.ChangeDirection(3);
                        break;
                    case ConsoleKey.RightArrow:
                        Snake.ChangeDirection(1);
                        break;
                }
                Eat();
            } while (keyInfo.Key != ConsoleKey.Escape || HasLost());
        }

        public static bool HasLost() {
            if (Snake.Body[0, 0] == 0 || Snake.Body[0, 0] == Game.Width - 1 || Snake.Body[0, 1] == 0 || Snake.Body[0, 1] == Game.Height - 1) return true;
            for (int i = 1; i < Snake.Size; i++) 
                if (Snake.Body[0, 0] == Snake.Body[i, 0] && Snake.Body[0, 1] == Snake.Body[i, 1]) return true;
            return false;
        }

        public static void Eat() {
            if (Snake.Body[0, 0] == Game.Fruit[0] && Snake.Body[0, 1] == Game.Fruit[1]) {
                Snake.Grow();
                Game.Score++;
                Game.SpawnFruit();
                if (Game.Score % 10 == 0 && GameTimer.Interval >= 200) GameTimer.Interval -= TimerUpdate;
            }
        }

        public static void HandleTimerElapsed(object sender, ElapsedEventArgs e) {
            Game.MoveSnake(Snake);
            Console.Clear();
            Game.Draw();
            if (HasLost()) {
                Console.WriteLine("You lost!");
                GameTimer.Stop();
            }
            Eat();
        }
    }
}