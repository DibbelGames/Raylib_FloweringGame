using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class PotManager
    {
        private List<Pot> pots = new List<Pot>();
        internal List<Pot> Pots { get => pots; set => pots = value; }

        public void Main()
        {
            for (int i = 0; i < Pots.Count(); i++)
            {
                Pots[i].Tick();
            }
        }
    }

    class Pot : IActor, ITile
    {
        private Debugger debugger;
        private TextureManager textureManager;

        private Texture2D emptyPot;
        public int layer { get; set; } = 1;

        public Vector2 position { get; set; }
        public Plant? plant;

        public int id;

        //just for testing
        public int resources { get; set; } = 69;

        public Pot(TextureManager textureManager, Vector2 position, int layer, IGameScene scene)
        {
            this.textureManager = textureManager;
            this.position = position;
            this.layer = layer;
            this.debugger = new Debugger();

            scene.potManager.Pots.Add(this);
            scene.layerManager.actors.Add(this);
            this.id = scene.potManager.Pots.Count;

            this.emptyPot = this.textureManager.pot_empty;
        }

        public void AddPlant(string plant)
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
                //get stuff in inventory
            }
        }

        public void Tick()
        {
            debugger.Main();

            if (plant != null)
            {
                plant.Tick();
                debugger.ShowText(new DebugInfo("Name: " + plant.name, new Vector2(position.X + 64, position.Y), Color.DARKGRAY));
                debugger.ShowText(new DebugInfo("Size: " + plant.size, new Vector2(position.X + 64, position.Y + 20), Color.DARKGRAY));
                debugger.ShowText(new DebugInfo("isHarvestable: " + plant.isHarvestable(), new Vector2(position.X + 64, position.Y + 40), Color.DARKGRAY));
            }
            else
            {
                debugger.ShowText(new DebugInfo("Empty", new Vector2(position.X + 64, position.Y), Color.DARKGRAY));
            }
        }

        public void Draw()
        {
            if (plant != null)
            {
                DrawTextureRec(plant.texture, new Rectangle(64, 128 * plant.size, 64, 128), position, Color.RAYWHITE);
            }
            else
            {
                DrawTextureV(emptyPot, position, Color.RAYWHITE);
            }
        }
    }
}