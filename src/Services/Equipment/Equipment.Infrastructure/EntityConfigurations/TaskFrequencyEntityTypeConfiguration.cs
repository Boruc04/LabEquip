using System.Linq;
using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using Boruc.LabEquip.Services.SharedKernel;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.EntityConfigurations
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

			//Hack for derived types on seed - https://github.com/aspnet/EntityFrameworkCore/issues/12841
			var taskFrequencies = Enumeration.GetAll<TaskFrequency>().Select(frequency => new { frequency.Id, frequency.Name });
			builder.HasData(taskFrequencies);
		}
	}
}
