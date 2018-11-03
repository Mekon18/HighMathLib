using System;

namespace HighMath
{
    public struct Vector
    {
        private double _x;
        private double _y;
        private double _z;
        public double X { get { return _x; } set { _x = value; GetLength(); } }
        public double Y { get { return _y; } set { _y = value; GetLength(); } }
        public double Z { get { return _z; } set { _z = value; GetLength(); } }
        public double Length { get; private set; }

        public Vector(double x, double y, double z) : this()
        {
            X = x;
            Y = y;
            Z = z;
        }
        private void GetLength()
        {
            Length = Math.Sqrt(X * X + Y * Y + Z * Z);
        }

        public override string ToString()
        {
            return $"({X}; {Y}; {Z})";
        }

        #region operators
        public static Vector operator +(Vector v1, Vector v2)
        {
            return new Vector(v1.X + v2.X, v1.Y + v2.Y, v1.Z + v2.Z);
        }
        public static Vector operator -(Vector v1, Vector v2)
        {
            return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
        }
        public static Vector operator *(Vector v, double a)
        {
            return new Vector(v.X * a, v.Y * a, v.Z * a);
        }
        public static Vector operator /(Vector v, double a)
        {
            return new Vector(v.X / a, v.Y / a, v.Z / a);
        }
        public static Vector operator *(double a, Vector v)
        {
            return new Vector(v.X * a, v.Y * a, v.Z * a);
        }
        public static Vector operator /(double a, Vector v)
        {
            return new Vector(v.X / a, v.Y / a, v.Z / a);
        }
        public static Vector operator -(Vector v)
        {
            return new Vector(-v.X, -v.Y, -v.Z);
        }
        #endregion

        public static Vector Point3DToVector(Point3D p)
        {
            Vector V = new Vector(p.X, p.Y, p.Z);
            return V;
        }

        public static double ScalarMultiplying(Vector v1, Vector v2)
        {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public static double GetCos(Vector v1, Vector v2)
        {
            return ScalarMultiplying(v1, v2) / (v1.Length * v2.Length);
        }
    }
}
