using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magnata.Other;

namespace Magnata.Components
{
    public class Transform : Component
    {
        private Vector _position;
        private object key = new object();

        public Vector Position
        {
            get { lock(key) { return _position;  } }
            set { lock(key) { _position = value; } }
        }

        public Transform(Gameobject go, Vector position) : base(go)
        {
            this.Position = position;
        }

        public void Translate(Vector v)
            => Position += v.IsNaN ? Vector.Zero : v;
    }
}
