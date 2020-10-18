using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects
{
    class RedVirus : Virus
    {
        public RedVirus() : base()
        {
        }

        public RedVirus(string id, string name, Point position) : base(id, position)
        {
        }

        public override void CreateMapObject(Point? position)
        {
            size = 80;
            color = System.Windows.Media.Color.FromRgb(255, 0, 0);
            Name = "RedVirus";

            var r = GameManager.Random;
            if (!position.HasValue)
                position = new System.Windows.Point(r.Next(0, 700), r.Next(0, 500));
            Position = position.Value;
            Shape = GraphicsDrawer.CreateNewVirus(size, color, Position);
        }
    }
}
