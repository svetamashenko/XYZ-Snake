namespace XYZ_Snake
{
    public class SnakeGameplayState : BaseGameState
    {
        private struct Cell(int x, int y)
        {
            public int X { get; private set; } = x;
            public int Y { get; private set; } = y;
        }
        private readonly List<Cell> _body = [];
        private SnakeDir _currentDir = SnakeDir.Right;
        private float _timeToMove = 0f;
        public void SetDirection(SnakeDir newDir)
        {
            _currentDir = newDir;
        }
        private static Cell ShiftTo(Cell old, SnakeDir snakeDir)
        {
            return snakeDir switch
            {
                SnakeDir.Left => new Cell(old.X - 1, old.Y),
                SnakeDir.Right => new Cell(old.X + 1, old.Y),
                SnakeDir.Up => new Cell(old.X, old.Y + 1),
                SnakeDir.Down => new Cell(old.X, old.Y - 1),
                _ => old,
            };
        }
        public override void Reset()
        {
            _body.Clear();
            _currentDir = SnakeDir.Right;
            _body.Add(new Cell(0, 0));
            _timeToMove = 0f;
        }
        public override void Update(float deltaTime)
        {
            _timeToMove -= deltaTime;
            if (_timeToMove > 0f)
                return;
            _timeToMove = 1f / 3f;
            Cell head = _body[0];
            Cell nextCell = ShiftTo(head, _currentDir);
            _body.Remove(_body.Last());
            _body.Insert(0, nextCell);
            Console.WriteLine($"Голова на позиции x = {_body[0].X}, y = {_body[0].Y}.");
        }
    }
    public enum SnakeDir
    {
        Up, Down, Left, Right
    }
}
