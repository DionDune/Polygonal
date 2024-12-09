using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Polygonal
{
    public class EntityHandler
    {
        private List<Object> Entities { get; set; }

        public EntityHandler()
        {
            Entities = new List<Object>();
        }

        public void UpdateObjects(World world)
        {
            foreach (Object obj in Entities)
            {
                obj.Update(world);
            }
        }


        public void AddEntity(Object Entity)
        {
            if (!Entities.Contains(Entity))
                Entities.Add(Entity);
        }
        public void RemoveEntity(Object Entity)
        {
            Entities.Remove(Entity);
        }
    }
}
