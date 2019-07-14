using System;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.EntityConfigurations
{
	class ActionTaskTypeEntityTypeConfiguration : IEntityTypeConfiguration<ActionTaskType>
	{
		public void Configure(EntityTypeBuilder<ActionTaskType> builder)
		{
			builder.ToTable("ActionTaskTypes", EquipmentContext.DEFAULT_SCHEMA);

			builder.HasKey(att => att.Id);

			builder.Property(att => att.Id)
				.ForSqlServerUseSequenceHiLo("actionTaskTypesSeq", EquipmentContext.DEFAULT_SCHEMA);

			builder.Property<int>("EquipmentId")
				.IsRequired();

			builder.Property<DateTime>("FirstOccurrence")
				.IsRequired();

			builder.Property<int>("TaskTypeId")
				.IsRequired();
			builder.HasOne(a => a.TaskType)
				.WithMany()
				.HasForeignKey("TaskTypeId")
				.OnDelete(DeleteBehavior.ClientSetNull);

			builder.Property<int>("TaskFrequencyId")
				.IsRequired();
			builder.HasOne(a => a.TaskFrequency)
				.WithMany()
				.HasForeignKey("TaskFrequencyId")
				.OnDelete(DeleteBehavior.ClientSetNull);
		}
	}
}
