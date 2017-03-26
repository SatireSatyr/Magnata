using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magnata.Other;

namespace Magnata.Components
{
    class Transform : Component
    {
        public Vector Position;

        public Transform(Gameobject go, Vector position) : base(go)
        {
            this.Position = position;
        }

        public void Translate(Vector v)
            => Position += v.IsNaN ? Vector.Zero : v;
    }
}
