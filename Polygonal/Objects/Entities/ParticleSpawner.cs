using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal.Objects
{
    public class ParticleSpawner : Object
    {
        private const int ParticleSpawnChanceDivisor = 5;
        private const int MaxSingleDirVelocity = 5; // Divided by 100

        public ParticleSpawner(Vector3 Position)
        {
            this.Position = Position;
            this.Faces = new List<ObjectFace>();
        }


        public override void Update(World world)
        {
            base.Update(world);

            // Spawn Particle
            if (Game1.random.Next(0, ParticleSpawnChanceDivisor) == 0)
            {
                // Position
                Vector3 ParticlePos = new Vector3(
                    this.Position.X + (float)Game1.random.Next(0,10) / 10,
                    this.Position.Y + (float)Game1.random.Next(0, 10) / 10,
                    this.Position.Z + (float)Game1.random.Next(0, 10) / 10
                    );

                // Color
                Color? ParticleColor = Color.Gold;

                // Size
                float ParticleSize = (float)Game1.random.Next(15, 50) / 100f;

                // Lifespan
                int ParticleFrameLifespan = 120;

                // Velocity
                Vector3 ParticleVelocity = new Vector3(
                    Game1.random.Next(-MaxSingleDirVelocity, MaxSingleDirVelocity) / 100f,
                    Game1.random.Next(-MaxSingleDirVelocity, MaxSingleDirVelocity) / 100f,
                    Game1.random.Next(-MaxSingleDirVelocity, MaxSingleDirVelocity) / 100f
                    );

                Object Particle = new Particle(ParticlePos, ParticleColor, ParticleSize, ParticleFrameLifespan, ParticleVelocity);
                world.Atmosphere.AddParticle( Particle );
                world.objectsNew.Add( Particle );
            }
        }
    }
}
