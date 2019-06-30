using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure
{
	using Domain.AggregatesModel.EquipmentAggregate;
	using EntityConfigurations;
	using SharedKernel;

	public class EquipmentContext : DbContext, IUnitOfWork
	{
		public const string DEFAULT_SCHEMA = "equipment";
		public DbSet<Equipment> Equipments { get; set; }
		public DbSet<ActionTaskType> ActionTaskTypes { get; set; }
		public DbSet<TaskType> TaskTypes { get; set; }
		public DbSet<TaskFrequency> TaskFrequencies { get; set; }
		public DbSet<Book> Books { get; set; }

		private readonly IMediator _mediator;

		public EquipmentContext(DbContextOptions<EquipmentContext> options, IMediator mediator) : base(options)
		{
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfigurationsFromAssembly(
				typeof(EquipmentEntityTypeConfiguration).GetTypeInfo().Assembly);
		}

		public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			await _mediator.DispatchDomainEventsAsync(this);

			await base.SaveChangesAsync(cancellationToken);

			return true;
		}
	}

	public class EquipmentContextDesignFactory : IDesignTimeDbContextFactory<EquipmentContext>
	{
		public EquipmentContext CreateDbContext(string[] args)
		{
			var optionsBuilder = new DbContextOptionsBuilder<EquipmentContext>()
				.UseSqlServer("Server=.; Database=Boruc.LabEquip.Equipment; Integrated Security=True;")
				.EnableSensitiveDataLogging();

			return new EquipmentContext(optionsBuilder.Options, new NoMediator());
		}
	}

	internal class NoMediator : IMediator
	{
		public Task<TResponse> Send<TResponse>(IRequest<TResponse> request, CancellationToken cancellationToken = new CancellationToken())
		{
			throw new NotImplementedException();
		}

		public Task Publish(object notification, CancellationToken cancellationToken = new CancellationToken())
		{
			throw new NotImplementedException();
		}

		public Task Publish<TNotification>(TNotification notification, CancellationToken cancellationToken = new CancellationToken()) where TNotification : INotification
		{
			throw new NotImplementedException();
		}
	}
}
