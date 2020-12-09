using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Iterator
{
    class ArrayIterator : IIterator
    {
        private int index = 0;
        private MapObject[] mapObj;

        public ArrayIterator(MapObject[] obj)
        {
            mapObj = obj;
        }

        public bool HasNext()
        {
            if (index < mapObj.Length)
            {
                return true;
            }
            return false;
        }

        public int Index()
        {
            return index;
        }

        public object Next()
        {
            if (this.HasNext())
            {
                return mapObj[index++];
            }
            return null;
        }
    }
}
