namespace Snake {
    public class Game {
        public int Width { get; private set; }
        public int Height { get; private set; }
        private string[,] Map;
        public int[] Fruit { get; private set; }
        public int Score { get; set; }

        public Game(int height, int width) {
            this.Width = width;
            this.Height = height;
            Map = new string[width, Height];
            FillMap();
            SpawnFruit();
        }

        public void FillMap() {
            for (int i = 0; i < Width; i++) {
                for (int j = 0; j < Height; j++) {
                    Map[0, j] = "■";
                    Map[i, j] = " ";
                    Map[Width - 1, j] = "■";
                }
                Map[i, 0] = "■";
                Map[i, Height - 1] = "■";
            }
        }

        public void Draw() {
            for (int i = 0; i < Height; i++) {
                string line = "";
                for (int j = 0; j < Width; j++) {
                    line += Map[j, i] + " ";
                }
                Console.WriteLine(line);
            }
            Console.WriteLine("Fruits eaten: " + Score);
        }

        public void MoveSnake(Snake snake) {
            Map[snake.Tail[0], snake.Tail[1]] = " ";
            for (int i = snake.Size - 1; i > 0; i--) {
                snake.Body[i, 0] = snake.Body[i - 1, 0];
                snake.Body[i, 1] = snake.Body[i - 1, 1];
            }
            snake.Body[0, 0] += snake.DirectionVector[0];
            snake.Body[0, 1] += snake.DirectionVector[1];
            snake.Tail[0] = snake.Body[snake.Size - 1, 0];
            snake.Tail[1] = snake.Body[snake.Size - 1, 1];
            for (int i = 0; i < snake.Size; i++) {
                Map[snake.Body[i, 0], snake.Body[i, 1]] = "▣";
            }
        }

        public void SpawnFruit() {
            while (true) {
                Random random = new Random();
                int x = random.Next(1, Width - 1);
                int y = random.Next(1, Height - 1);
                if (Map[x, y] == " ") {
                    Map[x, y] = "◉";
                    Fruit = new int[] { x, y };
                    break;
                }
            }
        }
    }
}