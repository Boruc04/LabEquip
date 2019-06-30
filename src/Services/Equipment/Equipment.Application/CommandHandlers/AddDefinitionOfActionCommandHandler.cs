using Boruc.LabEquip.Services.Equipment.Application.Commands;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.CommandHandlers
{
	public class AddDefinitionOfActionCommandHandler : IRequestHandler<CreateActionTypeCommand, bool>
	{
		private readonly IEquipmentRepository _equipmentRepository;
		private readonly ILogger<AddDefinitionOfActionCommandHandler> _logger;

		public AddDefinitionOfActionCommandHandler(IEquipmentRepository equipmentRepository,
			ILogger<AddDefinitionOfActionCommandHandler> logger)
		{
			_equipmentRepository = equipmentRepository ?? throw new ArgumentNullException(nameof(equipmentRepository));
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
		}

		public async Task<bool> Handle(CreateActionTypeCommand request, CancellationToken cancellationToken)
		{
			var equipment = await _equipmentRepository.GetAsync(request.EquipmentId);
			if (equipment == null)
			{
				return false;
			}

			_logger.LogInformation("----- Adding action type to the Equipment: {EquipmentId}", request.EquipmentId);
			equipment.AddActionType(request.FirstOccurenceDateTime, request.TaskFrequencyId, request.TaskTypeId);

			return await _equipmentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);
		}
	}
}
