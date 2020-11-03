using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects
{
    class GreenFoodDecorator : Food
    {
        public GreenFoodDecorator()
        {
            this.setColor();
        }

        public GreenFoodDecorator(string id, string name, Point position) : base(id, position)
        {
            this.setColor();
            Name = name;
        }

        public void setColor() {
            this.color = System.Windows.Media.Color.FromRgb(0, 255, 0);
            this.Shape.Fill = new SolidColorBrush(color);

            this.Name = "GreenFood";
        }

        public override void CreateMapObject(Point? position)
        {
            var r = GameManager.Random;
            if (!position.HasValue)
                position = new System.Windows.Point(r.Next(0, 700), r.Next(0, 500));
            Position = position.Value;
            Shape = GraphicsDrawer.CreateNewEllipse(size, color, Position);
        }
    }
}
