using agar_client.Game.Objects.Factory;
using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Adapter
{
    class BluePoisonAdapter : Food
    {
        protected BluePoison theBluePoison;
        public BluePoisonAdapter(BluePoison newBluePoison)
        {
            theBluePoison = newBluePoison;
        }

        public override void FoodLogMessage()
        {
            theBluePoison.PoisonLogMessage();
        }
    }
}
