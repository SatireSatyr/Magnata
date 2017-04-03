using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnataUnitTest
{
    class TestComponent : Magnata.Components.Component, Magnata.IUpdateable, Magnata.IDrawable, Magnata.ILoadable, Magnata.IRemoveable, Magnata.IAddable
    {
        public bool Updated = false;
        public bool Drawed = false;
        public bool Loaded = false;
        public bool Unloaded = false;
        public bool Removed = false;
        public bool Added = false;

        public TestComponent(Magnata.Gameobject go) : base(go)
        { }

        void Magnata.IUpdateable.Update(Microsoft.Xna.Framework.GameTime time)
            => Updated = true;

        void Magnata.IDrawable.Draw(Microsoft.Xna.Framework.Graphics.SpriteBatch sb)
            => Drawed = true;

        void Magnata.ILoadable.Load()
            => Loaded = true;

        void Magnata.ILoadable.Unload()
            => Unloaded = true;

        void Magnata.IRemoveable.Remove()
            => Removed = true;

        void Magnata.IAddable.Add()
            => Added = true;
    }
}
