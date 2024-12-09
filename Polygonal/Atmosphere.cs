using Microsoft.Xna.Framework;
using Polygonal.Objects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Polygonal
{
    public class Atmosphere
    {
        public bool isRaining { get; set; }
        private int RainIntensity { get; set; }
        public RainSpawner RainSpawner { get; set; }

        private List<Object> StaticParticleSpawners { get; set; }
        private List<Object> Particles { get; set; }


        public Atmosphere()
        {
            StaticParticleSpawners = new List<Object>();
            Particles = new List<Object>();

            Vector3 SpawnerPos = new Vector3(40, 20, -15);
            RainSpawner RainSpawnerObj = new RainSpawner(SpawnerPos);
            RainSpawner = RainSpawnerObj;
            isRaining = true;
        }


        public void Update(World world)
        {
            if (isRaining)
            {
                RainSpawner.Update(world);
                RainSpawner.Position = Game1.Camera.WorldPosition + RainSpawner.CameraFollowDistance;
            }
            


            foreach (Object obj in Particles)
            {
                obj.Update(world);
            }

            // Handle Particle deletions
            List<Object> ParticlesDeleted = new List<Object>();
            foreach (Object Obj in Particles)
            {
                if (Obj.forDelete)
                {
                    world.objectsForDelete.Add(Obj);
                    ParticlesDeleted.Add(Obj);
                } 
            }
            foreach (Object Obj in ParticlesDeleted)
                RemoveParticle(Obj);
        }



        public void AddParticle(Object Particle)
        {
            if (!Particles.Contains(Particle))
                Particles.Add(Particle);
        }
        public void RemoveParticle(Object Particle)
        {
            Particles.Remove(Particle);
        }
    }
}
