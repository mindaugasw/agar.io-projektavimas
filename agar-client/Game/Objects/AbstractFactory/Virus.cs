﻿using System;
using System.Collections.Generic;
using System.Text;
using static agar_client.Game.Utils;
namespace agar_client.Game.Objects
{
    public class Virus : MapObject
    {
        protected int size;
        protected System.Windows.Media.Color color;

        public Virus() : base()
        {
        }

        public Virus(string id, Point position) : base(id, position)
        {
        }

        public override void CreateMapObject(Point? position)
        {
        }

        public int getSize() {
            return size;
        }

        public System.Windows.Media.Color getColor()
        {
            return color;
        }
    }
}
