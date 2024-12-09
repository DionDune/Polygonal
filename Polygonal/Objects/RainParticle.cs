using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class RainParticle : Object
    {
        public int FrameLifespan { get; set; }

        private Vector3 Velocity { get; set; }
        private Vector3 VelocityChange { get; set; }
        private const int MaxSingleDirVelocity = 5; // Divided by 100

        private readonly Color Color = Color.Blue;

        public RainParticle(Vector3 Position, Vector3 VelocityChange, int FrameLifespan)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();
            this.Velocity = VelocityChange;
            this.VelocityChange = VelocityChange;
            this.FrameLifespan = FrameLifespan;

            float Width = Game1.random.Next(15, 25) / 100f;
            float Height = Game1.random.Next(30, 50) / 100f;
            float Rotation = Game1.random.Next(0, 91);

            Vector3 Point1 = new Vector3(0,0,0);
            Vector3 Point2 = new Vector3( Width * (float)Math.Cos( Rotation * (Math.PI / 180) ),
                                            Width * (float)Math.Sin( Rotation * (Math.PI / 180) ),
                                            0);
            Vector3 Point3 = new Vector3(Point1.X, Point1.Y, Height);
            Vector3 Point4 = new Vector3(Point2.X, Point2.Y, Height);

            // Upper 1
            Faces.Add(new ObjectFace(
                Point1,
                Point3,
                Point2,
                Color
                ));
            // Lower 1
            Faces.Add(new ObjectFace(
                Point2,
                Point3,
                Point4,
                Color
                ));
            // Upper 2
            Faces.Add(new ObjectFace(
                Point2,
                Point3,
                Point1,
                Color
                ));
            // Lower 2
            Faces.Add(new ObjectFace(
                Point4,
                Point3,
                Point2,
                Color
                ));
        }


        public override void Update(World world)
        {
            base.Update(world);

            if (!forDelete)
            {
                // Mark for deletion - Scale bellow cutoff point
                if (FrameLifespan <= 0)
                {
                    forDelete = true;
                    return;
                }

                // Move Particle
                this.Position += Velocity;

                FrameLifespan -= 1;
            }
        }
    }
}
