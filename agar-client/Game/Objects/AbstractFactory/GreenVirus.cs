using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects
{
    public class GreenVirus : Virus
    {
        public GreenVirus() : base()
        {
        }

        public GreenVirus(string id, string name, Point position) : base(id, position)
        {
        }

        public override void CreateMapObject(Point? position)
        {
            size = 100;
            color = System.Windows.Media.Color.FromRgb(0, 255, 0);
            Name = "GreenVirus";

            var r = GameManager.Random;
            if (!position.HasValue)
                position = new System.Windows.Point(r.Next(0, 700), r.Next(0, 500));
            Position = position.Value;
            Shape = GraphicsDrawer.Instance.CreateNewVirus(size, color, Position);
        }
    }
}
