using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magnata.Other
{
    public class Vector
    {
        #region Operators
        public static Vector operator + (Vector lhs, Vector rhs)
            => new Vector(lhs.X + rhs.X, lhs.Y + rhs.Y);
        public static Vector operator - (Vector lhs, Vector rhs)
            => new Vector(lhs.X - rhs.X, lhs.Y - rhs.Y);
        public static Vector operator * (Vector lhs, float rhs)
            => new Vector(lhs.X * rhs, lhs.Y * rhs);
        public static Vector operator * (Vector lhs, int rhs)
            => new Vector(lhs.X * rhs, lhs.Y * rhs);
        public static Vector operator / (Vector lhs, float rhs)
            => new Vector(lhs.X / rhs, lhs.Y / rhs);
        public static Vector operator / (Vector lhs, int rhs)
            => new Vector(lhs.X / rhs, lhs.Y / rhs);
        public static bool operator == (Vector lhs, Vector rhs)
            => lhs.X == rhs.X && lhs.Y == rhs.Y;
        public static bool operator != (Vector lhs, Vector rhs)
            => !(lhs == rhs);
        #endregion

        #region Properties
        private object xKey = new object();
        private object yKey = new object();

        private float _y;
        private float _x;

        public float X
        {
            get { lock (xKey) { return _x; } }
            set { lock (xKey) { _x = value; } }
        }
        public float Y
        {
            get { lock(yKey) { return _y; } }
            set { lock(yKey) { _y = value; } }
        }

        public int Xint
        {
            get { return (int)X; }
            set { X = value; }
        }
        public int Yint
        {
            get { return (int)Y; }
            set { Y = value; }
        }

        public float Length { get { return (float)Math.Sqrt(X * X + Y * Y); } }
        public Vector Normalized { get { return new Vector(X / Length, Y / Length); } }
        public bool IsNaN { get { return float.IsNaN(X + Y); } }
        
        public static Vector Zero { get { return new Vector(0, 0); } }
        #endregion

        #region Constructors
        public Vector(float x, float y)
        {
            this.X = x;
            this.Y = y;
        }

        public Vector(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }
        #endregion
    }
}
