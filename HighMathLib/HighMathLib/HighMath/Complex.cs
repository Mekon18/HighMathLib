using System;

namespace HighMath
{
    public struct Complex
    {
        public double Imaginary { get; set; }
        public double Real { get; set; }

        public Complex(double a, double b)
        {
            Real = a;
            Imaginary = b;
            
        }

        public override string ToString()
        {
            if (double.IsNaN(Real) || double.IsNaN(Imaginary))
            {
                return "NaN";
            }
            if (Real == 0 && Imaginary == 0)
            {
                return "0";
            }
            string str = "";
            if (Real != 0)
            {
                str += Real;
            }
            if (Imaginary != 0)
                if (Real != 0)
                {
                    if (Math.Sign(Imaginary) == -1)
                    {
                        str += $" - {Math.Abs(Imaginary)}i";
                    }
                    else
                    {
                        str += $" + {Imaginary}i";
                    }
                }
                else
                {
                    str += Imaginary + "i";
                }
            return str;
        }

        public static Complex Parse(string str)
        {
            double r = 0;
            double i = 0;
            var parts = str.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            switch (parts.Length)
            {
                case 1:

                    if (parts[0].IndexOf('i') != -1)
                    {
                        i = double.Parse(parts[0].Remove(parts[0].Length - 1, 1));
                    }
                    else
                    {
                        r = double.Parse(parts[0]);
                    }
                    break;
                case 3:
                    r = double.Parse(parts[0]);
                    i = double.Parse(parts[2].Remove(parts[2].Length - 1, 1));
                    if (parts[1] == "-")
                        i *= -1;
                    break;
                default:
                    throw new FormatException();
            }
            return new Complex(r, i);
        }

        public double Abs()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }

        public static Complex operator +(double d, Complex c)
        {
            Complex res = new Complex(c.Real + d, c.Imaginary);
            return res;
        }
        public static Complex operator +(Complex c, double d)
        {
            Complex res = d + c;
            return res;
        }
        public static Complex operator +(Complex c1, Complex c2)
        {
            Complex res = new Complex(c1.Real + c2.Real, c1.Imaginary + c2.Imaginary);
            return res;
        }

        public static Complex operator -(double d, Complex c)
        {
            Complex res = new Complex(d - c.Real, c.Imaginary);
            return res;
        }
        public static Complex operator -(Complex c, double d)
        {
            Complex res = new Complex(c.Real - d, c.Imaginary);
            return res;
        }
        public static Complex operator -(Complex c1, Complex c2)
        {
            Complex res = new Complex(c1.Real - c2.Real, c1.Imaginary - c2.Imaginary);
            return res;
        }
        public static Complex operator -(Complex c)
        {
            return new Complex(-c.Real, -c.Imaginary);
        }

        public static Complex operator *(Complex c1, Complex c2)
        {
            Complex res = new Complex(c1.Real * c2.Real - c1.Imaginary * c2.Imaginary, c1.Real * c2.Imaginary + c1.Imaginary * c2.Real);
            return res;
        }
        public static Complex operator *(double d, Complex c)
        {
            Complex res = new Complex(d, 0) * c;
            return res;
        }
        public static Complex operator *(Complex c, double d)
        {
            Complex res = c * new Complex(d, 0);
            return res;
        }

        public static Complex operator /(Complex c1, Complex c2)
        {
            Complex res = new Complex((c1.Real * c2.Real + c1.Imaginary * c2.Imaginary) / (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary),
                (c2.Real * c1.Imaginary - c2.Imaginary * c1.Real) / (c2.Real * c2.Real + c2.Imaginary * c2.Imaginary));
            return res;
        }
        public static Complex operator /(double d, Complex c)
        {
            Complex res = new Complex(d, 0) / c;
            return res;
        }
        public static Complex operator /(Complex c, double d)
        {
            Complex res = c / new Complex(d, 0);
            return res;
        }
    }
}