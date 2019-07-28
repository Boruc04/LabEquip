using Equipment.Infrastructure.ES.DB.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.EventHandlers
{
	using Domain.AggregatesModel.EquipmentAggregateES;
	using Domain.EventsES;

	public class EquipmentCreatedEventHandler : INotificationHandler<EquipmentCreatedEvent>
	{
		private readonly IReadModelFacadeWrite _modelFacadeWrite;
		private readonly IEquipmentESRepository _equipmentESRepository;

		public EquipmentCreatedEventHandler(IReadModelFacadeWrite modelFacadeWrite,
			IEquipmentESRepository equipmentESRepository)
		{
			_modelFacadeWrite = modelFacadeWrite;
			_equipmentESRepository = equipmentESRepository;
		}

		public Task Handle(EquipmentCreatedEvent notification, CancellationToken cancellationToken)
		{
			// Get the latest Aggregate snapshot
			var equipment = _equipmentESRepository.GetById(notification.AggregateId);
			// Apply event
			equipment.LoadFromHistory(new[] { notification });
			// Save in readonly DB.
			_modelFacadeWrite.AddEquipment(equipment);
			return Task.CompletedTask;
		}
	}
}
