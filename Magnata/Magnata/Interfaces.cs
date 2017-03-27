using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Magnata
{
    interface IUpdateable
    {
        void Update(GameTime time);
    }

    interface IDrawable
    {
        void Draw(SpriteBatch sb);
    }

    interface ILoadable
    {
        void Load();
        void Unload();
    }

    interface IRemoveable
    {
        void Remove();
    }

    interface IAddable
    {
        void Add();
    }

    interface ICollider
    {
        Gameobject Gameobject { get; }
        bool CheckCollision(ICollider col);
        void OnCollision(Gameobject Other);
    }

    interface ICollisionEnter
    {
        void OnCollisionEnter();
    }

    interface ICollisionStay
    {
        void OnCollisionStay();
    }

    interface ICollisionExit
    {
        void OnCollisionExit();
    }
}
