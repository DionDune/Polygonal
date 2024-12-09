using Microsoft.Xna.Framework;
using Polygonal.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal
{
    public class Object
    {
        public Vector3 Position { get; set; }
        public List<ObjectFace> Faces { get; set; }
        public float Scale { get; set; }
        public bool forDelete { get; set; }

        public Object()
        {
            Scale = 1.0f;
            forDelete = false;
        }

        public virtual void Update(World world)
        {

        }
        public static void UpdateObjects(World world)
        {
            foreach (Object obj in world.objects)
            {
                obj.Update(world);
            }
        }


        public static List<Object> getRandom(int Count, Vector3 Range)
        {
            Random random = new Random();
            List<Object> Objects = new List<Object>();


            for (int i = 0; i < Count; i++)
            {
                Object Obj = new Object();

                if (random.Next(0,2) == 0)
                {
                    Obj = new Cube(new Vector3(random.Next(0, (int)Range.X), random.Next(0, (int)Range.Y), random.Next(0, (int)Range.Z)),
                                    null, 1);
                }
                else
                {
                    Obj = new TriangleBasedPrism(new Vector3(random.Next(0, (int)Range.X), random.Next(0, (int)Range.Y), random.Next(0, (int)Range.Z)),
                                                    null, true, 1);
                }

                Objects.Add(Obj);
            }


            return Objects;
        }
    }

    public class ObjectFace
    {
        public Vector3 Vertex1 { get; set; }
        public Vector3 Vertex2 { get; set; }
        public Vector3 Vertex3 { get; set; }

        public Color Color { get; set; }

        public ObjectFace(Vector3 Vert1, Vector3 Vert2, Vector3 Vert3, Color Color)
        {
            Vertex1 = Vert1;
            Vertex2 = Vert2;
            Vertex3 = Vert3;

            this.Color = Color;
        }
    }
}
