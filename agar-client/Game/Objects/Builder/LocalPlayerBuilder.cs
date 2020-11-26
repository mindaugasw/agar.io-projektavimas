using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Media;
using System.Windows.Shapes;

namespace agar_client.Game.Objects.Builder
{
	// Concrete builder #1
	public class LocalPlayerBuilder : IPlayerBuilder
	{
		private LocalPlayer player;

		public void BuildPlayer()
		{
			player = new LocalPlayer();
		}

		public void BuildLocalPlayerIndicator()
		{
			player.Shape.Stroke = new SolidColorBrush(System.Windows.Media.Color.FromRgb(255, 0, 0));
			player.Shape.StrokeThickness = 3;
		}

		public Player GetResult()
		{
			return player;
		}
	}
}
