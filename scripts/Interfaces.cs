using System;
using System.Numerics;
using Raylib_cs;

namespace GardeningGame
{
    public interface IGameScene
    {
        void Init();
        int WINDOW_WIDTH { get; }
        int WINDOW_HEIGHT { get; }
        TextureManager textureManager { get; }
        UIManager uiManager { get; }
        PotManager potManager { get; }
        BuildingManager buildingManager { get; }
        LayerManager layerManager { get; }
        Player player { get; }
    }
    public interface IActor
    {
        void Draw();
        int layer { get; set; }
    }
    public interface ITile
    {
        Vector2 position { get; }
        //just for testing
        int resources { get; }
    }
}