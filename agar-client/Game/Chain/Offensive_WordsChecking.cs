using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Chain
{
    class Offensive_WordsChecking : IChain
    {
        private IChain nextInChain;
        public void CheckBadWord(Words request)
        {
            if (request.GetWord() == "idiot")
            {
                Logger.Log("Offensive word. Your language contains bad language aesthetic.");
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
