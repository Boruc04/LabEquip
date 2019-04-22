using System.Threading.Tasks;
using Boruc.LabEquip.Services.SharedKernel;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregates
{
	public interface IEquipmentRepository :IRepository<Equipment>
	{
		Equipment Add(Equipment equipment);

		void Update(Equipment equipment);

		Task<Equipment> GetAsync(int equipmentId);
	}
}
