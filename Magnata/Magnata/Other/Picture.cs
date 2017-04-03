using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Magnata.Other
{
    public static class Picture
    {
        private class ImageInfo
        {
            public Texture2D image;
            public int Loaded;

            public ImageInfo(Texture2D image)
            {
                this.image = image;
                this.Loaded = 1;
            }
        }

        private static Dictionary<string, ImageInfo> images;
        private static ContentManager cm;

        public static void Initialize(ContentManager cm)
        {
            Picture.cm = cm;
        }

        public static Texture2D GetImage(string key)
        {
            if (!images.ContainsKey(key))
                images.Add(key, new ImageInfo(cm.Load<Texture2D>($@"Content\Sprites\{key}")));

            return images[key].image;
        }


        public static string GetKey(Texture2D image)
            => images.First(kv => kv.Value.image == image).Key;

        public static void Load(string key)
        {
            if (images.ContainsKey(key))
                images[key].Loaded++;
            else
                images.Add(key, new ImageInfo(cm.Load<Texture2D>($@"Content\Sprites\{key}")));
        }

        public static void Unload(string key)
        {
            images[key].Loaded--;

            if (images[key].Loaded == 0)
                images.Remove(key);
        }
    }
}
