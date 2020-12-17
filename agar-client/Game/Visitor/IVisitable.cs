using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Visitor
{
    interface IVisitable
    {
        public string Accept(IVisitor visitor);
    }
}
