using Autofac;

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

			builder.RegisterType<EquipmentRepository>()
				.As<IEquipmentRepository>()
				.InstancePerLifetimeScope();
		}
	}
}
