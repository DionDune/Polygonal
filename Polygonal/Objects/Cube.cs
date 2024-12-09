using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class Cube : Object
    {
        public Cube(Vector3 Position, Color? Color, float SideLength)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();


            if (Color == null)
            {
                Random random = new Random();
                Color = new Color(random.Next(0, 63) * 4, random.Next(0, 63) * 4, random.Next(0, 63) * 4);
            }

            // Front Upper
            Faces.Add(new ObjectFace(
                new Vector3(SideLength, 0, 0),
                new Vector3(0, 0, 0),
                new Vector3(0, 0, SideLength),
                (Color)Color
                ));
            // Fron Lower
            Faces.Add(new ObjectFace(
                new Vector3(SideLength, 0, 0),
                new Vector3(0, 0, SideLength),
                new Vector3(SideLength, 0, SideLength),
                (Color)Color
                ));

            // Left Upper
            Faces.Add(new ObjectFace(
                new Vector3(0, 0, 0),
                new Vector3(0, SideLength, 0),
                new Vector3(0, 0, SideLength),
                (Color)Color
                ));
            // Left Lower
            Faces.Add(new ObjectFace(
                new Vector3(0, 0, SideLength),
                new Vector3(0, SideLength, 0),
                new Vector3(0, SideLength, SideLength),
                (Color)Color
                ));

            // Back Upper
            Faces.Add(new ObjectFace(
                new Vector3(0, SideLength, 0),
                new Vector3(SideLength, SideLength, 0),
                new Vector3(SideLength, SideLength, SideLength),
                (Color)Color
                ));
            // Back Lower
            Faces.Add(new ObjectFace(
                new Vector3(0, SideLength, 0),
                new Vector3(SideLength, SideLength, SideLength),
                new Vector3(0, SideLength, SideLength),
                (Color)Color
                ));

            // Right Upper
            Faces.Add(new ObjectFace(
                new Vector3(SideLength, SideLength, 0),
                new Vector3(SideLength, 0, 0),
                new Vector3(SideLength, SideLength, SideLength),
                (Color)Color
                ));
            // Right Lower
            Faces.Add(new ObjectFace(
                new Vector3(SideLength, SideLength, SideLength),
                new Vector3(SideLength, 0, 0),
                new Vector3(SideLength, 0, SideLength),
                (Color)Color
                ));

            // Top Upper
            Faces.Add(new ObjectFace(
                new Vector3(0, 0, 0),
                new Vector3(SideLength, 0, 0),
                new Vector3(0, SideLength, 0),
                (Color)Color
                ));
            // Top Lower
            Faces.Add(new ObjectFace(
                new Vector3(SideLength, 0, 0),
                new Vector3(SideLength, SideLength, 0),
                new Vector3(0, SideLength, 0),
                (Color)Color
                ));

            // Bottom Upper
            Faces.Add(new ObjectFace(
                new Vector3(SideLength, 0, SideLength),
                new Vector3(0, 0, SideLength),
                new Vector3(0, SideLength, SideLength),
                (Color)Color
                ));
            // Bottom Lower
            Faces.Add(new ObjectFace(
                new Vector3(SideLength, 0, SideLength),
                new Vector3(0, SideLength, SideLength),
                new Vector3(SideLength, SideLength, SideLength),
                (Color)Color
                ));
        }
    }
}
