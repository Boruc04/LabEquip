using Autofac;
using MediatR;
using System.Reflection;

namespace Boruc.LabEquip.Services.Equipment.API.Infrastructure.AutofacModules
{
	using Boruc.LabEquip.Services.Equipment.Application.Commands;

	public class MediatorModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(typeof(CreateEquipmentCommand).GetTypeInfo().Assembly)
				.AsClosedTypesOf(typeof(IRequestHandler<,>));


			//TODO: Register domain event handler and Validators

			builder.Register<ServiceFactory>(context =>
			{
				var componentContext = context.Resolve<IComponentContext>();
				return t =>
				{
					object o;
					return componentContext.TryResolve(t, out o) ? o : null;
				};
			});

			//TODO: register behaviours
		}
	}
}
