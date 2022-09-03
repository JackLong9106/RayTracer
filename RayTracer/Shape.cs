using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public interface Shape
    {
        public Material Material { get; set; }
        public Vector Normal();
        public bool CheckIntersection(Ray ray);
    }
}
