using System;
using Boruc.LabEquip.Services.SharedKernelES;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES
{
	public interface IEquipmentRepositoryES : IRepository<Equipment2>
	{
		void Add(Equipment2 aggregateRoot, int expectedVersion);
		Equipment2 GetById(Guid id);
	}
}
