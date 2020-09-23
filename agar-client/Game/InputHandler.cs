using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using agar_client.Game.Objects;
using static agar_client.Game.Utils;

namespace agar_client
{
	class InputHandler
	{
		// Input handling:
		// https://stackoverflow.com/questions/20794918/wpf-how-to-use-command-input-bindings

		public static InputHandler Instance;

		readonly Point MovementBounds = new Point(700, 500); // TODO: move out of InputHandler; make not hardcoded (get from canvas size?)


		public InputHandler()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			MainWindow.Instance.ArrowKeysInput += Player_move;
		}

		public void Player_move(string direction)
		{
			if (LocalPlayer.Instance != null)
			{
				var lp = LocalPlayer.Instance;
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

				translation = translation * LocalPlayer.PLAYER_MOVE_SPEED;
				lp.Position += translation;
				//GraphicsDrawer.TranslateShape(LocalPlayer.Instance.Shape, translation); // Translation not working
				GraphicsDrawer.MoveShape(lp.Shape, lp.Position);
				CommunicationManager.Instance.MoveObject(lp.Id, lp.Position);
				//CommunicationManager.Instance.sendMessage($"Player move: {direction}");
			}
		}

	}
}
