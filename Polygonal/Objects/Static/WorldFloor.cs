using Microsoft.Xna.Framework;
using Polygonal.Objects.Static;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class WorldFloor : Object
    {
        public WorldFloor(Vector3 Position, World World)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();

            Vector2 Dimentions = new Vector2(50,50);
            Vector2 TileDimentions = new Vector2(1,1);

            Vector3 ColorDefault = new Vector3(134, 0, 179);//(0,204,0);
            Point TintRange = new Point(-50, 50);

            generateFloor(World, Position, Dimentions, TileDimentions, ColorDefault, TintRange);
        }

        private void generateFloor(World World, Vector3 Position, Vector2 Dimentions, Vector2 TileDimentions, Vector3 ColorDefault, Point TintRange)
        {
            // Generate Floor
            for (int Y = 0; Y < Dimentions.Y; Y++)
            {
                for (int X = 0; X < Dimentions.X; X++)
                {
                    Vector3 ColVect = getTileColor(ColorDefault, TintRange);

                    Vector3 WorldPosition = new Vector3(
                        Position.X + (X * TileDimentions.X),
                        Position.Y + (Y * TileDimentions.Y),
                        Position.Z
                        );

                    Vector3 Point1 = new Vector3(
                        0,
                        0,
                        0
                        );
                    Vector3 Point2 = new Vector3(
                        TileDimentions.X,
                        0,
                        0
                        );
                    Vector3 Point3 = new Vector3(
                        0,
                        TileDimentions.Y,
                        0
                        );
                    Vector3 Point4 = new Vector3(
                        TileDimentions.X,
                        TileDimentions.Y,
                        0
                        );


                    World.objects.Add(new FlatFace(
                        WorldPosition,
                        new Color((int)ColVect.X, (int)ColVect.Y, (int)ColVect.Z),
                        Point1,
                        Point2,
                        Point3,
                        Point4
                        ));
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
