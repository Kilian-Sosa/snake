namespace Snake {
    public class Snake {
        public int Size { get; private set; }
        public int[,] Body { get; private set; }
        public int[] Head { get; private set; }
        public int[] Tail { get; private set; }
        private int Direction;
        public int[] DirectionVector { get; private set; }

        public Snake(int size, int[] head, int direction) {
            this.Size = size;
            this.Head = head;
            this.Direction = direction;
            DirectionVector = new int[2];
            switch (Direction) {
                case 0:
                    DirectionVector[0] = 0;
                    DirectionVector[1] = -1;
                    break;
                case 1:
                    DirectionVector[0] = 1;
                    DirectionVector[1] = 0;
                    break;
                case 2:
                    DirectionVector[0] = 0;
                    DirectionVector[1] = 1;
                    break;
                case 3:
                    DirectionVector[0] = -1;
                    DirectionVector[1] = 0;
                    break;
            }
            Body = new int[size, 2];
            for (int i = 0; i < size; i++) {
                Body[i, 0] = head[0] - i * DirectionVector[0];
                Body[i, 1] = head[1] - i * DirectionVector[1];
            }
            Tail = new int[2];
            Tail[0] = Body[size - 1, 0];
            Tail[1] = Body[size - 1, 1];
        }

        public void ChangeDirection(int direction) {
            if (this.Direction == direction) return;
            switch (direction) {
                case 0: // Up
                    if (this.Direction == 2) return;
                    DirectionVector[0] = 0;
                    DirectionVector[1] = -1;
                    break;
                case 1: // Right
                    if (this.Direction == 3) return;
                    DirectionVector[0] = 1;
                    DirectionVector[1] = 0;
                    break;
                case 2: // Down
                    if (this.Direction == 0) return;
                    DirectionVector[0] = 0;
                    DirectionVector[1] = 1;
                    break;
                case 3: // Left
                    if (this.Direction == 1) return;
                    DirectionVector[0] = -1;
                    DirectionVector[1] = 0;
                    break;
            }
            this.Direction = direction;
        }

        public void Grow() {
            Size++;
            int[,] newBody = new int[Size, 2];
            for (int i = 0; i < Size - 1; i++) {
                newBody[i, 0] = Body[i, 0];
                newBody[i, 1] = Body[i, 1];
            }
            newBody[Size - 1, 0] = Tail[0];
            newBody[Size - 1, 1] = Tail[1];
            Body = newBody;
        }
    }
}