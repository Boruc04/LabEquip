using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.Queries
{
	public interface IEquipmentQueries
	{
		Task<IEnumerable <EquipmentViewModel>> GetEquipmentsAsync();
		Task<EquipmentViewModel> GetEquipmentAsync(int equipmentId);
	}
}