using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Chain
{
    interface IChain
    {
        public void SetNextChain(IChain nextChain);

        public void CheckBadWord(Words request);

    }
}
