using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects
{
    class GreenFood : Food
    {
        public GreenFood() : base()
        {
        }

        public GreenFood(string id, string name, Point position) : base(id, position)
        {
            Name = name;
        }

        public override void CreateMapObject(Point? position)
        {
            size = 10;
            color = System.Windows.Media.Color.FromRgb(0, 255, 0);
            Name = "GreenFood";

            var r = GameManager.Random;
            if (!position.HasValue)
                position = new System.Windows.Point(r.Next(0, 700), r.Next(0, 500));
            Position = position.Value;
            Shape = GraphicsDrawer.CreateNewEllipse(size, color, Position);
        }
    }
}
