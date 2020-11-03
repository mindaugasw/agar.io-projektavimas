using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.SignalR.Client;

namespace agar_client.Game.Objects
{
	class CheckConnection
	{
		HubConnection connection;
		public CheckConnection(HubConnection connection) 
		{
			this.connection = connection;
		}

        public bool IsConnected() {
            return this.connection.State == HubConnectionState.Connected;
        }
	}
}