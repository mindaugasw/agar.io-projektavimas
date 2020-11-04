using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Bridge
{
    class QuickDamageAction : Damage
    {

        public QuickDamageAction(Virus newVirus) : base(newVirus)
        {
        }

        override public void InflictDamage()
        {
            Logger.Log("Damage appear instantly");
        }
    }
}
