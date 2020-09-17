using System;
using System.Collections.Generic;
using System.Diagnostics;
//using System.Drawing;
using System.Windows;
using System.Text;

namespace agar_client
{
	class InputHandler
	{
		// Input handling:
		// https://stackoverflow.com/questions/20794918/wpf-how-to-use-command-input-bindings

		public static InputHandler Instance;

		const int PlayerMoveSpeed = 35;

		public InputHandler()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();
		}

		public void Player_move(string direction)
		{
			Point translation;

			switch (direction)
			{
				case "up":
					translation = new Point(0, -1);
					break;
				case "down":
					translation = new Point(0, 1);
					break;
				case "right":
					translation = new Point(1, 0);
					break;
				case "left":
					translation = new Point(-1, 0);
					break;
				default:
					throw new Exception();
			}

			translation = translation.Multiply(PlayerMoveSpeed);
			CommunicationManager.Instance.sendMessage($"Player move: {direction}");
			GraphicsDrawer.Instance.PlayerTranslate(translation);
		}

	}
}
