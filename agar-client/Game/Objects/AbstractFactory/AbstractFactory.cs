using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;

namespace agar_client.Game.Objects
{
    public abstract class AbstractFactory
    {
        public MapObject objects;

        public void TemplateMethod(Dictionary<string, int> objNames) 
        {
            Message1();
            createMapObjects(objNames);
            Message2();
            Message3();
        }

        public virtual void Message1()
        {
            Logger.Log("Message from AbstractFactory");
        }

        public abstract void Message2();

        public abstract void Message3();

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
