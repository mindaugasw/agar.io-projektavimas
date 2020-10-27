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

		public DbSet<Player> Players { get; set; }
		public DbSet<Food> Food { get; set; }
		public DbSet<Virus> Viruses { get; set; }
		public DbSet<Poison> Poison { get; set; }
	}
}
