using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    class Debugger
    {
        private bool showInfo;

        public void Main()
        {
            if (IsKeyPressed(KeyboardKey.KEY_F3))
            {
                showInfo = !showInfo;
            }

            if (showInfo)
            {
                DrawFPS(0, 0);
            }
        }

        public void ShowText(DebugInfo info)
        {
            if (showInfo)
                DrawText(info.infoText, (int)info.position.X, (int)info.position.Y, 16, info.color);
        }

        public void ShowGizmo(Gizmo gizmo)
        {
            if (showInfo)
                gizmo.Draw();
        }
    }

    class DebugInfo
    {
        public string infoText;
        public Vector2 position;
        public Color color;

        public DebugInfo(string infoText, Vector2 position, Color color)
        {
            this.infoText = infoText;
            this.position = position;
            this.color = color;
        }
    }

    interface Gizmo
    {
        void Draw();
    }

    class G_Circle : Gizmo
    {
        private Vector2 position;
        private float radius;
        private Color color;

        public G_Circle(Vector2 position, float radius, Color color)
        {
            this.position = position;
            this.radius = radius;
            this.color = color;
        }

        public void Draw()
        {
            DrawCircleV(position, radius, color);
        }
    }
}