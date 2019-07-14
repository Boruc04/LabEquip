using System;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.EntityConfigurations
{
	class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.EquipmentAggregate.Equipment>
	{
		public void Configure(EntityTypeBuilder<Domain.AggregatesModel.EquipmentAggregate.Equipment> builder)
		{
			builder.ToTable("Equipments", EquipmentContext.DEFAULT_SCHEMA);

			builder.HasKey(e => e.Id);

			builder.Ignore(e => e.DomainEvents);

			builder.Property(e => e.Id).ForSqlServerUseSequenceHiLo("equipmentseq", EquipmentContext.DEFAULT_SCHEMA);

			builder.Property<string>("Name")
				.IsRequired();

			builder.Property<string>("Number").IsRequired();

			builder.Property<DateTime>("AddedOnUTC").IsRequired();

			builder.HasOne<Book>()
				.WithMany()
				.HasForeignKey("BookId")
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Cascade);

			var navigation = builder.Metadata.FindNavigation(nameof(Domain.AggregatesModel.EquipmentAggregate.Equipment.ActionTaskTypes));
			navigation.SetPropertyAccessMode(PropertyAccessMode.Field);
		}
	}
}
