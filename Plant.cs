using System.IO;
using System.Text.Json;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    class Plant
    {
        private Debugger debugger = new Debugger();

        public Texture2D texture;

        public string? name;
        private float growRate;
        private float maxSize;

        public int size;

        private int tickCounter;

        public Plant(string jsonRef, TextureManager textureManager)
        {
            string text = File.ReadAllText(jsonRef);
            var type = JsonSerializer.Deserialize<Type>(text);

            if (type != null)
            {
                this.name = type.name;
                this.growRate = type.growRate;
                this.maxSize = type.maxSize;
                this.texture = textureManager.plant_textures[type.textureID];
            }
        }

        public void Grow()
        {
            if (!isHarvestable())
                size++;
        }

        public void Tick()
        {
            tickCounter++;
            if (tickCounter == growRate)
            {
                Grow();
                tickCounter = 0;
            }
        }

        public bool isHarvestable()
        {
            if (size >= maxSize)
                return true;
            else
                return false;
        }
    }

    class Type
    {
        public string? name { get; set; }
        public int textureID { get; set; }
        public int growRate { get; set; }
        public int maxSize { get; set; }
    }
}