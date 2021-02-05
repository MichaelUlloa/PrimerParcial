﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimerParcial.Data;

namespace PrimerParcial.Migrations
{
    [DbContext(typeof(ParcialDbContext))]
    partial class ParcialDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrimerParcial.Models.Articulos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Clasificacion_ArticulosId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Clasificacion_ArticulosId");

                    b.HasIndex("SuplidorId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("PrimerParcial.Models.Clasificacion_Articulos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clasificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clasificacion_Articulos");
                });

            modelBuilder.Entity("PrimerParcial.Models.Clasificacion_Suplidores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clasificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Clasificacion_Suplidores");
                });

            modelBuilder.Entity("PrimerParcial.Models.Suplidores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClasificacionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionId");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("PrimerParcial.Models.Articulos", b =>
                {
                    b.HasOne("PrimerParcial.Models.Clasificacion_Articulos", "Clasificacion")
                        .WithMany("Articulos")
                        .HasForeignKey("Clasificacion_ArticulosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimerParcial.Models.Suplidores", "Suplidor")
                        .WithMany("Articulos")
                        .HasForeignKey("SuplidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimerParcial.Models.Suplidores", b =>
                {
                    b.HasOne("PrimerParcial.Models.Clasificacion_Suplidores", "Clasificacion")
                        .WithMany("Suplidores")
                        .HasForeignKey("ClasificacionId");
                });
#pragma warning restore 612, 618
        }
    }
}
