﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ScheduleApp.Entities;

#nullable disable

namespace ScheduleApp.Migrations
{
    [DbContext(typeof(ScheduleDbContext))]
    [Migration("20230401162325_AddClientId")]
    partial class AddClientId
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ScheduleApp.Entities.Adress", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ClientId")
                        .HasColumnType("int");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PostalCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("ScheduleApp.Entities.Appointment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AppointmentEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("AppointmentStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("ClientInformationsId")
                        .HasColumnType("int");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ServiceId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClientInformationsId");

                    b.HasIndex("ServiceId");

                    b.ToTable("Appointments");
                });

            modelBuilder.Entity("ScheduleApp.Entities.ClientInformations", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AdressId")
                        .HasColumnType("int");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdressId")
                        .IsUnique();

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("ScheduleApp.Entities.Service", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<string>("ServiceName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Services");
                });

            modelBuilder.Entity("ScheduleApp.Entities.Appointment", b =>
                {
                    b.HasOne("ScheduleApp.Entities.ClientInformations", "ClientInformations")
                        .WithMany("Appointments")
                        .HasForeignKey("ClientInformationsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ScheduleApp.Entities.Service", "Service")
                        .WithMany("Appointments")
                        .HasForeignKey("ServiceId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClientInformations");

                    b.Navigation("Service");
                });

            modelBuilder.Entity("ScheduleApp.Entities.ClientInformations", b =>
                {
                    b.HasOne("ScheduleApp.Entities.Adress", "Adress")
                        .WithOne("ClientInformations")
                        .HasForeignKey("ScheduleApp.Entities.ClientInformations", "AdressId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Adress");
                });

            modelBuilder.Entity("ScheduleApp.Entities.Adress", b =>
                {
                    b.Navigation("ClientInformations")
                        .IsRequired();
                });

            modelBuilder.Entity("ScheduleApp.Entities.ClientInformations", b =>
                {
                    b.Navigation("Appointments");
                });

            modelBuilder.Entity("ScheduleApp.Entities.Service", b =>
                {
                    b.Navigation("Appointments");
                });
#pragma warning restore 612, 618
        }
    }
}
