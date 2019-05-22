using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Application.Commands
{


	public class CreateEquipmentCommandHandler : IRequestHandler<CreateEquipmentCommand, EquipmentDTO>
	{
		public Task<EquipmentDTO> Handle(CreateEquipmentCommand request, CancellationToken cancellationToken)
		{
			throw new System.NotImplementedException();
		}
	}
	public class EquipmentDTO
	{
	}
}
