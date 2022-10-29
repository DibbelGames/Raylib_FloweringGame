using Raylib_cs;
using static Raylib_cs.Raylib;
using static Raylib_cs.Color;

namespace GardeningGame
{
    static class Program
    {
        static int WINDOW_WIDTH = 1280;
        static int WINDOW_HEIGHT = 704;

        static GameScene gamescene = new GameScene();


        public static void Main()
        {
            Raylib.InitWindow(WINDOW_WIDTH, WINDOW_HEIGHT, "Gardening Game");
            Raylib.SetWindowIcon(LoadImage("img/icon.png"));
            Raylib.SetTargetFPS(60);

            gamescene.Main();

            while (!Raylib.WindowShouldClose())
            {
                //be useless
            }

            Raylib.CloseWindow();
        }
    }
}