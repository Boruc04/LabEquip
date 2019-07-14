using System;
using System.Threading.Tasks;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using Boruc.LabEquip.Services.SharedKernel;
using Microsoft.EntityFrameworkCore;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.Repositories
{
	public class EquipmentRepository : IEquipmentRepository
	{
		private readonly EquipmentContext _context;

		public IUnitOfWork UnitOfWork => _context;

		public EquipmentRepository(EquipmentContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public Domain.AggregatesModel.EquipmentAggregate.Equipment Add(Domain.AggregatesModel.EquipmentAggregate.Equipment equipment)
		{
			return _context.Equipments.Add(equipment).Entity;
		}

		public void Update(Domain.AggregatesModel.EquipmentAggregate.Equipment equipment)
		{
			_context.Entry(equipment).State = EntityState.Modified;
		}

		public Task<Domain.AggregatesModel.EquipmentAggregate.Equipment> GetAsync(int equipmentId)
		{
			return _context.Equipments.FindAsync(equipmentId);
		}
	}
}
