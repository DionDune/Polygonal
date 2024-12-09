using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class MorphingCube : Object
    {
        private bool Shrinking { get; set; }
        private Vector2 ScaleRange { get; set; }
        private float ScaleChangeRate { get; set; }


        public MorphingCube(Vector3 Position)
        {
            this.Position = new Vector3(10, 10, -5);
            this.Faces = new List<ObjectFace>();

            Shrinking = true;
            float DefaultSideLength = 2f;
            this.ScaleRange = new Vector2(0.1f, 2f);
            this.ScaleChangeRate = 0.02f;
            Color? Color = Microsoft.Xna.Framework.Color.Red;
            


            if (Color == null)
            {
                Random random = new Random();
                Color = new Color(random.Next(0, 63) * 4, random.Next(0, 63) * 4, random.Next(0, 63) * 4);
            }

            // Front Upper
            Faces.Add(new ObjectFace(
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(-(DefaultSideLength / 2), -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(-(DefaultSideLength / 2), -(DefaultSideLength / 2), DefaultSideLength / 2),
                (Color)Color
                ));
            // Fron Lower
            Faces.Add(new ObjectFace(
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(-(DefaultSideLength / 2), -(DefaultSideLength / 2), DefaultSideLength / 2),
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), DefaultSideLength / 2),
                (Color)Color
                ));

            // Left Upper
            Faces.Add(new ObjectFace(
                new Vector3(-(DefaultSideLength / 2), -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, -(DefaultSideLength / 2)),
                new Vector3(-(DefaultSideLength / 2), -(DefaultSideLength / 2), DefaultSideLength / 2),
                (Color)Color
                ));
            // Left Lower
            Faces.Add(new ObjectFace(
                new Vector3(-(DefaultSideLength / 2), -(DefaultSideLength / 2), DefaultSideLength / 2),
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, -(DefaultSideLength / 2)),
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, DefaultSideLength / 2),
                (Color)Color
                ));

            // Back Upper
            Faces.Add(new ObjectFace(
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, -(DefaultSideLength / 2)),
                new Vector3(DefaultSideLength / 2, DefaultSideLength / 2, -(DefaultSideLength / 2)),
                new Vector3(DefaultSideLength / 2, DefaultSideLength / 2, DefaultSideLength / 2),
                (Color)Color
                ));
            // Back Lower
            Faces.Add(new ObjectFace(
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, -(DefaultSideLength / 2)),
                new Vector3(DefaultSideLength / 2, DefaultSideLength / 2, DefaultSideLength / 2),
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, DefaultSideLength / 2),
                (Color)Color
                ));

            // Right Upper
            Faces.Add(new ObjectFace(
                new Vector3(DefaultSideLength / 2, DefaultSideLength / 2, -(DefaultSideLength / 2)),
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(DefaultSideLength / 2, DefaultSideLength / 2, DefaultSideLength / 2),
                (Color)Color
                ));
            // Right Lower
            Faces.Add(new ObjectFace(
                new Vector3(DefaultSideLength / 2, DefaultSideLength / 2, DefaultSideLength / 2),
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), DefaultSideLength / 2),
                (Color)Color
                ));

            // Top Upper
            Faces.Add(new ObjectFace(
                new Vector3(-(DefaultSideLength / 2), -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, -(DefaultSideLength / 2)),
                (Color)Color
                ));
            // Top Lower
            Faces.Add(new ObjectFace(
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), -(DefaultSideLength / 2)),
                new Vector3(DefaultSideLength / 2, DefaultSideLength / 2, -(DefaultSideLength / 2)),
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, -(DefaultSideLength / 2)),
                (Color)Color
                ));

            // Bottom Upper
            Faces.Add(new ObjectFace(
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), DefaultSideLength / 2),
                new Vector3(-(DefaultSideLength / 2), -(DefaultSideLength / 2), DefaultSideLength / 2),
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, DefaultSideLength / 2),
                (Color)Color
                ));
            // Bottom Lower
            Faces.Add(new ObjectFace(
                new Vector3(DefaultSideLength / 2, -(DefaultSideLength / 2), DefaultSideLength / 2),
                new Vector3(-(DefaultSideLength / 2), DefaultSideLength / 2, DefaultSideLength / 2),
                new Vector3(DefaultSideLength / 2, DefaultSideLength / 2, DefaultSideLength / 2),
                (Color)Color
                ));
        }



        public override void Update(World world)
        {
            base.Update(world);

            // Shrinking
            if (Shrinking)
            {
                if (Scale - ScaleChangeRate <= ScaleRange.X)
                    Shrinking = false;
                else 
                    Scale -= ScaleChangeRate;
            }
            // Growing
            else
            {
                if (Scale + ScaleChangeRate >= ScaleRange.Y)
                    Shrinking = true;
                else
                    Scale += ScaleChangeRate;
            }
        }
    }
}
