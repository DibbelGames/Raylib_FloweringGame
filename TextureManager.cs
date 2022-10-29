using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class TextureManager
    {
        public Texture2D gridtile = LoadTexture("img/gridtile.png");
        public Texture2D playerTexture = LoadTexture("img/player_placeholder.png");
        public Texture2D pot_empty = LoadTexture("img/pot_empty.png");
        public Texture2D[] plant_textures = new Texture2D[]{
            LoadTexture("img/pot_empty.png"),
            LoadTexture("img/pot_tomato.png"),
            LoadTexture("img/pot_blumato.png")
        };
        public Texture2D letters_texture = LoadTexture("img/font.png");

        public Rectangle letterRec(char letter)
        {
            char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            return new Rectangle(0, 64 * (Array.IndexOf(letters, letter)), 64, 64);
        }
    }
}