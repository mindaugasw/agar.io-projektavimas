using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
    class VirusFactory : AbstractFactory
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
        public override void createMapObjects()
        {
            var r = GameManager.Random;
            var gCount = r.Next(0, 5);
            var rCount = 4 - gCount;

            for (int i = 0; i < gCount; i++)
            {
                viruses.Add(new GreenVirus());
            }
            for (int i = 0; i < rCount; i++)
            {
                viruses.Add(new RedVirus());
            }
        }
    }
}
