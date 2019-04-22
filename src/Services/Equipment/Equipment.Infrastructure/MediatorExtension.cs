﻿using Boruc.LabEquip.Services.SharedKernel;
using MediatR;
using System.Linq;
using System.Threading.Tasks;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure
{
	static class MediatorExtension
	{
		public static async Task DispatchDomainEventsAsync(this IMediator mediator, EquipmentContext context)
		{
			var domainEntities = context.ChangeTracker
				.Entries<Entity>()
				.Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any())
				.ToList();

			var domainEvents = domainEntities
				.SelectMany(x => x.Entity.DomainEvents)
				.ToList();

			domainEntities.ForEach(entity => entity.Entity.ClearDomainEvents());

			var tasks = domainEvents
				.Select(async (domainEvent) =>
				{
					await mediator.Publish(domainEvent);
				});

			await Task.WhenAll(tasks);
		}
	}
}
