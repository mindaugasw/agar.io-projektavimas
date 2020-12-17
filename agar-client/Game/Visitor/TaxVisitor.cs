using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Visitor
{
    class TaxVisitor : IVisitor
    {

        public TaxVisitor()
        {

        }

        public string Visit(Skin skinItem)
        {
            double value = Math.Round(skinItem.GetPrice() * 0.18 + skinItem.GetPrice(), 2);
            string log = "Skin item: price with tax: " + value.ToString();
            //string log = "Skin item: price with tax: ";
            //Logger.Log(log);
            return log;
        }

        public string Visit(XPBoost xpBoostItem)
        {
            double value = Math.Round(xpBoostItem.GetPrice() * 0.10 + xpBoostItem.GetPrice(), 2);
            string log = "XPBoost item: price with tax: " + value.ToString();
            //string log = "XPBoost item: price with tax: ";
            //Logger.Log(log);
            return log;
        }

        public string Visit(UltimateAcc ultimateAccItem)
        {
            double value = Math.Round(ultimateAccItem.GetPrice() * 0 + ultimateAccItem.GetPrice(), 2);
            string log = "UltimateAcc item: price with tax: " + value.ToString();
            //string log = "UltimateAcc item: price with tax: ";
            //Logger.Log(log);
            return log;
        }
    }
}
