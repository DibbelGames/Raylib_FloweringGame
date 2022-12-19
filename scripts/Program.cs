using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace GardeningGame
{
    static class Program
    {
        const int WINDOW_WIDTH = 1280;
        const int WINDOW_HEIGHT = 704;

        static IGameScene gamescene = new GameScene();

        public static void Main()
        {
            Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, "Gardening Game");
            Raylib.SetWindowIcon(LoadImage("img/ui/icon.png"));
            Raylib.SetTargetFPS(60);

            gamescene.Init();

            Raylib.CloseWindow();
        }
    }
}