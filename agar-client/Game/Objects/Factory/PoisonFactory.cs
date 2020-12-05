using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects.Factory
{
    public class PoisonFactory
    {
        public static PoisonFactory Instance;
        public List<Poison> poison = new List<Poison>();
        public MapObject poison2;

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
                Poison p = new BluePoison();
                poison.Add(p);
                Add(p);
                p = new CyanPoison();
                poison.Add(p);
                Add(p);
                p = new DarkBluePoison();
                poison.Add(p);
                Add(p);
            }
            else
            {
                if (objNames.ContainsKey("BluePoison"))
                    for (int i = 0; i < objNames["BluePoison"]; i++)
                    {
                        Poison p = new BluePoison();
                        poison.Add(p);
                        Add(p);
                    }
                if (objNames.ContainsKey("CyanPoison"))
                    for (int i = 0; i < objNames["CyanPoison"]; i++)
                    {
                        Poison p = new CyanPoison();
                        poison.Add(p);
                        Add(p);
                    }
                if (objNames.ContainsKey("DarkBluePoison"))
                    for (int i = 0; i < objNames["DarkBluePoison"]; i++)
                    {
                        Poison p = new DarkBluePoison();
                        poison.Add(p);
                        Add(p);
                    }
            }
        }

        public void Add(MapObject p)
        {
            if (poison2 == null)
                poison2 = p;
            else
                poison2.Add(p);
        }
    }
}
