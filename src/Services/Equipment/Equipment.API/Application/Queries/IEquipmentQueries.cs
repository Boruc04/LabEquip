using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.API.Application.Queries
{
	public interface IEquipmentQueries
	{
		Task<Equipment> GetEquipmentAsync();
	}
}