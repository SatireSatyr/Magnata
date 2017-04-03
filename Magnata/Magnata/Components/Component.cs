using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magnata.Components
{
    public class Component
    {
        public Gameobject Gameobject { get; private set; }
        public Transform Transform { get { return Gameobject.Transform; } }
        public Renderer Renderer { get { return Gameobject.Renderer; } }

        public Component(Gameobject go)
        {
            this.Gameobject = go;
        }
    }
}
