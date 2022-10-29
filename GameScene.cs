using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    class GameScene
    {
        static int WINDOW_WIDTH = 1280;
        static int WINDOW_HEIGHT = 704;

        static Texture2D gridtile;

        static Debugger debugger = new Debugger();
        static TextureManager textureManager = new TextureManager();
        static UIManager uiManager = new UIManager();
        static PotManager potManager = new PotManager();
        static Player player = new Player(textureManager, uiManager, potManager);

        Color bgColor = new Color(255, 235, 180, 255);

        public void Main()
        {
            Pot testingPot = new Pot(textureManager, new Vector2(640, 320));

            potManager.pots.Add(testingPot);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                for (int width = 0; width < WINDOW_WIDTH; width += textureManager.gridtile.width)
                {
                    for (int height = 0; height < WINDOW_HEIGHT; height += textureManager.gridtile.height)
                    {
                        DrawTexture(textureManager.gridtile, width, height, Color.RAYWHITE);
                    }
                }

                player.Main();
                potManager.Main();
                debugger.Main();

                Raylib.ClearBackground(bgColor);

                if (IsMouseButtonPressed(0))
                {
                    potManager.pots[0].addPlant("tomato");
                }

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}