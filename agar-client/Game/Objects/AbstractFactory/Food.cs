using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects
{
    abstract class Food : MapObject
    {

        protected int size;
        protected System.Windows.Media.Color color;

        public Food() : base()
        {
        }

        public Food(string id, Point position) : base(id, position)
        {
        }

        public override void CreateMapObject(Point? position)
        {
        }
    }
}
