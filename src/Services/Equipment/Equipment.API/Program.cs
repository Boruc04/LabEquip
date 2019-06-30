#pragma warning disable CS1591

using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;
using System;
using System.IO;

namespace Boruc.LabEquip.Services.Equipment.API
{
	using Microsoft.ApplicationInsights.Extensibility;
	using Serilog.Events;

	public class Program
	{
		public static readonly string Namespace = typeof(Program).Namespace;
		public static readonly string AppName = Namespace.Substring(Namespace.LastIndexOf('.', Namespace.LastIndexOf('.') - 1) + 1);

		public static int Main(string[] args)
		{
			// Hack for .net core 2.2 issue related with - https://github.com/aspnet/AspNetCore/issues/4206
			CurrentDirectoryHelpers.SetCurrentDirectory();

			var configuration = GetConfiguration();

			Log.Logger = CreateSerilogLogger();

			try
			{
				Log.Information("Configuring web host ({ApplicationContext})...", AppName);
				var host = BuildWebHost(configuration, args);

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
			var configurationBuilder = new ConfigurationBuilder()
				.SetBasePath(Directory.GetCurrentDirectory())
				.AddJsonFile("appsettings.json", false, true)
				.AddEnvironmentVariables();

			return configurationBuilder.Build();
		}

		private static ILogger CreateSerilogLogger()
		{
			//TODO check this - var logsFilePath = string.Concat(Directory.GetCurrentDirectory(), @"\logs\api\logs.txt");

			var loggerConfiguration = new LoggerConfiguration()
				.MinimumLevel.Verbose()
				.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
				.Enrich.WithProperty("ApplicationContext", AppName)
				.Enrich.FromLogContext()
				.WriteTo.Console()
				//.WriteTo.File(logsFilePath)
				.WriteTo.ApplicationInsights(TelemetryConfiguration.Active, TelemetryConverter.Traces)
				.CreateLogger();

			return loggerConfiguration;
		}

		private static IWebHost BuildWebHost(IConfiguration configuration, string[] args)
		{
			return WebHost.CreateDefaultBuilder(args)
				.CaptureStartupErrors(false)
				.UseStartup<Startup>()
				.UseConfiguration(configuration)
				.UseSerilog()
				.Build();
		}
	}
}
