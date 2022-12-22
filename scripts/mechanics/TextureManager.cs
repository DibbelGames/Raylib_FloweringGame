using Raylib_cs;
using System.Numerics;
using System.Collections.Generic;
using static Raylib_cs.Raylib;

namespace GardeningGame
{
    public class TextureManager
    {
        public Texture2D gridtile = LoadTexture("img/gridtile.png");
        public Texture2D playerTexture = LoadTexture("img/player/player_placeholder.png");

        //plants
        public Texture2D pot_empty = LoadTexture("img/plants/pot_empty.png");
        public Texture2D[] plant_textures = new Texture2D[]{
            LoadTexture("img/plants/pot_empty.png"),
            LoadTexture("img/plants/pot_tomato.png"),
            LoadTexture("img/plants/pot_blumato.png")
        };

        //ui
        public Texture2D potButton = LoadTexture("img/ui/building/building_button_pot.png");
        public Texture2D placingSplacingIndicator = LoadTexture("img/ui/building/placing_indicator.png");

        //font
        public Texture2D letters_texture = LoadTexture("img/ui/font.png");
        public Rectangle letterRec(char letter)
        {
            char[] letters = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
            return new Rectangle(0, 64 * (Array.IndexOf(letters, letter)), 64, 64);
        }

        public Font disco = LoadFontEx("fonts/DigitalDisco.ttf", 64, null, 250);
    }
}