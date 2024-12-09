using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class RainSpawner : Object
    {
        private const int ParticleSpawnChanceDivisor = 1;
        public Vector2 SpawnDistanceRange = new Vector2(-55, 55);
        public static readonly Vector3 CameraFollowDistance = new Vector3(0,0,-25);
        public bool Enabled = true;

        public RainSpawner(Vector3 Position)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();
        }

        public override void Update(World world)
        {
            base.Update(world);

            // Spawn Particle
            if (Enabled)
                if (Game1.random.Next(0, ParticleSpawnChanceDivisor) == 0)
                {
                    // Position
                    Vector3 ParticlePos = new Vector3(
                        this.Position.X + (float)Game1.random.Next((int)(SpawnDistanceRange.X * 10), (int)(SpawnDistanceRange.Y * 10)) / 10f,
                        this.Position.Y + (float)Game1.random.Next((int)(SpawnDistanceRange.X * 10), (int)(SpawnDistanceRange.Y * 10)) / 10f,
                        this.Position.Z
                        );


                    // Lifespan
                    int ParticleFrameLifespan = 250;

                    // Velocity Change
                    Vector3 ParticleVelocity = new Vector3(
                        0, 0, 0.24f
                        );

                    Object Particle = new RainParticle(ParticlePos, ParticleVelocity, ParticleFrameLifespan);
                    world.Atmosphere.AddParticle( Particle );
                    world.objectsNew.Add( Particle );
                }
        }
    }
}
