using Equipment.Infrastructure.ES.DB.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries
{
	public class EquipmentESQueries : IEquipmentESQueries
	{
		private readonly IReadModelFacade _readModelFacade;

		public EquipmentESQueries(IReadModelFacade readModelFacade)
		{
			_readModelFacade = readModelFacade;
		}

		public async Task<IEnumerable<EquipmentESViewModel>> GetEquipmentsAsync()
		{
			var equipmentEntities = _readModelFacade.GetEquipments();
			return equipmentEntities.Select(o => new EquipmentESViewModel { Id = o.Id, Name = o.Name, Number = o.Number });
		}

		public async Task<EquipmentESViewModel> GetEquipmentAsync(Guid equipmentId)
		{
			var equipment = _readModelFacade.GetEquipment(equipmentId);
			return EquipmentESViewModel.MapFromEntity(equipment);
		}
	}
}
