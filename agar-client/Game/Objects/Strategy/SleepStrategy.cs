using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    public class SleepStrategy : PlayerStrategy
    {
        public override int playerSpeed()
        {
            return 0;
        }
    }
}
