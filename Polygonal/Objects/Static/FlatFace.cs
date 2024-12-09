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
                        Point2,
                        Point3,
                        Point1,
                        (Color)Color));
            Faces.Add(new ObjectFace(
                        Point4,
                        Point3,
                        Point2,
                        (Color)Color));
        }
    }
}
