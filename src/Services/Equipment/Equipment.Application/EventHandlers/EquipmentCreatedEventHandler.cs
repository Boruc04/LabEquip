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
		private readonly IEquipmentRepositoryES _equipmentRepositoryES;

		public EquipmentCreatedEventHandler(IReadModelFacadeWrite modelFacadeWrite,
			IEquipmentRepositoryES equipmentRepositoryES)
		{
			_modelFacadeWrite = modelFacadeWrite;
			_equipmentRepositoryES = equipmentRepositoryES;
		}

		public Task Handle(EquipmentCreatedEvent notification, CancellationToken cancellationToken)
		{
			// Get the latest Aggregate snapshot
			var equipment = _equipmentRepositoryES.GetById(notification.AggregateId);
			// Apply event
			equipment.LoadFromHistory(new[] { notification });
			// Save in readonly DB.
			_modelFacadeWrite.AddEquipment(equipment);
			return Task.CompletedTask;
		}
	}
}
