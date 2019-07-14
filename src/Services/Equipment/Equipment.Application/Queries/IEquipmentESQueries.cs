using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries {
	public interface IEquipmentESQueries
	{
		Task<IEnumerable<EquipmentES>> GetEquipmentsAsync();
		Task<EquipmentES> GetEquipmentAsync(Guid equipmentId);
	}
}