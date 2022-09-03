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
        

        public Renderer(int height, int width, Camera camera)
        {
            Camera = camera;
            image = new Bitmap(height, width);
            ImgHeight = height;
            ImgWidth = width;
            ImgBuffer = new Color[ImgHeight,ImgWidth];
            FileName = "output2.bmp";
        }

        public void Render()
        {
            File.Delete(FileName);
            //int processors = Environment.ProcessorCount;
            int processors = 1;
            Task[] tasks = new Task[processors];
            for (int i = 0; i < processors; i++)
            {
                int segment = ImgWidth / processors;
                int min = segment * i;
                int max = segment * (i + 1);

                tasks[i] = Task.Factory.StartNew(() => RenderSection(
                    min,
                    max,
                    GenerateRandomColour()));
            }
            Task.WaitAll(tasks);
            SaveImage();
            
        }

        public void RenderSection(int xMin, int xMax, Color color)
        {
            for (int x = xMin; x < xMax; x++)
            {
                for (int y = 0; y < ImgHeight; y++)
                {
                    FibonacciCoreTester(0, 1, 1, 1000);
                    ImgBuffer[x, y] = color; 
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
            return Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
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
