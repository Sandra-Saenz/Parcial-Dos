﻿// <auto-generated />
using System;
using Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Infraestructure.Migrations
{
    [DbContext(typeof(CreditoContext))]
    partial class CreditoContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Domain.Entities.Credito", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreditoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("datetime2");

                    b.Property<int>("Plazo")
                        .HasColumnType("int");

                    b.Property<double>("ValorPrestamo")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Creditos");
                });

            modelBuilder.Entity("Domain.Entities.Cuota", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreditoId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreditoId1")
                        .HasColumnType("int");

                    b.Property<DateTime>("FechaCuota")
                        .HasColumnType("datetime2");

                    b.Property<double>("ValorCuota")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("CreditoId1");

                    b.ToTable("Cuota");
                });

            modelBuilder.Entity("Domain.Entities.Cuota", b =>
                {
                    b.HasOne("Domain.Entities.Credito", null)
                        .WithMany("ListaCuotas")
                        .HasForeignKey("CreditoId1");
                });
#pragma warning restore 612, 618
        }
    }
}