using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects.Static
{
    public class FlatFace : Object
    {
        public FlatFace(Vector3 Position, Color? Color, Vector3 Point1, Vector3 Point2, Vector3 Point3, Vector3 Point4)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();

            if (Color == null)
            {
                Random random = new Random();
                Color = new Color(random.Next(0, 63) * 4, random.Next(0, 63) * 4, random.Next(0, 63) * 4);
            }

            Faces.Add(new ObjectFace(
                        new Vector3(Point2.X, Point2.Y, Point2.Z),
                        new Vector3(Point3.X, Point3.Y, Point3.Z),
                        new Vector3(Point1.X, Point1.Y, Point1.Z),
                        (Color)Color));
            Faces.Add(new ObjectFace(
                        new Vector3(Point4.X, Point4.Y, Point4.Z),
                        new Vector3(Point3.X, Point3.Y, Point3.Z),
                        new Vector3(Point2.X, Point2.Y, Point2.Z),
                        (Color)Color));
        }
    }
}
