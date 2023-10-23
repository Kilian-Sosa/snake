namespace Snake {
    public class Snake {
        public int size { get; private set; }
        public int[,] body { get; private set; }
        public int[] head { get; private set; }
        public int[] tail { get; private set; }
        private int direction;
        public int[] directionVector { get; private set; }

        public Snake(int size, int[] head, int direction) {
            this.size = size;
            this.head = head;
            this.direction = direction;
            directionVector = new int[2];
            switch (direction) {
                case 0:
                    directionVector[0] = 0;
                    directionVector[1] = -1;
                    break;
                case 1:
                    directionVector[0] = 1;
                    directionVector[1] = 0;
                    break;
                case 2:
                    directionVector[0] = 0;
                    directionVector[1] = 1;
                    break;
                case 3:
                    directionVector[0] = -1;
                    directionVector[1] = 0;
                    break;
            }
            body = new int[size, 2];
            for (int i = 0; i < size; i++) {
                body[i, 0] = head[0] - i * directionVector[0];
                body[i, 1] = head[1] - i * directionVector[1];
            }
            tail = new int[2];
            tail[0] = body[size - 1, 0];
            tail[1] = body[size - 1, 1];
        }

        public void ChangeDirection(int direction) {
            if (this.direction == direction) return;
            switch (direction) {
                case 0: // Up
                    if (this.direction == 2) return;
                    directionVector[0] = 0;
                    directionVector[1] = -1;
                    break;
                case 1: // Right
                    if (this.direction == 3) return;
                    directionVector[0] = 1;
                    directionVector[1] = 0;
                    break;
                case 2: // Down
                    if (this.direction == 0) return;
                    directionVector[0] = 0;
                    directionVector[1] = 1;
                    break;
                case 3: // Left
                    if (this.direction == 1) return;
                    directionVector[0] = -1;
                    directionVector[1] = 0;
                    break;
            }
            this.direction = direction;
        }

        public void Grow() {
            size++;
            int[,] newBody = new int[size, 2];
            for (int i = 0; i < size - 1; i++) {
                newBody[i, 0] = body[i, 0];
                newBody[i, 1] = body[i, 1];
            }
            newBody[size - 1, 0] = tail[0];
            newBody[size - 1, 1] = tail[1];
            body = newBody;
        }
    }
}