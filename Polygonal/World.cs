using Polygonal.Objects;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal
{
    public class World
    {
        public List<Object> objects;
        public List<Object> objectsNew;
        public List<Object> objectsForDelete;

        public Atmosphere Atmosphere;
        public EntityHandler EntityHandler;



        public World(Settings settings)
        {
            GenWorld(settings);
        }

        private void GenWorld(Settings settings)
        {
            objects = new List<Object>();
            if (settings.objectsRandomPopulation)
                objects = Object.getRandom(settings.objectsRandomCount, settings.objectSpawnRange);
            objectsNew = new List<Object>();
            objectsForDelete = new List<Object>();

            EntityHandler = new EntityHandler();
            Atmosphere = new Atmosphere();
            objects.Add(new WorldFloor(new Vector3(50, 50, 20), this));


            genSikeFloor();
            genEntities();
        }



        private void genSikeFloor()
        {
            Point SpikeGridDimentions = new Point(20, 20);

            for (int x = 0; x < SpikeGridDimentions.X; x++)
            {
                for (int y = 0; y < SpikeGridDimentions.Y; y++)
                {
                    Object Obj = new TriangleBasedPrism(new Vector3(x, y, 0), null, false, 1);

                    objects.Add(Obj);
                }
            }
        }
        private void genEntities()
        {
            // Morphing Cube
            Vector3 CubePos = new Vector3(10, 10, -5);
            Object MCube = new MorphingCube(CubePos);
            objects.Add(MCube);
            EntityHandler.AddEntity(MCube);

            // Particle Spawner
            Vector3 SpawnerPos = new Vector3(15, 15, -5);
            Object PSpawner = new ParticleSpawner(SpawnerPos);
            objects.Add(PSpawner);
            EntityHandler.AddEntity(PSpawner);

            // Static Rain spawner
            Vector3 RSpawnerPos = new Vector3(35, 15, -15);
            Object RSpawner = new RainSpawner(RSpawnerPos)
            {
                SpawnDistanceRange = new Vector2(-10, 10)
            };
            objects.Add(RSpawner);
            EntityHandler.AddEntity(RSpawner);
            
        }



        public void Update()
        {
            EntityHandler.UpdateObjects(this);
            Atmosphere.Update(this);


            // Create New Objects
            List<Object> ObjsTransfered = new List<Object>();
            foreach (Object Obj in objectsNew)
            {
                objects.Add(Obj);
                ObjsTransfered.Add(Obj);
            }
            foreach (Object Obj in ObjsTransfered)
                objectsNew.Remove(Obj);

            // Delete Objects
            foreach (Object Obj in objectsForDelete)
                objects.Remove(Obj);
            objectsForDelete.Clear();
        }
    }
}
