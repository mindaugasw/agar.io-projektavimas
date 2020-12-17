using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Visitor
{
    class HolidayVisitor : IVisitor
    {
        public HolidayVisitor()
        {

        }

        public string Visit(Skin skinItem)
        {
            double value = Math.Round(skinItem.GetPrice() * 0.18 + skinItem.GetPrice() - skinItem.GetPrice() * 0.25, 2);
            string log = "Skin item: price with tax: " + value.ToString();

            return log;
        }

        public string Visit(XPBoost xpBoostItem)
        {
            double value = Math.Round(xpBoostItem.GetPrice() * 0.10 + xpBoostItem.GetPrice() - xpBoostItem.GetPrice() * 0.75, 2);
            string log = "XPBoost item: price with tax: " + value.ToString();

            return log;
        }

        public string Visit(UltimateAcc ultimateAccItem)
        {
            double value = Math.Round(ultimateAccItem.GetPrice() * 0 + ultimateAccItem.GetPrice() - ultimateAccItem.GetPrice() * 0.50, 2);
            string log = "UltimateAcc item: price with tax: " + value.ToString();

            return log;
        }
    }
}
