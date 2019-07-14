using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries {
	public interface IEquipmentESQueries
	{
		Task<IEnumerable<EquipmentESViewModel>> GetEquipmentsAsync();
		Task<EquipmentESViewModel> GetEquipmentAsync(Guid equipmentId);
	}
}