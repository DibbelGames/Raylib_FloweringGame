using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class Player : IActor
    {
        private Debugger debugger = new Debugger();
        private IGameScene scene;

        public Vector2 position;
        public Vector2 handPosition;

        private int stepSize = 64;
        private int moveTime = 16; //only 8, 16, 32... (no idea why, probably because stepsize/movetime needs to be even)

        private bool isMoving;
        private int tickCounter;

        private Vector2 currentDirection;

        public int layer { get; set; } = 0;

        //just for testing
        public int resources = 420;

        public Player(IGameScene currentScene)
        {
            this.scene = currentScene;

            scene.layerManager.actors.Add(this);
        }

        public void Main()
        {
            debugger.Main();

            Movement();
            PotControl();
            BuildingControl();

            debugger.ShowGizmo(new G_Circle(handPosition, 3, Color.BLUE));
        }

        void PotControl()
        {
            Pot? pot = null;
            foreach (Pot p in scene.potManager.Pots)
            {
                if (p.position == handPosition - new Vector2(32, 96))
                {
                    pot = p;
                }
            }

            if (pot == null)
                return;

            if (pot.plant == null)
            {
                if (IsKeyPressed(KeyboardKey.KEY_E))
                {
                    pot.AddPlant("tomato");
                }
                scene.uiManager.Draw(new Key_Prompt(scene.textureManager, 'e', pot.position));
            }
            else if (pot.plant.isHarvestable())
            {
                if (IsKeyPressed(KeyboardKey.KEY_F))
                {
                    pot.Harvest();
                }
                scene.uiManager.Draw(new Key_Prompt(scene.textureManager, 'f', pot.position - new Vector2(0, 64)));
            }
        }

        void BuildingControl()
        {
            if (IsKeyPressed(KeyboardKey.KEY_Q) && !isMoving)
            {
                scene.buildingManager.BuildingScreen();
            }
        }

        void Movement()
        {
            if (scene.buildingManager.isBuilding) return;

            if (tickCounter < moveTime)
                tickCounter++;
            else
                isMoving = false;

            if (isMoving)
                position += currentDirection * (stepSize / moveTime);

            TakeInput();

            handPosition = position + currentDirection * stepSize + new Vector2(32, 32);
        }

        void TakeInput()
        {
            if (IsKeyDown(KeyboardKey.KEY_D))
                Move(new Vector2(1, 0));
            if (IsKeyDown(KeyboardKey.KEY_A))
                Move(new Vector2(-1, 0));
            if (IsKeyDown(KeyboardKey.KEY_W))
                Move(new Vector2(0, -1));
            if (IsKeyDown(KeyboardKey.KEY_S))
                Move(new Vector2(0, 1));

            if (IsKeyDown(KeyboardKey.KEY_RIGHT))
                Look(new Vector2(1, 0));
            if (IsKeyDown(KeyboardKey.KEY_LEFT))
                Look(new Vector2(-1, 0));
            if (IsKeyDown(KeyboardKey.KEY_UP))
                Look(new Vector2(0, -1));
            if (IsKeyDown(KeyboardKey.KEY_DOWN))
                Look(new Vector2(0, 1));
        }

        void Move(Vector2 direction)
        {
            if (!isMoving)
            {
                this.currentDirection = direction;

                foreach (Pot pot in scene.potManager.Pots)
                {
                    if (pot.position == (position + direction * stepSize) - new Vector2(0, 64))
                        return;
                }

                isMoving = true;
                tickCounter = 0;
            }
        }

        void Look(Vector2 direction)
        {
            if (!isMoving)
            {
                this.currentDirection = direction;
            }
        }

        public void Draw()
        {
            DrawTextureV(scene.textureManager.playerTexture, position, Color.RAYWHITE);
        }
    }
}