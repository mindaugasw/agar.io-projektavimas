using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    public abstract class AbstractFactory
    {
        public abstract void createMapObjects(Dictionary<string, int> objNames);
    }
}
