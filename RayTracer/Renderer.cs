using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RayTracer
{
    public class Renderer
    {
        public Bitmap image { get; set; }
        public Camera Camera { get; set; }

        public Renderer(int height, int width, Camera camera)
        {
            Camera = camera;
            image = new Bitmap(height, width);
        }

        public void Render()
        {
            for (int x = 0; x < 1000; x++)
            {
                for (int y = 0; y < 1000; y++)
                {
                    image.SetPixel(x, y, Color.FromArgb(150, 150, 150));
                }
            }

            image.Save("output.bmp");
        }
      
    }
}
