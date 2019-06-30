using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.CommandHandlers
{
	using Commands;
	using Domain.AggregatesModel.EquipmentAggregate;

	public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand>
	{
		private readonly IEquipmentRepository _equipmentRepository;
		private readonly ILogger<CreateEquipmentCommandHandler> _logger;

		public CreateEquipmentCommandHandler(IEquipmentRepository equipmentRepository,
			ILogger<CreateEquipmentCommandHandler> logger)
		{
			_equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<Unit> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
		{
			var equipment = new Equipment(request.Name, request.Number);
			_logger.LogInformation("----- Creating Equipment - Equipment: {@equipment}", equipment);

			_equipmentRepository.Add(equipment);

			await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
			return new Unit();
		}
	}
}
