using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Chain
{
    class Words
    {
        private string word;
        public bool isSwear = true;

        public Words(string newWord)
        {
            word = newWord;
        }

        public string GetWord()
        {
            return word;
        }
        public bool GetIsSwear()
        {
            return isSwear;
        }
    }
}
