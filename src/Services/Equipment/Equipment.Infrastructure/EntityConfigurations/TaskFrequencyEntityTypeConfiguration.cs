using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EntityConfigurations
{
	class TaskFrequencyEntityTypeConfiguration : IEntityTypeConfiguration<TaskFrequency>
	{
		public void Configure(EntityTypeBuilder<TaskFrequency> builder)
		{
			builder.ToTable("TaskFrequencies", EquipmentContext.DEFAULT_SCHEMA);

			builder.HasKey(o => o.Id);

			builder.Property(o => o.Id)
				.HasDefaultValue(1)
				.ValueGeneratedNever()
				.IsRequired();

			builder.Property(o => o.Name)
				.HasMaxLength(200)
				.IsRequired();
		}
	}
}
