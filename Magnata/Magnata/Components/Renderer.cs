using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Magnata.Components
{
    class Renderer : Component, IDrawable, ILoadable, IAddable, IRemoveable
    {
        private string _sourceTexture;
        private Texture2D _sourceTexture2D;

        public string SourceTextureName
        {
            get { return _sourceTexture; }
            set
            {
                //Handles swapping of values
                string temp = _sourceTexture;
                _sourceTexture = value;

                //Handles loading & Unloading of pictures
                if (Gameobject.Loaded)
                {
                    Other.Picture.Load(value);
                    _sourceTexture2D = Other.Picture.GetImage(value);
                    Other.Picture.Unload(temp);
                }
            }
        }
        public Texture2D SourceTexture
        { get { return _sourceTexture2D == null ? _sourceTexture2D = Other.Picture.GetImage(SourceTextureName) : _sourceTexture2D; } }
        public Rectangle? SourceRectangle { get; private set; }
        public Color Color { get; set; }

        public Renderer(Gameobject go, string sourceTexture)
            : this(go, sourceTexture, null, Color.White)
        { }

        public Renderer(Gameobject go, string sourceTexture, Rectangle? sourceRectangle)
            : this(go, sourceTexture, sourceRectangle, Color.White)
        { }

        public Renderer(Gameobject go, string sourceTexture, Rectangle? sourceRectangle, Color color)
            : base(go)
        {
            this.SourceTextureName = sourceTexture;
            this.SourceRectangle = sourceRectangle == null ? new Rectangle(0, 0, SourceTexture.Width, SourceTexture.Height) : sourceRectangle.Value;
            this.Color = Color;
        }

        public void Draw(SpriteBatch sb)
            => sb.Draw(SourceTexture, new Rectangle(Transform.Position.Xint, Transform.Position.Yint,
                (int)((SourceRectangle == null ? SourceTexture.Width : SourceRectangle.Value.Width) * Gameobject.Scale), 
                (int)((SourceRectangle == null ? SourceTexture.Height : SourceRectangle.Value.Height) * Gameobject.Scale)), 
                SourceRectangle, Color);

        public void Unload()
            => Other.Picture.Unload(SourceTextureName);

        public void Load()
            => Other.Picture.Load(SourceTextureName);

        public void Add()
        {
            if (Gameobject.Loaded)
                Other.Picture.Load(SourceTextureName);
        }

        public void Remove()
        {
            if (Gameobject.Loaded)
                Other.Picture.Unload(SourceTextureName);
        }
    }
}
