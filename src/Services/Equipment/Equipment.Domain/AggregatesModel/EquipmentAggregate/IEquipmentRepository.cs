using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate
{
	using SharedKernel;

	public interface IEquipmentRepository : IRepository<Equipment>
	{
		Equipment Add(Equipment equipment);

		void Update(Equipment equipment);

		Task<Equipment> GetAsync(int equipmentId);
	}
}
