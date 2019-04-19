using System;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EntityConfigurations
{
	class EquipmentEntityTypeConfiguration : IEntityTypeConfiguration<Domain.AggregatesModel.EquipmentAggregates.Equipment>
	{
		public void Configure(EntityTypeBuilder<Domain.AggregatesModel.EquipmentAggregates.Equipment> builder)
		{
			builder.ToTable("equipments", EquipmentContext.DEFAULT_SCHEMA);

			builder.HasKey(e => e.Id);

			builder.Ignore(e => e.DomainEvents);

			builder.Property(e => e.Id).ForSqlServerUseSequenceHiLo("equipmentseq", EquipmentContext.DEFAULT_SCHEMA);

			builder.Property<string>("Name").IsRequired();
			builder.Property<string>("Number").IsRequired();
			builder.Property<DateTime>("AddedOnUTC").IsRequired();

			builder.HasOne<Book>()
				.WithMany()
				.HasForeignKey("BookId")
				.IsRequired(false)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
