using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Magnata.Components;

namespace Magnata
{
    class Gameobject
    {
        private List<Component> components;

        public Transform Transform { get; private set; }
        public Renderer Renderer { get; private set; }

        public float Scale { get; private set; }
        public bool Loaded { get; private set; }

        public Gameobject() : this(1)
        { }

        public Gameobject(float scale)
        {
            this.Scale = scale;
            this.Loaded = false;
            this.components = new List<Component>();
        }

        public void Update(GameTime time)
            => (from c in components where c is IUpdateable select c as IUpdateable).ToList().ForEach(iu => iu.Update(time));

        public void Draw(SpriteBatch sb)
            => (from c in components where c is IDrawable select c as IDrawable).ToList().ForEach(id => id.Draw(sb));

        public void Load()
        { 
            (from c in components where c is ILoadable select c as ILoadable).ToList().ForEach(il => il.Load());
            Loaded = true;
        }

        public void Unload()
        { 
            (from c in components where c is ILoadable select c as ILoadable).ToList().ForEach(il => il.Unload());
            Loaded = false;
        }

        public void AddComponent(Component comp)
        { 
            components.Add(comp);

            if (comp is IAddable)
                (comp as IAddable).Add();

            if (comp is Transform)
                Transform = comp as Transform;
            else if (comp is Renderer)
                Renderer = comp as Renderer;
        }

        public void RemoveComponent(Component comp)
        { 
            components.Remove(comp);

            if (comp is IRemoveable)
                (comp as IRemoveable).Remove();
        }

        public T GetComponent<T>() where T : Component
            => components.Find(c => c is T) as T;

        public Component GetComponent(Predicate<Component> filter)
            => components.Find(filter);

        public T[] GetComponents<T>() where T : Component
            => (from c in components where c is T select c as T).ToArray();

        public Component[] GetComponents(Predicate<Component> filter)
            => components.FindAll(filter).ToArray();
    }
}
