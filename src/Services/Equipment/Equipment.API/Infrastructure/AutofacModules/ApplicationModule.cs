#pragma warning disable CS1591

using Autofac;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES;

namespace Boruc.LabEquip.Services.Equipment.API.Infrastructure.AutofacModules
{
	using Application.Queries;
	using Domain.AggregatesModel.EquipmentAggregate;
	using Equipment.Infrastructure.Repositories;

	public class ApplicationModule : Module
	{
		public string ConnectionString { get; }

		public ApplicationModule(string connectionString)
		{
			ConnectionString = connectionString;
		}

		protected override void Load(ContainerBuilder builder)
		{
			builder.Register(context => new EquipmentQueries(ConnectionString))
				.As<IEquipmentQueries>()
				.InstancePerLifetimeScope();
			
			builder.RegisterType<EquipmentESQueries>()
				.As<IEquipmentQueries>()
				.InstancePerLifetimeScope();

			builder.RegisterType<EquipmentRepository>()
				.As<IEquipmentRepository>()
				.InstancePerLifetimeScope();

			builder.RegisterType<Services.Equipment.Infrastructure.EventStore.Repositories.EquipmentRepository>()
				.As<IEquipmentRepositoryES>()
				.InstancePerLifetimeScope();
		}
	}
}
