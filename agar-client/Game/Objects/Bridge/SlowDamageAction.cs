using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Bridge
{
    class SlowDamageAction : Damage
    {
        private Random rand = new Random();
        public SlowDamageAction(Virus newVirus) : base(newVirus)
        {
        }

        override public void InflictDamage()
        {
            Logger.Log("Damage appear after " + rand.Next(11) + " seconds");
        }
    }
}
