using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Sphere : Shape
    {
        public Material Material { get; set; }
        public Vector Point { get; set; }
        public double Radius { get; set; }

        public Sphere(Vector point, double radius, Material material)
        {
            Material = material;
            Point = point;
            Radius = radius;
        }

        public Vector Normal()
        {
            return null;
        }

        public bool CheckIntersection(Ray ray)
        {
            double a = ray.Direction.Dot(ray.Direction);
            double b = 2 * ray.Direction.Dot(ray.Origin);
            double c = ray.Origin.Dot(ray.Origin) - (Radius * Radius);

            double d = (b * b) - (4 * a * c);

            if (d < 0) return false;

            // if there is a sphere intersection, there must be 2 intersections.
            // Each distance is an intersection point
            double distance1 = (-b - Math.Sqrt(d)) / (2 * a);
            double distance2 = (-b + Math.Sqrt(d)) / (2 * a);

            if (distance1 < 0 && distance2 > 0) return false;
            else if (distance1 >= 0 && distance2 >= 0)
            {
                if (distance1 <= distance2) ray.Intersect(distance1, this);
                else ray.Intersect(distance2, this);
                return true;
            }

            return false;
        }
    }
}
