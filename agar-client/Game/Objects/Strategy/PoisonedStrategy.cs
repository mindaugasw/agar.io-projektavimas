using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    class PoisonedStrategy : PlayerStrategy
    {
        public override int playerSpeed()
        {
            return 15;
        }
    }
}
