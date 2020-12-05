using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Iterator
{
    public interface IIterator
    {
        public bool HasNext();
        public Object Next();

        public int Index();
    }
}
