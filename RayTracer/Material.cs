using System;
using System.Drawing;

namespace RayTracer
{
    public class Material
    {
        public double DiffuseCoef { get; set; }
        public double SpecularCoef { get; set; }
        public Color Color { get; set; }
        public bool IsReflective { get; set; }

        public Material(double diffuseCoef, double specularCoef, Color color, bool isReflective)
        {
            DiffuseCoef = diffuseCoef;
            SpecularCoef = specularCoef;
            Color = color;
            IsReflective = isReflective;
        }
    }
}
