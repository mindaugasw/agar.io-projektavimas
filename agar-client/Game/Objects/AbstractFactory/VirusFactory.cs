using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    public class VirusFactory : AbstractFactory
    {
        public static VirusFactory Instance;
        public List<Virus> viruses = new List<Virus>();

        public VirusFactory()
        {
            if (Instance == null)
                Instance = this;
            else
                throw new Exception();
        }
        public override void createMapObjects(Dictionary<string, int> objNames)
        {
            if (objNames == null)
            {
                var r = GameManager.Random;
                var gCount = r.Next(0, 5);
                var rCount = 4 - gCount;

                for (int i = 0; i < gCount; i++)
                {
                    var v = new GreenVirus();
                    viruses.Add(v);
                    Add(v);
                }
                for (int i = 0; i < rCount; i++)
                {
                    var v = new RedVirus();
                    viruses.Add(v);
                    Add(v);
                }
            }
            else
            {
                if (objNames.ContainsKey("GreenVirus"))
                    for (int i = 0; i < objNames["GreenVirus"]; i++)
                    {
                        var v = new GreenVirus();
                        viruses.Add(v);
                        Add(v);
                    }
                if (objNames.ContainsKey("RedVirus"))
                    for (int i = 0; i < objNames["RedVirus"]; i++)
                    {
                        var v = new RedVirus();
                        viruses.Add(v);
                        Add(v);
                    }
            }
        }

        public override void Message2()
        {
            Logger.Log("Message2 from VirusFactory");
        }

        public override void Message3()
        {
            Logger.Log("Message3 from VirusFactory");
        }
    }
}
