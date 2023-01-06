using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class Sink : ITile
    {
        public IGameScene scene;

        public Vector2 position { get; set; }

        public Sink(Vector2 position, IGameScene scene)
        {
            this.position = position;
            this.scene = scene;
        }

        public void Tick()
        {
            DrawTextureV(scene.textureManager.sink, position, Color.RAYWHITE);
        }
    }
}