using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Magnata.Other;

namespace Magnata.MapTools
{
    public class Tile : ILoadable
    {
        private bool loaded = false;

        public Vector Position;
        public int Altitude;
        public MapType Type;
        public Texture2D Texture { get; private set; }
        public string TextureName { get; private set; }

        private float buildingCostMultiplier;
        private float roadCostMultiplier;

        public Tile(Vector position, int altitude, MapType type, string texture)
        {
            this.Position = position;
            this.Altitude = altitude;
            this.Type = type;
            this.TextureName = texture;
        }

        public Tile(Vector position, int altitude, MapType type, Texture2D texture)
            : this(position, altitude, type, Picture.GetKey(texture))
        { }

        public void Load()
        {
            Picture.Load(TextureName);
            this.Texture = Picture.GetImage(TextureName);
        }

        public void Unload()
        {
            this.Texture = null;
            Picture.Unload(TextureName);
        }

        public int CalcBuildprice(int basePrice, bool isRoad)
            => (int)(isRoad ? basePrice * roadCostMultiplier : basePrice * buildingCostMultiplier);
    }
}
