using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Visitor
{
    interface IVisitor
    {
        public string Visit(Skin skinItem);
        public string Visit(XPBoost xpBoostItem);
        public string Visit(UltimateAcc ultimateAccItem);

    }
}
