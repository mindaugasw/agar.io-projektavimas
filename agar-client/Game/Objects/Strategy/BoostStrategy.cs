using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    class BoostStrategy : PlayerStrategy
    {
        public override int playerSpeed()
        {
            return 55;
        }
    }
}
