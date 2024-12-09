using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class WorldFloor : Object
    {
        public WorldFloor(Vector3 Position)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();

            Vector2 Dimentions = new Vector2(50,50);
            Vector2 TileDimentions = new Vector2(2,2);

            Vector3 ColorDefault = new Vector3(134, 0, 179);//(0,204,0);
            Point TintRange = new Point(-50, 50);
            

            for (int Y = 0; Y < Dimentions.Y; Y++)
            {
                for (int X = 0; X < Dimentions.X; X++)
                {
                    Vector3 ColVect = getTileColor(ColorDefault, TintRange);
                    Color Col = new Color((int)ColVect.X, (int)ColVect.Y, (int)ColVect.Z);
                    Vector3 Origin = new Vector3(
                        Position.X + (X * TileDimentions.X),
                        Position.Y + (Y * TileDimentions.Y),
                        Position.Z
                        );

                    Faces.Add( new ObjectFace(
                        new Vector3(Origin.X + TileDimentions.X, Origin.Y, Origin.Z),
                        new Vector3(Origin.X, Origin.Y + TileDimentions.Y, Origin.Z),
                        new Vector3(Origin.X, Origin.Y, Origin.Z),
                        new Color((int)ColVect.X, (int)ColVect.Y, (int)ColVect.Z)) );
                    Faces.Add(new ObjectFace(
                        new Vector3(Origin.X + TileDimentions.X, Origin.Y + TileDimentions.Y, Origin.Z),
                        new Vector3(Origin.X, Origin.Y + TileDimentions.Y, Origin.Z),
                        new Vector3(Origin.X + TileDimentions.X, Origin.Y, Origin.Z),
                        new Color((int)ColVect.X, (int)ColVect.Y, (int)ColVect.Z)));
                }
            }
        }


        private Vector3 getTileColor(Vector3 Color, Point TintRange)
        {
            Random random = new Random();

            // Apply Ligh/Dark tint
            int TintOffset = random.Next(TintRange.X, TintRange.Y);
            Color.X += TintOffset;
            Color.Y += TintOffset;
            Color.Z += TintOffset;

            // Color Correction
            if (Color.X > 255)
                Color.X = 255;
            else if (Color.X < 0)
                Color.X = 0;
            if (Color.Y > 255)
                Color.Y = 255;
            else if (Color.Y < 0)
                Color.Y = 0;
            if (Color.Z > 255)
                Color.Z = 255;
            else if (Color.Z < 0)
                Color.Z = 0;

            return Color;
        }
    }
}
