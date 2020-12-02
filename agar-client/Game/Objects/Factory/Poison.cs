using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects.Factory
{
    public abstract class Poison : MapObject
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

        public abstract void PoisonLogMessage();

        public int getSize()
        {
            return size;
        }

        public System.Windows.Media.Color getColor()
        {
            return color;
        }
    }
}
