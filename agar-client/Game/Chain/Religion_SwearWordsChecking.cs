using System;
using System.Collections.Generic;
using System.Text;


namespace agar_client.Game.Chain
{
    class Religion_SwearWordsChecking : IChain
    {
        private IChain nextInChain;
        public void CheckBadWord(Words request)
        {
            if (request.GetWord() == "goddamn")
            {
                Logger.Log("Insulting religion. Your language contains bad language aesthetic.");
            }
            else
            {
                request.isSwear = false;
            }
        }

        public void SetNextChain(IChain nextChain)
        {
            nextInChain = nextChain;
        }
    }
}
