using System.Numerics;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    class Player
    {
        private Debugger debugger = new Debugger();
        private TextureManager textures;
        private UIManager ui;
        private PotManager potManager;

        private Vector2 position;
        private Vector2 handPosition;

        private int stepSize = 64;
        private int moveTime = 16; //only 8, 16, 32... (no idea why, maybe because stepsize/movetime needs to be even)

        private bool isMoving;
        private int tickCounter;

        private Vector2 currentDirection;

        public Player(TextureManager textures, UIManager uIManager, PotManager potManager)
        {
            this.textures = textures;
            this.potManager = potManager;
            this.ui = uIManager;
        }

        public void Main()
        {
            debugger.Main();

            Movement();
            PotControl();

            DrawTextureV(textures.playerTexture, position, Color.RAYWHITE);
            debugger.ShowGizmo(new G_Circle(handPosition, 3, Color.BLUE));
        }

        public void PotControl()
        {
            Pot? pot = null;
            foreach (Pot p in potManager.pots)
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
                ui.Draw(new Key_Prompt(textures, 'e', "planting_e-prompt", pot.position));
                if (IsKeyPressed(KeyboardKey.KEY_E))
                {
                    pot.addPlant("blumato");
                }
            }
            else if (pot.plant.isHarvestable())
            {
                ui.Draw(new Key_Prompt(textures, 'e', "harvesting_f-prompt", pot.position));
                if (IsKeyPressed(KeyboardKey.KEY_F))
                {
                    pot.Harvest();
                }
            }
        }

        public void Movement()
        {
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
        }

        void Move(Vector2 direction)
        {
            if (!isMoving)
            {
                this.currentDirection = direction;

                foreach (Pot pot in potManager.pots)
                {
                    if (pot.position == (position + direction * stepSize) - new Vector2(0, 64))
                        return;
                }

                isMoving = true;
                tickCounter = 0;
            }
        }
    }
}