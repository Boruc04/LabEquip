﻿// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.Migrations
{
    [DbContext(typeof(EquipmentContext))]
    [Migration("20190519165931_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:equipment.bookseq", "'bookseq', 'equipment', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:equipment.equipmentseq", "'equipmentseq', 'equipment', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "bookseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "equipment")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.HasKey("Id");

                    b.ToTable("books","equipment");
                });

            modelBuilder.Entity("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.Equipment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "equipmentseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "equipment")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<DateTime>("AddedOnUTC");

                    b.Property<int?>("BookId");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<string>("Number")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("BookId");

                    b.ToTable("equipments","equipment");
                });

            modelBuilder.Entity("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.Equipment", b =>
                {
                    b.HasOne("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.Book")
                        .WithMany()
                        .HasForeignKey("BookId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
