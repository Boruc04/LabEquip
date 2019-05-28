using Autofac;
using FluentValidation;
using MediatR;
using System.Reflection;

namespace Boruc.LabEquip.Services.Equipment.API.Infrastructure.AutofacModules
{
	using Application.Behaviors;
	using Application.Commands;
	using Application.Validations;

	public class MediatorModule : Autofac.Module
	{
		protected override void Load(ContainerBuilder builder)
		{
			builder.RegisterAssemblyTypes(typeof(IMediator).GetTypeInfo().Assembly).AsImplementedInterfaces();

			builder.RegisterAssemblyTypes(typeof(CreateEquipmentCommand).GetTypeInfo().Assembly)
				.AsClosedTypesOf(typeof(IRequestHandler<,>));

			builder.RegisterAssemblyTypes(typeof(CreateEquipmentCommandValidator).GetTypeInfo().Assembly)
				.Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
				.AsImplementedInterfaces();

			//TODO: Register the DomainEventHandler classes 

			builder.Register<ServiceFactory>(context =>
			{
				var componentContext = context.Resolve<IComponentContext>();
				return t =>
				{
					object o;
					return componentContext.TryResolve(t, out o) ? o : null;
				};
			});

			builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
			builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
		}
	}
}
