using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO.Pipelines;
using System.Linq;
using System.Threading.Tasks;
using agar_server.Game;
using agar_server.Game.Objects;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using static agar_server.Game.Utils;


namespace agar_server.Hubs
{
	public class GameHub : Hub
	{
        //Dictionary<string, Point> players = new Dictionary<string, Point>();


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

            var newPlayer = new Player() { Id = id, Position = position };
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

            if (context.Food.Count() > 1)
            {
                Debug.WriteLine("Sending map objects to other clients.");
                //List<Food> mapObjects = context.Food.ToList();

                //Debug.WriteLine($"{context.Players.Count()} {context.Food.Count()}");
                MapObject[] food = context.Food.ToArray();
                MapObject[] viruses = context.Viruses.ToArray();
                List<MapObject> mapObjects = food.Concat(viruses).ToList();
                ids = mapObjects.Select(x => x.Id).ToArray();
                var names = mapObjects.Select(x => x.Name).ToArray();
                positions = mapObjects.Select(x => x.Position).ToArray();

                Clients.Caller.SendAsync("ReceiveMapObjects", ids, names, positions);
            }


            context.SaveChanges();
        }


        public async Task CreateMapObjects(string[] ids, string[] mapObjectNames, Point[] positions) 
        {
            for (int i = 0; i < ids.Length; i++)
            {
                Debug.WriteLine($"Created map object. ID: {ids[i]}, Name: {mapObjectNames[i]}, X: {positions[i].X}, Y: {positions[i].Y}");
                switch (mapObjectNames[i])
                {
                    case "GreenFood":
                        var newFood = new Food() { Id = ids[i], Position = positions[i], Name = mapObjectNames[i] };
                        context.Food.Add(newFood);
                        break;
                    case "GreenVirus":
                        var newVirus = new Virus() { Id = ids[i], Position = positions[i], Name = mapObjectNames[i] };
                        context.Viruses.Add(newVirus);
                        break;
                }
            }
            context.SaveChanges();
        }

        public async Task MoveObject(string id, Point position)
        {
            Debug.WriteLine($"Move. ID: {id}, X: {position.X}, Y: {position.Y}");
            Clients.Others.SendAsync("MoveObject", id, position);

            context.Players.Where(plr => plr.Id == id).First().Position = position;
            context.SaveChanges();
        }
    }
}
