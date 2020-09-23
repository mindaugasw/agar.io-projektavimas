using System;
using System.Collections.Generic;
using System.Text;

namespace agar_client.Game.Objects
{
	/// <summary>
	/// Represents player on this machine
	/// </summary>
	class LocalPlayer : Player
	{
		public static LocalPlayer Instance;

		public LocalPlayer() : base()
		{
			if (Instance == null)
				Instance = this;
			else
				throw new Exception();

			CommunicationManager.Instance.AnnounceNewPlayer(Id, Position);
		}
	}
}
