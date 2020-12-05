using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    public abstract class AbstractFactory
    {
        public MapObject objects;
        public abstract void createMapObjects(Dictionary<string, int> objNames);

        public void Add(MapObject a)
        {
            if (objects == null)
                objects = a;
            else
                objects.Add(a);
        }

    }
}
