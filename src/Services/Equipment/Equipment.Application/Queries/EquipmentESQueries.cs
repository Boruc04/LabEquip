using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries
{
	public class EquipmentESQueries : IEquipmentESQueries
	{
		private readonly IEquipmentRepositoryES _equipmentRepository;

		public EquipmentESQueries(IEquipmentRepositoryES equipmentRepository)
		{
			_equipmentRepository = equipmentRepository;
		}

		public async Task<IEnumerable<EquipmentES>> GetEquipmentsAsync()
		{
			throw new NotImplementedException();
		}

		public async Task<EquipmentES> GetEquipmentAsync(Guid equipmentId)
		{
			// this is temporary shortcut and should be changed into separate read model repository.
			Domain.AggregatesModel.EquipmentAggregateES.EquipmentES equipment = null;
			await Task.Run(() => equipment = _equipmentRepository.GetById(equipmentId));
			return EquipmentES.MapFromEntity(equipment);
		}
	}
}
