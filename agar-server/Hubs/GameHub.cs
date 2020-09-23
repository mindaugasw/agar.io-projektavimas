using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using agar_server.Game;
using agar_server.Game.Objects;
using Microsoft.AspNetCore.SignalR;

namespace agar_server.Hubs
{
	public class GameHub : Hub
	{
        Dictionary<string, Point> players = new Dictionary<string, Point>();

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

        public async Task AnnounceNewPlayer(string id, Point position)
		{
            Debug.WriteLine($"New player. ID: {id}, X: {position.X}, Y: {position.Y}");
            Clients.Others.SendAsync("AnnounceNewPlayer", id, position);
            players.Add(id, position);

            
        }

        public async Task GetGameState(string id)
		{
            var x = new int [1, 2, 3];
            Clients.Caller.SendAsync("GetGameState", x as object);
		}

        public async Task MoveObject(string id, Point position)
        {
            Debug.WriteLine($"Move. ID: {id}, X: {position.X}, Y: {position.Y}");
            Clients.Others.SendAsync("MoveObject", id, position);
        }
        
        /*public async Task AnnounceNewPlayer(MapObject obj)
		{
            Debug.WriteLine($"New player. ID: {obj.Id}, X: {obj.Position.X}, Y: {obj.Position.Y}");
            Clients.Others.SendAsync("AnnounceNewPlayer", obj);
        }

        public async Task MoveObject(MapObject obj)
        {
            Debug.WriteLine($"Move. ID: {obj.Id}, X: {obj.Position.X}, Y: {obj.Position.Y}");
            Clients.Others.SendAsync("MoveObject", obj);
        }*/
    }
}
