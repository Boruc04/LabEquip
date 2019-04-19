using Boruc.LabEquip.Services.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure
{
	public class EquipmentContext : DbContext, IUnitOfWork
	{
		public const string DEFAULT_SCHEMA = "equipment";

		public DbSet<Domain.AggregatesModel.EquipmentAggregates.Equipment> Equipments { get; set; }

		public Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
		{
			throw new System.NotImplementedException();
		}
	}
}
