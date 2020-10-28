using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Bridge
{
    abstract class Damage
    {
        private Virus theVirus;
        public Damage(Virus newVirus)
        {
            theVirus = newVirus;
        }

        public abstract void InflictDamage();
        
        
    }
}
