using System;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace Boruc.LabEquip.Services.Equipment.API
{
	public class Program
	{
		public static readonly string Namespace = typeof(Program).Namespace;
		public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);

		public static int Main(string[] args)
		{
			var configuration = GetConfiguration();

			Log.Logger = CreateSerilogLogger(configuration);

			try
			{
				Log.Information("Configuring web host ({ApplicationContext})...", AppName);
				var host = BuildWebHost(configuration, args);

				Log.Information("Applying migrations ({ApplicationContext})...", AppName);
				//TODO check if needed migrateDbContext

				Log.Information("Starting web host ({ApplicationContext})...", AppName);
				host.Run();

				return 0;
			}
			catch (Exception exception)
			{
				Log.Fatal(exception, "Program terminated unexpectedly ({ApplicationContext})!", AppName);
				return 1;
			}
			finally
			{
				Log.CloseAndFlush();
			}
		}

		private static IConfiguration GetConfiguration()
		{
			throw new System.NotImplementedException();
		}

		private static ILogger CreateSerilogLogger(IConfiguration configuration)
		{
			throw new System.NotImplementedException();
		}

		private static IWebHost BuildWebHost(IConfiguration configuration, string[] args)
		{
			throw new NotImplementedException();
		}
	}
}
