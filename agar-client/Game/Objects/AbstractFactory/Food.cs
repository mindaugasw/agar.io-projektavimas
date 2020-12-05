using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects
{
    public abstract class Food : MapObject
    {

        public int size;
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

        public Food Clone()
        {
            var copy = (Food) this.MemberwiseClone();
            copy.Shape = GraphicsDrawer.CreateNewEllipse(copy.size, copy.color, copy.Position);
            return (Food) copy;
        }

        public abstract void FoodLogMessage();

    }
}
