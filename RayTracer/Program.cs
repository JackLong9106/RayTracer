using RayTracer;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Numerics;

public class Program
{
    public static void Main(string[] args)
    {
        ConfigReader config = new ConfigReader();

        Camera camera = new Camera(
            new Vector3(1, 1, 0),
            new Vector3(0, 0, 0),
            new Vector3(0, 1, 0),
            20,
            (double)config.ImageWidth / config.ImageHeight
            );

        Renderer renderer = new Renderer(config.ImageHeight, config.ImageWidth, camera);
    }
}