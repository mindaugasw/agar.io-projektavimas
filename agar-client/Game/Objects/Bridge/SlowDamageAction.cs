using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Bridge
{
    class SlowDamageAction : Damage
    {
        public SlowDamageAction(Virus newVirus) : base(newVirus)
        {
        }

        override public void InflictDamage()
        {

        }
    }
}
