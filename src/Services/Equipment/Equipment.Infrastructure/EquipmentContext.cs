using Boruc.LabEquip.Services.Equipment.Infrastructure.EntityConfigurations;
using Boruc.LabEquip.Services.SharedKernel;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure
{
	public class EquipmentContext : DbContext, IUnitOfWork
	{
		private readonly IMediator _mediator;
		public const string DEFAULT_SCHEMA = "equipment";

		public DbSet<Domain.AggregatesModel.EquipmentAggregates.Equipment> Equipments { get; set; }

		public async Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			await _mediator.DispatchDomainEventsAsync(this);

			await base.SaveChangesAsync(cancellationToken);

			return true;
		}

		public EquipmentContext(DbContextOptions<EquipmentContext> options, IMediator mediator) : base(options)
		{
			_mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new EquipmentEntityTypeConfiguration());
		}
	}
}
