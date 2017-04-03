using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magnata.MapTools;

namespace Magnata
{
    public class Map
    {
        private const int MapCoordinateConversionRate = 16;

        private Tile[,] map;

        private int width;
        private int height;

        public Map()
            : this(300, 300, 100, 0, MapType.Varied)
        { }

        public Map(int width, int height)
            : this(width, height, 100, 0, MapType.Varied)
        { }

        public Map(int width, int height, int maxAltitude, int waterHeight)
            : this(width, height, maxAltitude, waterHeight, MapType.Varied)
        { }

        public Map(int width, int height, int maxAltitude, int waterHeight, MapType mapType)
        {
            this.width = width;
            this.height = height;
            this.map = new Tile[width, height];

            for(int i = 0; i < width; i ++)
                for (int j = 0; j < height; j ++)
                {

                }
        }
    }
}
