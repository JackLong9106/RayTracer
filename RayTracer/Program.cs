using RayTracer;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Diagnostics;

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Starting...");
        ConfigReader config = new ConfigReader();

        Camera camera = new Camera(
            new Vector(1, 1, 0),
            new Vector(0, 0, 0),
            new Vector(0, 1, 0),
            20,
            (double)config.ImageWidth / config.ImageHeight
            );

        Sphere s = new Sphere(new Vector(0,0,0), 0.3, new Material(1,1, Color.Blue, false));

        Renderer renderer = new Renderer(config, camera, s);

        Stopwatch stopWatch = new Stopwatch();
        stopWatch.Start();
        renderer.Render();
        stopWatch.Stop();

        TimeSpan ts = stopWatch.Elapsed;

        string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",
            ts.Hours, ts.Minutes, ts.Seconds,
            ts.Milliseconds / 10);
        Console.WriteLine("Finished...");
        Console.WriteLine("RunTime " + elapsedTime);
    }
}