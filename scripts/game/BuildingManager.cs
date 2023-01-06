using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class BuildingManager  //this ones an expecially junky spaghetti code
    {
        private IGameScene scene;
        private Debugger debugger;

        public List<ITile> tiles = new List<ITile>();

        public bool isBuilding;

        private Button select_potTile;

        private string selectedTile = "";

        public BuildingManager(IGameScene currentScene)
        {
            this.scene = currentScene;
            this.debugger = new Debugger();

            tiles.Add(new EmptyTile());
            select_potTile = new Button(scene.textureManager.potButton, new Vector2(1216, 640), () => SelectTile("pot"));
        }

        public void BuildingScreen()
        {
            isBuilding = !isBuilding;
        }

        public void Main()
        {
            for (int i = 0; i < tiles.Count(); i++)
            {
                tiles[i].Tick();
            }

            if (!isBuilding) return;

            //a probably way to clunky solution
            float mouse_x = GetMousePosition().X;
            float mouse_y = GetMousePosition().Y;

            int tile_x = 0;
            int tile_y = 0;

            if (selectedTile != "")
            {
                for (int width = 0; width < scene.WINDOW_WIDTH; width += scene.textureManager.gridtile.width)
                {
                    for (int height = 128; height < scene.WINDOW_HEIGHT; height += scene.textureManager.gridtile.height)
                    {
                        if (mouse_x > width && mouse_x < width + scene.textureManager.gridtile.width)
                        {
                            if (mouse_y > height && mouse_y < height + scene.textureManager.gridtile.height)
                            {
                                tile_x = width;
                                tile_y = height;

                                if (!canPlace(width, height))
                                    DrawTextureRec(scene.textureManager.placingSplacingIndicator, new Rectangle(0, 64, 64, 64), new Vector2(width, height), Color.RAYWHITE);
                                else if (!select_potTile.isHovering)
                                    DrawTextureRec(scene.textureManager.placingSplacingIndicator, new Rectangle(0, 128, 64, 64), new Vector2(width, height), Color.RAYWHITE);
                            }
                        }
                    }
                }
            }

            if (IsMouseButtonPressed(0) && canPlace(tile_x, tile_y) && !select_potTile.isHovering)
            {
                PlaceTile(new Vector2(tile_x, tile_y - 64));
            }

            //buildingMenu UI
            scene.uiManager.Draw(new Text("BUILDING", new Vector2(540, 10), 48, Color.BLACK, scene.textureManager.disco));
            scene.uiManager.Draw(select_potTile);
        }

        public void SelectTile(string tile)
        {
            selectedTile = tile;
        }

        public void PlaceTile(Vector2 position)
        {
            ITile newTile = new EmptyTile();
            if (selectedTile == "pot")
            {
                newTile = new Pot(scene.textureManager, position, scene.WINDOW_HEIGHT - (int)position.Y, scene);
            }

            tiles.Add(newTile);

            selectedTile = "";
        }

        private bool canPlace(int tile_x, int tile_y)
        {
            Vector2 mousePos = new Vector2(tile_x, tile_y - 64);
            for (int i = 0; i < tiles.Count; i++)
            {
                if (tiles[i].position == mousePos)
                {
                    return false;
                }
            }

            return true;
        }
    }

    class EmptyTile : ITile
    {
        public Vector2 position { get; set; } = new Vector2(6969, 420420);
        public int resources { get; set; }

        public void Tick() { }
    }
}
