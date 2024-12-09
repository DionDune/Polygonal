using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Polygonal
{
    public class Settings
    {
        public Vector2 cameraFOV { get; set; }
        public bool cameraRenderWireFrames { get; set; }
        public bool cameraRenderPolygonEdges { get; set; }
        public bool cameraRenderFaces { get; set; }
        public float cameraMovementSpeed { get; set; }
        public float cameraRotationSpeed { get; set; }

        public bool objectsRandomPopulation { get; set; }
        public int objectsRandomCount { get; set; }
        public Vector3 objectSpawnRange { get; set; }

        public bool isRaining { get; set; }

        public Settings()
        {
            cameraFOV = new Vector2(120, 66);
            cameraMovementSpeed = 0.3f;
            cameraRotationSpeed = 1.2f;

            cameraRenderWireFrames = false;
            cameraRenderPolygonEdges = false;
            cameraRenderFaces = true;

            objectsRandomPopulation = true;
            objectsRandomCount = 1000;
            objectSpawnRange = new Vector3(150, 150, 20);

            isRaining = true;
        }
    }
}
