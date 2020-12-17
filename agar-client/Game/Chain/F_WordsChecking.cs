using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Chain
{
    class F_WordsChecking : IChain
    {
        private IChain nextInChain;
        public void CheckBadWord(Words request)
        {
            if (request.GetWord() == "fuk")
            {
                Logger.Log("F-word. Your language contains bad language aesthetic.");
            }
            else
            {
                nextInChain.CheckBadWord(request);
            }
        }

        public void SetNextChain(IChain nextChain)
        {
            nextInChain = nextChain;
        }
    }
}
