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

        public void createPoisonObjects(Dictionary<string, int> objNames)
        {
            if (objNames == null)
            {
                poison.Add(new BluePoison());
                poison.Add(new CyanPoison());
                poison.Add(new DarkBluePoison());
            }
            else
            {
                if (objNames.ContainsKey("BluePoison"))
                    for (int i = 0; i < objNames["BluePoison"]; i++)
                    {
                        poison.Add(new BluePoison());
                    }
                if (objNames.ContainsKey("CyanPoison"))
                    for (int i = 0; i < objNames["CyanPoison"]; i++)
                    {
                        poison.Add(new CyanPoison());
                    }
                if (objNames.ContainsKey("DarkBluePoison"))
                    for (int i = 0; i < objNames["DarkBluePoison"]; i++)
                    {
                        poison.Add(new DarkBluePoison());
                    }
            }
        }
    }
}
