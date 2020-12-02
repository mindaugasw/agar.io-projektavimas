using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    public class PoisonedStrategy : PlayerStrategy
    {
        public override int playerSpeed()
        {
            return 15;
        }
    }
}
