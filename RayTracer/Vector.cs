using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Vector
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Vector(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vector(Vector vectA, Vector vectB)
        {
            X = vectA.X - vectB.X;
            Y = vectA.Y - vectB.Y;
            Z = vectA.Z - vectB.Z;
        }

        public void Normalize()
        {
            double currentLength = CalculateLength();

            X = X / currentLength;
            Y = Y / currentLength;
            Z = Z / currentLength;
        }

        public double CalculateLength()
        {
            return Math.Sqrt(Math.Pow(X, 2) + Math.Pow(Y, 2) + Math.Pow(Z, 2));
        }

        public Vector Cross(Vector vect)
        {
            return new Vector
                ((Y * vect.Z) - (Z * vect.Y),
                (Z * vect.X) - (Y * vect.Z),
                (X * vect.Y) - (X * vect.X));
        }

        public double Dot(Vector vect)
        {
            return (X * vect.X) + (Y * vect.Y) + (Z * vect.Z);
        }

        public Vector Inverse()
        {
            return new Vector(-X, -Y, -Z);
        }

        public Vector Multiply(double val)
        {
            return new Vector(X * val, Y * val, Z * val);
        }
        
        public Vector Divide(double val)
        {
            return new Vector(X / val, Y / val, Z / val);
        }

        public Vector Subtract(Vector vect)
        {
            return new Vector(X - vect.X, Y - vect.Y, Z - vect.Z);
        }
        
        public Vector Add(Vector vect)
        {
            return new Vector(X + vect.X, Y + vect.Y, Z + vect.Z);
        }

        public override string ToString()
        {
            return $"{X},{Y},{Z}";
        }
    }
}
