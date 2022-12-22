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
            DrawTextureRec(textureManager.letters_texture, textureManager.letterRec(letter), position, Color.RAYWHITE);
        }
    }

    public class Text : UIElement
    {
        string content;
        Vector2 position;
        int fontSize;
        Color color;
        Font font;

        public Text(string content, Vector2 position, int fontSize, Color color, Font font)
        {
            this.content = content;
            this.position = position;
            this.fontSize = fontSize;
            this.color = color;
            this.font = font;
        }

        public void Draw()
        {
            DrawTextEx(font, content, position, fontSize, 3, color);
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
            DrawTextureV(sprite, position, Color.RAYWHITE);
        }
    }

    public class Button : UIElement
    {
        Texture2D regular;
        Texture2D alternative;
        Vector2 position;

        Color selected = new Color(217, 217, 217, 255);
        Color pressed = new Color(199, 199, 199, 255);
        Action pressAction;
        Action? hoverAction;

        public bool isHovering;

        public Button(Texture2D regular, /*Texture2D alternative,*/ Vector2 position, Action pressAction, Action? hoverAction = null)
        {
            this.regular = regular;
            //this.alternative = alternative;
            this.position = position;
            this.pressAction = pressAction;
            this.hoverAction = hoverAction;
        }

        public void Draw(/*int texture*/)
        {
            /*Texture2D sprite;
            if (texture == 0)
                sprite = regular;
            else
                sprite = alternative;*/

            if (CheckCollisionPointRec(GetMousePosition(), new Rectangle(position.X, position.Y, regular.width, regular.height)))
            {
                if (IsMouseButtonDown(0))
                {
                    DrawTextureV(regular, position, pressed);
                    pressAction();
                }
                else
                {
                    DrawTextureV(regular, position, selected);
                    isHovering = true;
                    if (hoverAction != null)
                        hoverAction();
                }
            }
            else
            {
                isHovering = false;
                DrawTextureV(regular, position, Color.RAYWHITE);
            }
        }
    }
}