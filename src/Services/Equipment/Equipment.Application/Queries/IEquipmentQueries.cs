using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries
{
	public interface IEquipmentQueries
	{
		Task<IEnumerable <Equipment>> GetEquipmentsAsync();
		Task<Equipment> GetEquipmentAsync(int equipmentId);
	}
}