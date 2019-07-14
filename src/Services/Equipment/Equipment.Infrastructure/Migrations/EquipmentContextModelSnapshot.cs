﻿// ReSharper disable All
// <auto-generated />

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Boruc.LabEquip.Services.Equipment.Infrastructure.EF.Migrations
{
    [DbContext(typeof(EquipmentContext))]
    partial class EquipmentContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("Relational:Sequence:equipment.actionTaskTypesSeq", "'actionTaskTypesSeq', 'equipment', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:equipment.bookseq", "'bookseq', 'equipment', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("Relational:Sequence:equipment.equipmentseq", "'equipmentseq', 'equipment', '1', '10', '', '', 'Int64', 'False'")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.ActionTaskType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "actionTaskTypesSeq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "equipment")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.Property<int>("EquipmentId");

                    b.Property<DateTime>("FirstOccurrence");

                    b.Property<int>("TaskFrequencyId");

                    b.Property<int>("TaskTypeId");

                    b.HasKey("Id");

                    b.HasIndex("EquipmentId");

                    b.HasIndex("TaskFrequencyId");

                    b.HasIndex("TaskTypeId");

                    b.ToTable("ActionTaskTypes","equipment");
                });

            modelBuilder.Entity("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.Book", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:HiLoSequenceName", "bookseq")
                        .HasAnnotation("SqlServer:HiLoSequenceSchema", "equipment")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.SequenceHiLo);

                    b.HasKey("Id");

                    b.ToTable("Books","equipment");
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

                    b.ToTable("Equipments","equipment");
                });

            modelBuilder.Entity("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.TaskFrequency", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("TaskFrequencies","equipment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Monthly"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Yearly"
                        });
                });

            modelBuilder.Entity("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.TaskType", b =>
                {
                    b.Property<int>("Id")
                        .HasDefaultValue(1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(200);

                    b.HasKey("Id");

                    b.ToTable("TaskTypes","equipment");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Validation"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Calibration"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Overview"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Repair"
                        });
                });

            modelBuilder.Entity("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.ActionTaskType", b =>
                {
                    b.HasOne("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.Equipment")
                        .WithMany("ActionTaskTypes")
                        .HasForeignKey("EquipmentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.TaskFrequency", "TaskFrequency")
                        .WithMany()
                        .HasForeignKey("TaskFrequencyId");

                    b.HasOne("Boruc.LabEquip.Services.Equipment.Domain.AggregatesModel.EquipmentAggregate.TaskType", "TaskType")
                        .WithMany()
                        .HasForeignKey("TaskTypeId");
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
