using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Factory
{
    class PoisonFactory
    {
        public static PoisonFactory Instance;
        public List<Poison> poison = new List<Poison>();

        public PoisonFactory()
        {
            if (Instance == null)
                Instance = this;
            else
                throw new Exception();
        }

        public void createPoisonObjects()
        {
            poison.Add(new BluePoison());
            poison.Add(new CyanPoison());
            poison.Add(new DarkBluePoison());
        }
    }
}
