using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.Repositories
{
	using Domain.AggregatesModel.EquipmentAggregate;
	using SharedKernel;

	public class EquipmentRepository : IEquipmentRepository
	{
		private readonly EquipmentContext _context;

		public IUnitOfWork UnitOfWork => _context;

		public EquipmentRepository(EquipmentContext context)
		{
			_context = context ?? throw new ArgumentNullException(nameof(context));
		}

		public Equipment Add(Equipment equipment)
		{
			return _context.Equipments.Add(equipment).Entity;
		}

		public void Update(Equipment equipment)
		{
			_context.Entry(equipment).State = EntityState.Modified;
		}

		public Task<Equipment> GetAsync(int equipmentId)
		{
			return _context.Equipments.FindAsync(equipmentId);
		}
	}
}
