using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Visitor
{
    class UltimateAcc : IVisitable
    {
        private double price;


        public UltimateAcc(double item)
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
