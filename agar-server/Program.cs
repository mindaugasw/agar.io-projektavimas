using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using agar_server.Game;

namespace agar_server
{
	public class Program
	{
		public static void Main(string[] args)
		{
			CreateHostBuilder(args).Build().Run();
		}

		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();

					bool useCustomUrl = ConfigManager.Get<bool>("useCustomUrl");
					Debug.WriteLine("Use custom url? : " + useCustomUrl.ToString());
					if (useCustomUrl)
					{
						string url = ConfigManager.Get<string>("customUrl");
						Debug.WriteLine("Url : " + useCustomUrl.ToString());
						webBuilder.UseUrls(url);
					}
				});
	}
}
