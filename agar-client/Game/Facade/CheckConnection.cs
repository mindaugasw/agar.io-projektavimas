using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;

namespace agar_client.Game.Objects
{
	class CheckConnection
	{
		public CheckConnection() 
		{
		}

        public bool IsConnected(HubConnection connection) {
            return connection.State == HubConnectionState.Connected;
        }
	}
}