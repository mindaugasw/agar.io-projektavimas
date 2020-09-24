using agar_server.Game.Objects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agar_server
{
	public class AgarDbContext : DbContext
	{

		public AgarDbContext(DbContextOptions<AgarDbContext> options) : base(options)
		{
		}

		public DbSet<MapObject> Players { get; set; }
	}
}
