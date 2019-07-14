using Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.EntityConfigurations
{
	class BookEntityTypeConfiguration : IEntityTypeConfiguration<Book>
	{
		public void Configure(EntityTypeBuilder<Book> builder)
		{
			builder.ToTable("Books", EquipmentContext.DEFAULT_SCHEMA);

			builder.HasKey(b => b.Id);

			builder.Ignore(b => b.DomainEvents);

			builder.Property(b => b.Id).ForSqlServerUseSequenceHiLo("bookseq", EquipmentContext.DEFAULT_SCHEMA);
		}
	}
}
