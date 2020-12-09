using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace agar_client.Game.Objects.Iterator
{
    class DictionaryIterator : IIterator
    {
        private int index = 0;
        private List<MapObject> mapObj;

        public DictionaryIterator(Dictionary<int, MapObject> obj)
        {
            mapObj = obj.Values.ToList();
        }

        public bool HasNext()
        {
            if (index < mapObj.Count)
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
                return mapObj.ElementAt(index++);
            }
            return null;
        }
    }
}
