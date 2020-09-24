using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using agar_server.Game;
using agar_server.Game.Objects;
using Microsoft.AspNetCore.SignalR;
using static agar_server.Game.Utils;

namespace agar_server.Hubs
{
	public class GameHub : Hub
	{
        Dictionary<string, Point> players = new Dictionary<string, Point>();

        AgarDbContext context;

        public GameHub(AgarDbContext context)
        {
            this.context = context;
        }

        public async Task SendMessage(string message)
        {
            //await Clients.All.SendAsync("ReceiveMessage", user, message);
            Debug.WriteLine($"Received: {message}");
            await Clients.Caller.SendAsync("ReceiveMessage", $"Server received message: {message}");
            //await Clients.Others.SendAsync("ReceiveMessage", user, message);
            //await Clients.Caller.SendAsync("ReceiveMessage", user, "delivered: " + message);
        }

        public async Task AnnounceNewPlayer(string id, Point position)
		{
            Debug.WriteLine($"New player. ID: {id}, X: {position.X}, Y: {position.Y}");

            var newPlayer = new MapObject() { Id = id, Position = position };
            context.Players.Add(newPlayer);
            //context.SaveChanges();

            Clients.Others.SendAsync("AnnounceNewPlayer", id, position);

			//var playersList = context.Players.Where(plr => plr.Id != id).ToArray();
			var playersList = context.Players; // Filtering not needed, as current player is not yet saved to DB

            // Sending whole MapObject does not work, so sending ids and positions separately
            // Sending arrays (rather than lists) works more reliably

            var ids = context.Players.Select(plr => plr.Id).ToArray();
            var positions = context.Players.Select(plr => plr.Position).ToArray();

            Clients.Caller.SendAsync("GetGameState", ids, positions); 

            context.SaveChanges();
        }

        public async Task MoveObject(string id, Point position)
        {
            Debug.WriteLine($"Move. ID: {id}, X: {position.X}, Y: {position.Y}");
            Clients.Others.SendAsync("MoveObject", id, position);
        }
    }
}
