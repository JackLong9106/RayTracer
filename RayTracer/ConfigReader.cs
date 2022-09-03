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
        //Render
        public int ImageHeight { get; set; }
        public int ImageWidth { get; set; }

        //Camera
        public Vector Position { get; set; }
        public Vector LookAt { get; set; }
        public Vector DefaultViewUp { get; set; }
        public double Fov { get; set; }

        //Debug
        public bool IsDebugCoreMode { get; set; }

        public ConfigReader()
        {
            Console.WriteLine("Reading config.ini");
            foreach (string line in File.ReadLines("config.ini"))
            {
                if(line.Contains(":")) HandleLine(line);
            }
            Console.WriteLine("Done reading config.ini: ");
        }

        private void HandleLine(string line)
        {
            string setting = line.Split(':')[0].Trim();
            string contents = line.Split(':')[1].Trim();

            //Render
            if (setting == "ImageHeight") ImageHeight = int.Parse(contents);
            if (setting == "ImageWidth") ImageWidth = int.Parse(contents);
            //Camera
            if (setting == "Position") Position = StringToVector(contents);
            if (setting == "LookAt") LookAt = StringToVector(contents);
            if (setting == "DefaultViewUp") DefaultViewUp = StringToVector(contents);
            if (setting == "Fov") Fov = double.Parse(contents);
            if (setting == "CoreRenderDebug") IsDebugCoreMode = StringToBool(contents);
            //Debug
            if (setting == "CoreRenderDebug") IsDebugCoreMode = StringToBool(contents);
            if (IsDebugCoreMode == true) Console.WriteLine("DEBUG MODE: Rendering core view");
        }

        private Vector StringToVector(string vectStr)
        {
            string[] points = vectStr.Split(',');
            Vector vector = new Vector
                (
                    float.Parse(points[0]),
                    float.Parse(points[1]),
                    float.Parse(points[2])
                );
            return vector;
        }
        
        private bool StringToBool(string boolStr)
        {
            bool result = false;
            if (boolStr == "1") result = true;
            return result;
        }
    }
}
