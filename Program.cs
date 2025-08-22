namespace XYZ_Snake
{
    public class Program
    {
        static void Main()
        {
            SnakeGameLogic gameLogic = new();
            ConsoleInput input = new();
            gameLogic.InitializeInput(input);
            var lastFrameTime = DateTime.Now;
            gameLogic.GotoGameplay();
            while (true)
            {
                input.Update();
                var frameStartTime = DateTime.Now;
                float deltaTime = (float)(frameStartTime - lastFrameTime).TotalSeconds;
                gameLogic.Update(deltaTime);
                lastFrameTime = frameStartTime;
            }
        }
    }
}