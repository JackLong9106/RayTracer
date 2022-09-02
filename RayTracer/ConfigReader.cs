using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class ConfigReader
    {
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }
        public Vector3 Position { get; set; }
        public Vector3 LookAt { get; set; }
        public Vector3 DefaultViewUp { get; set; }
        public double Fov { get; set; }

        public ConfigReader()
        {
            foreach (string line in File.ReadLines("config.ini"))
            {
                if(line.Contains(":")) HandleLine(line);
            }
        }

        private void HandleLine(string line)
        {
            string setting = line.Split(':')[0].Trim();
            string contents = line.Split(':')[1].Trim();

            if (setting == "ImageHeight") ImageHeight = int.Parse(contents);
            if (setting == "ImageWidth") ImageWidth = int.Parse(contents);
            if (setting == "Position") Position = StringToVector(contents);
            if (setting == "LookAt") LookAt = StringToVector(contents);
            if (setting == "DefaultViewUp") DefaultViewUp = StringToVector(contents);
            if (setting == "Fov") Fov = double.Parse(contents);
        }

        private Vector3 StringToVector(string vectStr)
        {
            string[] points = vectStr.Split(',');
            Vector3 vector = new Vector3
                (
                    float.Parse(points[0]),
                    float.Parse(points[1]),
                    float.Parse(points[2])
                );
            return vector;
        }
    }
}
