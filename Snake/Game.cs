namespace Snake {
    public class Game {
        public int width { get; private set; }
        public int height { get; private set; }
        private string[,] map;
        public int[] fruit { get; private set; }
        public int score { get; set; }

        public Game(int height, int width) {
            this.width = width;
            this.height = height;
            map = new string[width, height];
            FillMap();
        }

        public void FillMap() {
            for (int i = 0; i < width; i++) {
                for (int j = 0; j < height; j++) {
                    map[0, j] = "■";
                    map[i, j] = " ";
                    map[width - 1, j] = "■";
                }
                map[i, 0] = "■";
                map[i, height - 1] = "■";
            }
        }

        public void Draw() {
            for (int i = 0; i < height; i++) {
                string line = "";
                for (int j = 0; j < width; j++) {
                    line += map[j, i];
                }
                Console.WriteLine(line);
            }
        }

        public void MoveSnake(Snake snake) {
            map[snake.tail[0], snake.tail[1]] = " ";
            for (int i = snake.size - 1; i > 0; i--) {
                snake.body[i, 0] = snake.body[i - 1, 0];
                snake.body[i, 1] = snake.body[i - 1, 1];
            }
            snake.body[0, 0] += snake.directionVector[0];
            snake.body[0, 1] += snake.directionVector[1];
            snake.tail[0] = snake.body[snake.size - 1, 0];
            snake.tail[1] = snake.body[snake.size - 1, 1];
            for (int i = 0; i < snake.size; i++) {
                map[snake.body[i, 0], snake.body[i, 1]] = "▣";
            }
        }

        public void SpawnFruit() {
            while (true) {
                Random random = new Random();
                int x = random.Next(1, width - 1);
                int y = random.Next(1, height - 1);
                if (map[x, y] == " ") {
                    map[x, y] = "◉";
                    fruit = new int[] { x, y };
                    break;
                }
            }
        }
    }
}