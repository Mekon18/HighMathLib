using System;

namespace HighMath
{
    public struct Quaternion
    {
        public double A { get; set; }
        public double B { get; set; }
        public double C { get; set; }
        public double D { get; set; }

        public Quaternion(double a, double b, double c, double d)
        {
            A = a;
            B = b;
            C = c;
            D = d;
        }

        public override string ToString()
        {
            string str = $"{A}";
            if (Math.Sign(B) == -1)
            {
                str += $" - {Math.Abs(B)}i";
            }
            else
            {
                str += $" + {B}i";
            }
            if (Math.Sign(C) == -1)
            {
                str += $" - {Math.Abs(C)}j";
            }
            else
            {
                str += $" + {C}j";
            }
            if (Math.Sign(D) == -1)
            {
                str += $" - {Math.Abs(D)}k";
            }
            else
            {
                str += $" + {D}k";
            }
            return str;
        }

        public static Quaternion operator *(Quaternion q1, Quaternion q2)
        {
            double A = q1.A * q2.A - q1.B * q2.B - q1.C * q2.C - q1.D * q2.D;
            double B = q1.A * q2.B + q1.B * q2.A + q1.C * q2.D - q1.D * q2.C;
            double C = q1.A * q2.C + q1.C * q2.A + q1.D * q2.B - q1.B * q2.D;
            double D = q1.A * q2.D + q1.D * q2.A + q1.B * q2.C - q1.C * q2.B;
            Quaternion q = new Quaternion(A, B, C, D);
            return q;
        }
        public static Quaternion operator *(Point3D p1, Quaternion q2)
        {
            Quaternion q1 = new Quaternion(0, p1.X, p1.Y, p1.Z);
            return q1 * q2;
        }
        public static Quaternion operator *(Quaternion q1, Point3D p2)
        {
            Quaternion q2 = new Quaternion(0, p2.X, p2.Y, p2.Z);
            return q1 * q2;
        }

        public Point3D ToPoint3D()
        {
            return new Point3D(B, C, D);
        }
        public Vector ToVector()
        {
            return new Vector(B, C, D);
        }
    }
}
