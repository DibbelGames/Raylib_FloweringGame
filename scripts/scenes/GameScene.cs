using Raylib_cs;
using System.Numerics;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    class GameScene : IGameScene
    {
        public int WINDOW_WIDTH { get; set; } = 1280;
        public int WINDOW_HEIGHT { get; set; } = 704;

        static Texture2D gridtile;

        private Debugger debugger = new Debugger();
        public LayerManager layerManager { get; set; } = new LayerManager();
        public TextureManager textureManager { get; set; } = new TextureManager();
        public UIManager uiManager { get; set; } = new UIManager();
        public PotManager potManager { get; set; } = new PotManager();
        public BuildingManager buildingManager { get; set; }
        public Player player { get; set; }

        Color bgColor = new Color(255, 235, 180, 255);

        public GameScene()
        {
            buildingManager = new BuildingManager(this);
            player = new Player(this);
        }

        public void Init()
        {
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

                layerManager.Main();
                player.Main();
                potManager.Main();
                buildingManager.Main();
                debugger.Main();

                Raylib.ClearBackground(bgColor);

                /*if (IsMouseButtonPressed(0))
                {
                    potManager.pots[0].AddPlant("tomato");
                }*/

                Raylib.EndDrawing();
            }

            Raylib.CloseWindow();
        }
    }
}