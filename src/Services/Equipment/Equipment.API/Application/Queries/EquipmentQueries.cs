using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.API.Application.Queries
{
	public class EquipmentQueries : IEquipmentQueries
	{
		public Task<Equipment> GetEquipmentAsync()
		{
			return Task.FromResult(new Equipment()
			{
				BookId = 1,
				EquipmentName = "asd",
				Number = "123"
			});
		}
	}
}
