using Boruc.LabEquip.Services.Equipment.Application.Commands;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.CommandHandlers
{
	public class CreateEquipmentESCommandHandler : IRequestHandler<CreateEquipmentESCommand, Guid>
	{
		private readonly ILogger<CreateEquipmentESCommandHandler> _logger;
		private readonly IEquipmentRepositoryES _repository;

		public CreateEquipmentESCommandHandler(ILogger<CreateEquipmentESCommandHandler> logger,
			IEquipmentRepositoryES repository)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<Guid> Handle(CreateEquipmentESCommand request, CancellationToken cancellationToken)
		{
			var equipmentId = Guid.NewGuid();
			var equipment = new EquipmentES(equipmentId, request.Name, request.Number);
			_logger.LogInformation("----- Creating Equipment - Equipment: {@equipment}", equipment);

			_repository.Add(equipment, -1);
			_repository.UnitOfWork.SaveAsync();

			return equipmentId;
		}
	}
}
