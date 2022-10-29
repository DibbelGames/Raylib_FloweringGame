using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    class PotManager
    {
        public List<Pot> pots = new List<Pot>();

        public void Main()
        {
            for (int i = 0; i < pots.Count(); i++)
            {
                pots[i].Tick();
            }
        }
    }

    class Pot
    {
        private Debugger debugger = new Debugger();
        private TextureManager textureManager;

        private Texture2D emptyPot;

        public Vector2 position;
        public Plant? plant;

        public Pot(TextureManager textureManager, Vector2 position)
        {
            this.textureManager = textureManager;
            this.position = position;

            this.emptyPot = this.textureManager.pot_empty;
        }

        public void addPlant(string plant)
        {
            if (this.plant == null)
            {
                this.plant = new Plant("plants/" + plant + ".json", textureManager);
            }
        }

        public void Harvest()
        {
            if (plant != null && plant.isHarvestable())
            {
                plant = null;
                //get stiff in inventory
            }
        }

        public void Tick()
        {
            debugger.Main();

            if (plant != null)
            {
                plant.Tick();
                DrawTextureRec(plant.texture, new Rectangle(64, 128 * plant.size, 64, 128), position, Color.RAYWHITE);
                debugger.ShowText(new DebugInfo("Name: " + plant.name, new Vector2(position.X + 64, position.Y), Color.DARKGRAY));
                debugger.ShowText(new DebugInfo("Size: " + plant.size, new Vector2(position.X + 64, position.Y + 20), Color.DARKGRAY));
                debugger.ShowText(new DebugInfo("isHarvestable: " + plant.isHarvestable(), new Vector2(position.X + 64, position.Y + 40), Color.DARKGRAY));
            }
            else
            {
                DrawTextureV(emptyPot, position, Color.RAYWHITE);
                debugger.ShowText(new DebugInfo("Empty", new Vector2(position.X + 64, position.Y), Color.DARKGRAY));
            }
        }
    }
}