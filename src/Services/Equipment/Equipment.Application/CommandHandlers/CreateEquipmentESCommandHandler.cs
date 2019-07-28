using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.CommandHandlers
{
	using Commands;
	using Domain.AggregatesModel.EquipmentAggregateES;

	public class CreateEquipmentESCommandHandler : IRequestHandler<CreateEquipmentESCommand, Guid>
	{
		private readonly ILogger<CreateEquipmentESCommandHandler> _logger;
		private readonly IEquipmentESRepository _Repository;

		public CreateEquipmentESCommandHandler(ILogger<CreateEquipmentESCommandHandler> logger,
			IEquipmentESRepository Repository)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_Repository = Repository ?? throw new ArgumentNullException(nameof(Repository));
		}

		public async Task<Guid> Handle(CreateEquipmentESCommand request, CancellationToken cancellationToken)
		{
			var equipmentId = Guid.NewGuid();
			var equipment = new EquipmentES(equipmentId, request.Name, request.Number);
			_logger.LogInformation("----- Creating Equipment - Equipment: {@equipment}", equipment);

			_Repository.Add(equipment, -1);
			_Repository.UnitOfWork.SaveAsync();

			return equipmentId;
		}
	}
}
