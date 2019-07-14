#pragma warning disable CS1591

using Autofac;
using System;

namespace Boruc.LabEquip.Services.Equipment.API.Infrastructure.AutofacModules
{
	using Equipment.Infrastructure.EventStore;

	public class EventStoreModule : Module
	{
		private readonly string _connectionString;

		public EventStoreModule(string connectionString)
		{
			_connectionString = !string.IsNullOrWhiteSpace(connectionString)
				? connectionString : throw new ArgumentNullException(nameof(connectionString));
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(context => new EventStore())
				.As<IEventStore>().SingleInstance();
		}
	}
}
