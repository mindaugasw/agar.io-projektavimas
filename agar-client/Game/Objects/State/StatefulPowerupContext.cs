using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace agar_client.Game.Objects.State
{
	class StatefulPowerupContext : MapObject
	{
		IPowerupState powerupState;
		public TextBlock text;

		public StatefulPowerupContext() : base()
		{
			SetState(new PowerupStateBoost(this));
		}

		public void SetState(IPowerupState newState)
		{
			this.powerupState = newState;
		}

		public override void CreateMapObject(Utils.Point? position)
		{
			var r = GameManager.Random;

			if (!position.HasValue)
				position = new Utils.Point(r.Next(0, 700), r.Next(0, 500)); // TODO remove hardcoded values

			Position = position.Value;
			var color = System.Windows.Media.Color.FromRgb((byte)r.Next(0, 256), (byte)r.Next(0, 256), (byte)r.Next(0, 256));
			Shape = GraphicsDrawer.CreateNewRectangle(250, color, Position);

			text = new TextBlock();
			text.Text = "?";
			GraphicsDrawer.AddControl(text, position.Value + new Utils.Point(5, 1));
		}
	}
}
