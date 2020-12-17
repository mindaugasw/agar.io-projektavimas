using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Visitor
{
    class XPBoost : IVisitable
    {
        private double price;

        public XPBoost(double item)
        {
            price = item;
        }

        public double GetPrice()
        {
            return price;
        }

        public string Accept(IVisitor visitor)
        {
            return visitor.Visit(this);
        }
    }
}
