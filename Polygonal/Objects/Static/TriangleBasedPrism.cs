using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class TriangleBasedPrism : Object
    {
        public TriangleBasedPrism(Vector3 Position, Color? Color, bool defaultColors, float SideLength)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();



            if (Color == null)
            {
                Random random = new Random();
                Color = new Color(random.Next(0, 63) * 4, random.Next(0, 63) * 4, random.Next(0, 63) * 4);
            }

            // Lower Front Left
            Vector3 Point1 = new Vector3(0, 0, 0);

            // Lower Back 
            Vector3 Point2 = new Vector3(SideLength / 2, SideLength, 0);

            // Lower Front Right
            Vector3 Point3 = new Vector3(SideLength, 0, 0);

            // Upper Point
            Vector3 Point4 = new Vector3(SideLength / 2, SideLength / 2, -SideLength);


            if (defaultColors)
            {
                // Front 
                Faces.Add(new ObjectFace(
                    Point1,
                    Point3,
                    Point4,
                    Microsoft.Xna.Framework.Color.Red
                    ));
                // Left
                Faces.Add(new ObjectFace(
                    Point1,
                    Point4,
                    Point2,
                    Microsoft.Xna.Framework.Color.Green
                    ));
                // Right
                Faces.Add(new ObjectFace(
                    Point2,
                    Point4,
                    Point3,
                    Microsoft.Xna.Framework.Color.Turquoise
                    ));
                // Bottom
                Faces.Add(new ObjectFace(
                    Point1,
                    Point2,
                    Point3,
                    Microsoft.Xna.Framework.Color.White
                    ));
            }
            else
            {
                // Front 
                Faces.Add(new ObjectFace(
                    Point1,
                    Point3,
                    Point4,
                    (Color)Color
                    ));
                // Left
                Faces.Add(new ObjectFace(
                    Point1,
                    Point4,
                    Point2,
                    (Color)Color
                    ));
                // Right
                Faces.Add(new ObjectFace(
                    Point2,
                    Point4,
                    Point3,
                    (Color)Color
                    ));
                // Bottom
                Faces.Add(new ObjectFace(
                    Point1,
                    Point2,
                    Point3,
                    (Color)Color
                    ));
            }
        }

        public static List<ObjectFace> getUniform(float SideLength, Color? Color, bool defaultColors)
        {
            List<ObjectFace> Faces = new List<ObjectFace>();

            if (Color == null)
            {
                Random random = new Random();
                Color = new Color(random.Next(0, 63) * 4, random.Next(0, 63) * 4, random.Next(0, 63) * 4);
            }

            // Lower Front Left
            Vector3 Point1 = new Vector3(0,0,0);

            // Lower Back 
            Vector3 Point2 = new Vector3(SideLength / 2, SideLength, 0);

            // Lower Front Right
            Vector3 Point3 = new Vector3(SideLength, 0, 0);

            // Upper Point
            Vector3 Point4 = new Vector3(SideLength / 2, SideLength / 2, -SideLength);


            if (defaultColors)
            {
                // Front 
                Faces.Add(new ObjectFace(
                    Point1,
                    Point3,
                    Point4,
                    Microsoft.Xna.Framework.Color.Red
                    ));
                // Left
                Faces.Add(new ObjectFace(
                    Point1,
                    Point4,
                    Point2,
                    Microsoft.Xna.Framework.Color.Green
                    ));
                // Right
                Faces.Add(new ObjectFace(
                    Point2,
                    Point4,
                    Point3,
                    Microsoft.Xna.Framework.Color.Turquoise
                    ));
                // Bottom
                Faces.Add(new ObjectFace(
                    Point1,
                    Point2,
                    Point3,
                    Microsoft.Xna.Framework.Color.White
                    ));
            }
            else
            {
                // Front 
                Faces.Add(new ObjectFace(
                    Point1,
                    Point3,
                    Point4,
                    (Color)Color
                    ));
                // Left
                Faces.Add(new ObjectFace(
                    Point1,
                    Point4,
                    Point2,
                    (Color)Color
                    ));
                // Right
                Faces.Add(new ObjectFace(
                    Point2,
                    Point4,
                    Point3,
                    (Color)Color
                    ));
                // Bottom
                Faces.Add(new ObjectFace(
                    Point1,
                    Point2,
                    Point3,
                    (Color)Color
                    ));
            }


            return Faces;
        }
    }
}
