using agar_client.Game.Objects.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Adapter
{
    class PoisonAdapter : Food
    {
        protected Poison thePoison;
        public PoisonAdapter(Poison newPoison)
        {
            thePoison = newPoison;
        }

    }
}
