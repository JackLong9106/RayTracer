using System.Numerics;

namespace RayTracer
{
    public class Camera
    {
        public Vector3 Position { get; set; }
        public Vector3 ViewUp { get; set; }
        public Vector3 ViewRight { get; set; }
        public Vector3 ViewNormal { get; set; }
        public double Fov { get; set; }
        public double AspectRatio { get; set; }
        public double CameraHeight { get; set; }
        public double CameraWidth{ get; set; }

        public Camera(Vector3 position, Vector3 lookAt, Vector3 viewUp, double fov, double aspectRatio)
        {
            Position = position;
            AspectRatio = aspectRatio;
            Fov = fov;

            ViewNormal = Vector3.Normalize(lookAt - position);
            ViewRight = Vector3.Normalize(Vector3.Cross(ViewNormal, viewUp));
            ViewUp = Vector3.Normalize(Vector3.Cross(ViewRight, ViewNormal));

            CameraHeight = Math.Atan(Math.Cos(Math.PI * fov / 180));
            CameraWidth = CameraHeight * aspectRatio;
        }
    }
}