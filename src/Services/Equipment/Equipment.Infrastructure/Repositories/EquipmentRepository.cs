using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregates;
using Boruc.LabEquip.Services.SharedKernel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.Repositories
{
	public class EquipmentRepository : IEquipmentRepository
	{
		private readonly EquipmentContext _context;

		public IUnitOfWork UnitOfWork => _context;

		public EquipmentRepository(EquipmentContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public Domain.AggregatesModel.EquipmentAggregates.Equipment Add(Domain.AggregatesModel.EquipmentAggregates.Equipment equipment)
		{
			return _context.Equipments.Add(equipment).Entity;
		}

		public void Update(Domain.AggregatesModel.EquipmentAggregates.Equipment equipment)
		{
			_context.Entry(equipment).State = EntityState.Modified;
		}

		public Task<Domain.AggregatesModel.EquipmentAggregates.Equipment> GetAsync(int equipmentId)
		{
			return _context.Equipments.FindAsync(equipmentId);
		}
	}
}
