using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Ray
    {
        public Vector Origin { get; set; }
        public Vector Direction { get; set; }
        public Vector? IntersectionPoint { get; set; }
        public Shape? IntersectionShape { get; set; }
        public bool DidIntersect { get; set; }

        public const double RAY_MIN = 0.0000000001;
        public const double RAY_MAX = double.MaxValue;

        public Ray(Vector origin, Vector direction)
        {
            Origin = origin;
            Direction = direction;
            IntersectionPoint = null;
            IntersectionShape = null;
            DidIntersect = false;
        }

        public void Intersect(double dist, Shape shape)
        {
            DidIntersect = true;
            IntersectionShape = shape;
            IntersectionPoint = CalculatePoint(dist);
        }

        public Vector CalculatePoint(double dist)
        {          
            return Origin.Add(Direction).Multiply(dist);
        }
    }
}
