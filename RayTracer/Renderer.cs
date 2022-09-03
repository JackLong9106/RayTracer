using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Renderer
    {
        public Bitmap image { get; set; }
        public Camera Camera { get; set; }
        public int ImgHeight { get; set; }
        public int ImgWidth { get; set; }
        public Color[,] ImgBuffer { get; set; }
        public string FileName { get; set; }
        public ConfigReader Config { get; set; }
        public Shape Shape1 { get; set; }

        private Color[] RandomDebugColors;
        private const int DebugColourLengthColor = 20;
        private const double DebugColourMissReduction = 0.1;

        public Renderer(ConfigReader config, Camera camera, Shape shape)
        {
            Config = config;
            Camera = camera;
            image = new Bitmap(Config.ImageWidth, Config.ImageHeight);
            ImgWidth = Config.ImageHeight;
            ImgHeight = Config.ImageHeight;
            ImgBuffer = new Color[ImgHeight, ImgWidth];
            FileName = "output2.bmp";
            Shape1 = shape;

            if (config.IsDebugCoreMode)
            {
                RandomDebugColors = new Color[DebugColourLengthColor];
                for (int i = 0; i < DebugColourLengthColor; i++)
                {
                    RandomDebugColors[i] = GenerateRandomColour();
                }
            }
        }

        public void Render()
        {
            File.Delete(FileName);
            int processors = Environment.ProcessorCount;
            //int processors = 1;
            Task[] tasks = new Task[processors];
            for (int i = 0; i < processors; i++)
            {
                int segment = ImgWidth / processors;
                int min = segment * i;
                int max = segment * (i + 1);

                tasks[i] = Task.Factory.StartNew(() => RenderSection(
                    min,
                    max,
                    i));
            }
            Task.WaitAll(tasks);
            SaveImage();
            
        }

        public void RenderSection(int xMin, int xMax, int core)
        {
            for (int x = xMin; x < xMax; x++)
            {
                for (int y = 0; y < ImgHeight; y++)
                {
                    Vector screenCoordinate = new Vector((2.0 * x) / ImgWidth - 1.0, (-2.0 * y) / ImgHeight + 1.0, 0.0); 
                    Ray ray = Camera.CreateRay(screenCoordinate);
                    Shape1.CheckIntersection(ray);

                    if (ray.DidIntersect)
                    {
                        ImgBuffer[x, y] = ray.IntersectionShape.Material.Color;
                    }
                    else ImgBuffer[x, y] = Color.Black;

                    //Debug
                    if (Config.Debug)
                    {
                        if (Config.IsDebugCoreMode) DebugCore(x, y, core, ray);
                    }
                }
            }
        }

        public void SaveImage()
        {
            for (int x = 0; x < ImgWidth; x++)
            {
                for (int y = 0; y < ImgHeight; y++)
                {
                    image.SetPixel(x, y, ImgBuffer[x, y]);
                }
            }
            Console.WriteLine($"Saving image as {FileName}");
            image.Save(FileName);
        }

        private Color GenerateRandomColour()
        {
            Random r = new Random();
            return Color.FromArgb(r.Next(30, 255), r.Next(30, 255), r.Next(30, 255));
        }

        private void DebugCore(int x, int y, int core, Ray ray)
        {
            FibonacciCoreTester(0, 1, 1, 1000); //Slows down to simulate higher complexity

            Color debugColourHit = RandomDebugColors[core];
            Color debugColourMiss = Color.FromArgb(
                Convert.ToInt32(debugColourHit.R * DebugColourMissReduction),
                Convert.ToInt32(debugColourHit.G * DebugColourMissReduction),
                Convert.ToInt32(debugColourHit.B * DebugColourMissReduction));

            if (ray.DidIntersect) ImgBuffer[x, y] = debugColourHit;
            else ImgBuffer[x, y] = debugColourMiss;
        }
        
        private static void FibonacciCoreTester(double a, double b, double counter, double len)
        {
            if (counter <= len)
            {
                FibonacciCoreTester(b, a + b, counter + 1, len);
            }
        }

    }
}
