﻿using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;

namespace agar_client.Game.Objects.Factory
{
    public class CyanPoison : Poison
    {
        public CyanPoison() : base()
        {
        }

        public CyanPoison(string id, string name, Point position) : base(id, position)
        {

        }

        public override void CreateMapObject(Point? position)
        {
            size = 10;
            color = System.Windows.Media.Color.FromRgb(0, 255, 255);
            Name = "CyanPoison";

            var r = GameManager.Random;
            if (!position.HasValue)
                position = new System.Windows.Point(r.Next(0, 700), r.Next(0, 500));
            Position = position.Value;
            Shape = GraphicsDrawer.Instance.CreateNewEllipse(size, color, Position);
        }
        public override void PoisonLogMessage()
        {
            Logger.Log("Cyan Poison");
        }
    }
}
