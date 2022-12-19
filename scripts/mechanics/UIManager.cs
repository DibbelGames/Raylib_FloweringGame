using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class UIManager
    {
        public void Draw(UIElement element)
        {
            element.Draw();
        }
    }

    public interface UIElement
    {
        void Draw();
    }

    public class Key_Prompt : UIElement
    {
        TextureManager textureManager;

        char letter;
        Vector2 position;

        public Key_Prompt(TextureManager textureManager, char letter, Vector2 position)
        {
            this.textureManager = textureManager;
            this.letter = letter;
            this.position = position;
        }

        public void Draw()
        {
            Raylib.DrawTextureRec(textureManager.letters_texture, textureManager.letterRec(letter), position, Color.RAYWHITE);
        }
    }

    public class Text : UIElement
    {
        string content;
        Vector2 position;
        int fontSize;
        Color color;

        public Text(string content, Vector2 position, int fontSize, Color color)
        {
            this.content = content;
            this.position = position;
            this.fontSize = fontSize;
            this.color = color;
        }

        public void Draw()
        {
            Raylib.DrawText(content, (int)position.X, (int)position.Y, fontSize, color);
        }
    }

    public class Image : UIElement
    {
        Texture2D sprite;
        Vector2 position;

        public Image(Texture2D sprite, Vector2 position)
        {
            this.sprite = sprite;
            this.position = position;
        }

        public void Draw()
        {
            Raylib.DrawTextureV(sprite, position, Color.RAYWHITE);
        }
    }

    public class Button : UIElement
    {
        Texture2D sprite;
        Vector2 position;

        Color selected = new Color(217, 217, 217, 255);
        Color pressed = new Color(199, 199, 199, 255);
        Action action;

        public Button(Texture2D sprite, Vector2 position, Action action)
        {
            this.sprite = sprite;
            this.position = position;
            this.action = action;
        }

        public void Draw()
        {
            if (Raylib.CheckCollisionPointRec(Raylib.GetMousePosition(), new Rectangle(position.X, position.Y, sprite.width, sprite.height)))
            {
                if (Raylib.IsMouseButtonDown(0))
                {
                    Raylib.DrawTextureV(sprite, position, pressed);
                    action();
                }
                else
                {
                    Raylib.DrawTextureV(sprite, position, selected);
                }
            }
            else
            {
                Raylib.DrawTextureV(sprite, position, Color.RAYWHITE);
            }
        }
    }
}