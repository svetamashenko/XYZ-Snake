namespace XYZ_Snake
{
    public class ConsoleInput
    {
        public interface IArrowListener
        {
            public abstract void OnArrowUp();
            public abstract void OnArrowDown();
            public abstract void OnArrowLeft();
            public abstract void OnArrowRight();
        }
        private readonly List<IArrowListener> arrowListeners = [];
        public void Subscribe(IArrowListener listener)
        {
            arrowListeners.Add(listener);
        }
        public void Update()
        {
            while (Console.KeyAvailable)
            {
                var key = Console.ReadKey();

                switch (key.Key)
                {
                    case ConsoleKey.UpArrow or ConsoleKey.W:
                        foreach (var arrowListener in arrowListeners)
                            arrowListener.OnArrowUp();
                        break;
                    case ConsoleKey.DownArrow or ConsoleKey.S:
                        foreach (var arrowListener in arrowListeners)
                            arrowListener.OnArrowDown();
                        break;
                    case ConsoleKey.RightArrow or ConsoleKey.D:
                        foreach (var arrowListener in arrowListeners)
                            arrowListener.OnArrowRight();
                        break;
                    case ConsoleKey.LeftArrow or ConsoleKey.A:
                        foreach (var arrowListener in arrowListeners)
                            arrowListener.OnArrowLeft();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
