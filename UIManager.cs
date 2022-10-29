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
        string? id { get; }
        void Draw();
    }

    public class Key_Prompt : UIElement
    {
        TextureManager textureManager;

        public string? id { get; set; }
        char letter;
        Vector2 position;

        public Key_Prompt(TextureManager textureManager, char letter, string id, Vector2 position)
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
}