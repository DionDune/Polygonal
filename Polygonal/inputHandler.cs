using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal
{
    internal class inputHandler
    {
        private List<Keys> PreviouseKeys;

        public inputHandler()
        {
            PreviouseKeys = new List<Keys>();
        }



        public void execute(Settings settings, Camera camera, World world, Screen _screen)
        {
            List<Keys> CurrentKeys = Keyboard.GetState().GetPressedKeys().ToList();


            Point ScreenCentre = new Point(_screen.Position.X + _screen.Dimentions.X / 2, _screen.Position.Y + _screen.Dimentions.Y / 2);
            Vector2 MouseCentreOffset = new Vector2((float)Mouse.GetState().X - ScreenCentre.X);
            camera.Rotate(new Vector2(MouseCentreOffset.X / 20f, 0));
            Mouse.SetPosition(ScreenCentre.X, ScreenCentre.Y);



            if (CurrentKeys.Contains(Keys.W))
                camera.MoveForward(settings);
            else if (CurrentKeys.Contains(Keys.S))
                camera.MoveBackward(settings);
            if (CurrentKeys.Contains(Keys.A))
                camera.MoveLeftward(settings);
            else if (CurrentKeys.Contains(Keys.D))
                camera.MoveRightward(settings);

            if (CurrentKeys.Contains(Keys.Space))
                camera.MoveUpward(settings);
            else if (CurrentKeys.Contains(Keys.LeftControl))
                camera.MoveDownward(settings);

            if (CurrentKeys.Contains(Keys.Left) || CurrentKeys.Contains(Keys.Q))
                camera.RotateHorizontal(settings, true);
            else if (CurrentKeys.Contains(Keys.Right) || CurrentKeys.Contains(Keys.E))
                camera.RotateHorizontal(settings, false);
            if (CurrentKeys.Contains(Keys.Up))
                camera.RotateVertical(settings, true);
            else if (CurrentKeys.Contains(Keys.Down))
                camera.RotateVertical(settings, false);



            if (isNewPress(Keys.T, CurrentKeys) == true)
                settings.cameraRenderWireFrames = !settings.cameraRenderWireFrames;
            if (isNewPress(Keys.Y, CurrentKeys) == true)
                settings.cameraRenderFaces = !settings.cameraRenderFaces;
            if (isNewPress(Keys.U, CurrentKeys) == true)
                settings.cameraRenderPolygonEdges = !settings.cameraRenderPolygonEdges;

            //Atmosphere
            if (isNewPress(Keys.R, CurrentKeys) == true)
                world.Atmosphere.isRaining = !world.Atmosphere.isRaining;



            PreviouseKeys = CurrentKeys;
        }

        private bool? isNewPress(Keys Key, List<Keys> CurrentKeys)
        {
            if (CurrentKeys.Contains(Key) && PreviouseKeys.Contains(Key))
                return false;
            if (CurrentKeys.Contains(Key) && !PreviouseKeys.Contains(Key))
                return true;
            else
                return null;
        }

    }
}
