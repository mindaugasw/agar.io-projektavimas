using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects.Factory
{
    abstract class Poison : MapObject
    {
        protected int size;
        protected System.Windows.Media.Color color;

        public Poison() : base()
        {
        }

        public Poison(string id, Point position) : base(id, position)
        {
        }

        public override void CreateMapObject(Point? position)
        {
        }
    }
}
