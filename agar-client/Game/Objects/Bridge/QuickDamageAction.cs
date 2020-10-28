using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Bridge
{
    class QuickDamageAction : Damage
    {
        private Virus theVirus;

        public QuickDamageAction(Virus newVirus)
        {
            this.theVirus = newVirus;
            //base.newVirus;
        }

        override public void InflictDamage()
        {

        }
    }
}
