using Boruc.LabEquip.Services.Equipment.Application.Commands;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregateES;
using MediatR;
using Microsoft.Extensions.Logging;
using SharedKernelES;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.CommandHandlers
{
	public class CreateEquipmentCommandHandlerES : IRequestHandler<CreateEquipmentCommand>
	{
		private readonly ILogger<CreateEquipmentCommandHandlerES> _logger;
		private readonly IRepository<Equipment2> _repository;

		public CreateEquipmentCommandHandlerES(ILogger<CreateEquipmentCommandHandlerES> logger,
			IRepository<Equipment2> repository)
		{
			_logger = logger ?? throw new ArgumentNullException(nameof(logger));
			_repository = repository ?? throw new ArgumentNullException(nameof(repository));
		}

		public async Task<Unit> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
		{
			var equipment = new Equipment2(request.EquipmentId, request.Name, request.Number);
			_logger.LogInformation("----- Creating Equipment - Equipment: {@equipment}", equipment);

			_repository.Add(equipment, -1);
			_repository.UnitOfWork.saveAsync();

			return new Unit();
		}
	}
}
