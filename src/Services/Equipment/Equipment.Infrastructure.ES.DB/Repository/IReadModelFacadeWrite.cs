using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES;

namespace Equipment.Infrastructure.ES.DB.Repository {
	public interface IReadModelFacadeWrite
	{
		void AddEquipment(EquipmentES equipment);
	}
}