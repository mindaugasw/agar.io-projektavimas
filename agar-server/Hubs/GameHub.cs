using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace agar_server.Hubs
{
	public class GameHub : Hub
	{
        public GameHub()
        {
        }

        public async Task SendMessage(string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            Debug.WriteLine($"Received: {message}");
            await Clients.Caller.SendAsync("ReceiveMessage", $"Server received message: {message}");
            //await Clients.Others.SendAsync("ReceiveMessage", user, message);
            //await Clients.Caller.SendAsync("ReceiveMessage", user, "delivered: " + message);
        }
    }
}
