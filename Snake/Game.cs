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
    }
}