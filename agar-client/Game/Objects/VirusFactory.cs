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
            for (int i = 0; i < 3; i++)
            {
                var newFood = new GreenVirus();
                viruses.Add(newFood);
            }
        }
    }
}
