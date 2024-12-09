using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class Particle : Object
    {
        public int FrameLifespan { get; set; }
        private float ShrinkRate { get; set; }
        private const float ScaleCutoff = 0.1f;

        private Vector3 Velocity { get; set; }

        public Particle(Vector3 Position, Color? Color, float InitialSize, int FrameLifespan, Vector3 Velocity)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();

            ShrinkRate = InitialSize / (float)FrameLifespan;
            this.Velocity = Velocity;




            if (Color == null)
            {
                Random random = new Random();
                Color = new Color(random.Next(0, 63) * 4, random.Next(0, 63) * 4, random.Next(0, 63) * 4);
            }

            // Lower Front Left
            Vector3 Point1 = new Vector3(0, 0, 0);
            // Lower Back 
            Vector3 Point2 = new Vector3(InitialSize / 2, InitialSize, 0);
            // Lower Front Right
            Vector3 Point3 = new Vector3(InitialSize, 0, 0);
            // Upper Point
            Vector3 Point4 = new Vector3(InitialSize / 2, InitialSize / 2, -InitialSize);

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

        public override void Update(World world)
        {
            base.Update(world);

            if (!forDelete)
            {
                // Mark for deletion - Scale bellow cutoff point
                if (this.Scale - this.ShrinkRate <= ScaleCutoff)
                {
                    forDelete = true;
                    return;
                }

                // Shrink particle
                this.Scale -= this.ShrinkRate;

                // Move Particle
                this.Position += Velocity;
            }
        }
    }
}
