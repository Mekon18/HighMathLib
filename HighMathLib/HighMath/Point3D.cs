namespace HighMath
{
    public struct Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }
        public override string ToString()
        {
            return $"({X}; {Y}; {Z})";
        }

        public static Point3D operator -(Point3D p1, Point3D p2)
        {
            Point3D res = new Point3D(p1.X, p1.Y, p1.Z);
            res.X -= p2.X;
            res.Y -= p2.Y;
            res.Z -= p2.Z;
            return res;
        }
        public static Point3D operator +(Point3D p1, Point3D p2)
        {
            Point3D res = new Point3D(p1.X, p1.Y, p1.Z);
            res.X += p2.X;
            res.Y += p2.Y;
            res.Z += p2.Z;
            return res;
        }
    }
}
