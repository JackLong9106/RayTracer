
namespace RayTracer
{
    public class Camera
    {
        public Vector Position { get; set; }
        public Vector ViewUp { get; set; }
        public Vector ViewRight { get; set; }
        public Vector ViewNormal { get; set; }
        public double Fov { get; set; }
        public double AspectRatio { get; set; }
        public double CameraHeight { get; set; }
        public double CameraWidth{ get; set; }

        public Camera(Vector position, Vector lookAt, Vector viewUp, double fov, double aspectRatio)
        {
            Position = position;
            AspectRatio = aspectRatio;
            Fov = fov;

            ViewNormal = lookAt.Subtract(position);
            viewUp.Normalize();

            ViewRight = ViewNormal.Cross(viewUp);
            ViewNormal.Normalize();

            ViewUp = ViewRight.Cross(ViewNormal);

            CameraHeight = Math.Atan(Math.Cos(Math.PI * fov / 180));
            CameraWidth = CameraHeight * aspectRatio;
        }

        public Ray CreateRay(Vector point)
        {
            Vector directionRight = ViewRight.Multiply(point.X);
            directionRight = directionRight.Multiply(CameraWidth);

            Vector directionUp = ViewUp.Multiply(point.Y);
            directionUp = directionUp.Multiply(CameraHeight);

            Vector direction = ViewNormal.Add(directionRight);
            direction = direction.Add(directionUp);
            direction.Normalize();

            return new Ray(Position, direction); ;
        }

        public void Print()
        {
            Console.WriteLine($"Position: {Position}");
            Console.WriteLine($"ViewUp: {ViewUp}");
            Console.WriteLine($"ViewRight: {ViewRight}");
            Console.WriteLine($"ViewNormal: {ViewNormal}");
            Console.WriteLine($"Fov: {Fov}");
            Console.WriteLine($"AspectRatio: {AspectRatio}");
            Console.WriteLine($"CameraHeight: {CameraHeight}");
            Console.WriteLine($"CameraWidth: {CameraWidth}");
        }
    }
}