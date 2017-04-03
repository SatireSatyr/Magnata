using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Magnata
{
    public interface IUpdateable
    {
        void Update(GameTime time);
    }

    public interface IDrawable
    {
        void Draw(SpriteBatch sb);
    }

    public interface ILoadable
    {
        void Load();
        void Unload();
    }

    public interface IRemoveable
    {
        void Remove();
    }

    public interface IAddable
    {
        void Add();
    }
}
