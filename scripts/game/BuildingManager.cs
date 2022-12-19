using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class BuildingManager
    {
        private IGameScene scene;

        public bool isBuilding;

        private string selectedTile;

        public void Main()
        {
            if (!isBuilding) return;

            scene.uiManager.Draw(new Text("BUILDING", new Vector2(564, 10), 32, Color.BLACK));

            scene.uiManager.Draw(new Button(scene.textureManager.potButton, new Vector2(500, 500), () => SelectTile("pot")));

            if (Raylib.IsKeyPressed(KeyboardKey.KEY_SPACE))
            {
                PlaceTile();
            }
        }

        public void SelectTile(string tile)
        {
            selectedTile = tile;
        }

        public void PlaceTile()
        {
            if (selectedTile == "pot")
                new Pot(scene.textureManager, new Vector2(640, 320), scene.WINDOW_HEIGHT - 320, scene);
        }

        public void BuildingScreen()
        {
            isBuilding = !isBuilding;
        }

        public BuildingManager(IGameScene currentScene)
        {
            this.scene = currentScene;
        }
    }
}