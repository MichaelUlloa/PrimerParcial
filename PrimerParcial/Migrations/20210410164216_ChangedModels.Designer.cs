﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PrimerParcial.Data;

namespace PrimerParcial.Migrations
{
    [DbContext(typeof(ParcialDbContext))]
    [Migration("20210410164216_ChangedModels")]
    partial class ChangedModels
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PrimerParcial.Models.Articulos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClasificacionArticulosId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MarcaId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Stock")
                        .HasColumnType("int");

                    b.Property<int>("UnidadesDeMedidaId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionArticulosId");

                    b.HasIndex("MarcaId");

                    b.HasIndex("UnidadesDeMedidaId");

                    b.ToTable("Articulos");
                });

            modelBuilder.Entity("PrimerParcial.Models.Ciudades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PaisId")
                        .HasColumnType("int");

                    b.Property<int>("UbicacionesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("PaisId");

                    b.HasIndex("UbicacionesId");

                    b.ToTable("Ciudades");
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

                    b.ToTable("ClasificacionArticulos");
                });

            modelBuilder.Entity("PrimerParcial.Models.Clasificacion_Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Clasificacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ClasificacionClientes");
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

                    b.ToTable("ClasificacionSuplidores");
                });

            modelBuilder.Entity("PrimerParcial.Models.Clientes", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClasificacionId")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("PrimerParcial.Models.Empleados", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmpresaId")
                        .HasColumnType("int");

                    b.Property<DateTime>("HiredDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("JobTitleId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmpresaId");

                    b.HasIndex("JobTitleId");

                    b.ToTable("Empleados");
                });

            modelBuilder.Entity("PrimerParcial.Models.Empresas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Empresas");
                });

            modelBuilder.Entity("PrimerParcial.Models.Formas_de_Envio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormasEnvio");
                });

            modelBuilder.Entity("PrimerParcial.Models.Formas_de_Pagos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("FormasPago");
                });

            modelBuilder.Entity("PrimerParcial.Models.Marcas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Marcas");
                });

            modelBuilder.Entity("PrimerParcial.Models.Monedas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Monedas");
                });

            modelBuilder.Entity("PrimerParcial.Models.OrdenCompraDetalle", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ArticuloId")
                        .HasColumnType("int");

                    b.Property<int>("Cantidad")
                        .HasColumnType("int");

                    b.Property<string>("Descripcion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("ITBIS")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("OrdenCompraMasterId")
                        .HasColumnType("int");

                    b.Property<decimal>("Precio")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Subtotal")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Total")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ArticuloId");

                    b.HasIndex("OrdenCompraMasterId");

                    b.ToTable("OrdenCompraDetalles");
                });

            modelBuilder.Entity("PrimerParcial.Models.OrdenCompraMaster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("FechaLlegada")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaPedido")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("FechaSalida")
                        .HasColumnType("datetime2");

                    b.Property<int>("FormaEnvioId")
                        .HasColumnType("int");

                    b.Property<int>("FormaPagoId")
                        .HasColumnType("int");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("FormaEnvioId");

                    b.HasIndex("FormaPagoId");

                    b.HasIndex("SuplidorId");

                    b.ToTable("OrdenCompraMasters");
                });

            modelBuilder.Entity("PrimerParcial.Models.Paises", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Paises");
                });

            modelBuilder.Entity("PrimerParcial.Models.Puestos_de_Trabajos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("PuestosTrabajo");
                });

            modelBuilder.Entity("PrimerParcial.Models.Suplidores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClasificacionId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("ClasificacionId");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("PrimerParcial.Models.Tasas_de_Cambio", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Equivalencia")
                        .HasColumnType("int");

                    b.Property<int>("MonedasId")
                        .HasColumnType("int");

                    b.Property<string>("ParDeMoneda")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("MonedasId");

                    b.ToTable("Tasas_de_Cambio");
                });

            modelBuilder.Entity("PrimerParcial.Models.Tipos_de_Documentos", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("TipoDocumento")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Tipos_de_Documentos");
                });

            modelBuilder.Entity("PrimerParcial.Models.Ubicaciones", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Ubicacion")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ubicaciones");
                });

            modelBuilder.Entity("PrimerParcial.Models.Unidades_de_Medida", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CantidadMedida")
                        .HasColumnType("int");

                    b.Property<string>("Medida")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Unidades_de_Medida");
                });

            modelBuilder.Entity("PrimerParcial.Models.Vendedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("PrimerParcial.Models.Articulos", b =>
                {
                    b.HasOne("PrimerParcial.Models.Clasificacion_Articulos", "ClasificacionArticulos")
                        .WithMany("Articulos")
                        .HasForeignKey("ClasificacionArticulosId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimerParcial.Models.Marcas", "Marca")
                        .WithMany("Articulos")
                        .HasForeignKey("MarcaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimerParcial.Models.Unidades_de_Medida", "UnidadesDeMedida")
                        .WithMany("Articulos")
                        .HasForeignKey("UnidadesDeMedidaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimerParcial.Models.Ciudades", b =>
                {
                    b.HasOne("PrimerParcial.Models.Paises", "Pais")
                        .WithMany("Ciudades")
                        .HasForeignKey("PaisId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimerParcial.Models.Ubicaciones", "Ubicaciones")
                        .WithMany("Ciudades")
                        .HasForeignKey("UbicacionesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimerParcial.Models.Clientes", b =>
                {
                    b.HasOne("PrimerParcial.Models.Clasificacion_Clientes", "Clasificacion")
                        .WithMany("Clientes")
                        .HasForeignKey("ClasificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimerParcial.Models.Empleados", b =>
                {
                    b.HasOne("PrimerParcial.Models.Empresas", "Empresa")
                        .WithMany("Empleados")
                        .HasForeignKey("EmpresaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimerParcial.Models.Puestos_de_Trabajos", "JobTitle")
                        .WithMany("Empleados")
                        .HasForeignKey("JobTitleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimerParcial.Models.OrdenCompraDetalle", b =>
                {
                    b.HasOne("PrimerParcial.Models.Articulos", "Articulo")
                        .WithMany()
                        .HasForeignKey("ArticuloId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimerParcial.Models.OrdenCompraMaster", "OrdenCompraMaster")
                        .WithMany("OrdenCompraDetalles")
                        .HasForeignKey("OrdenCompraMasterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimerParcial.Models.OrdenCompraMaster", b =>
                {
                    b.HasOne("PrimerParcial.Models.Formas_de_Envio", "FormaEnvio")
                        .WithMany()
                        .HasForeignKey("FormaEnvioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimerParcial.Models.Formas_de_Pagos", "FormaPago")
                        .WithMany()
                        .HasForeignKey("FormaPagoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PrimerParcial.Models.Suplidores", "Suplidor")
                        .WithMany()
                        .HasForeignKey("SuplidorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimerParcial.Models.Suplidores", b =>
                {
                    b.HasOne("PrimerParcial.Models.Clasificacion_Suplidores", "Clasificacion")
                        .WithMany("Suplidores")
                        .HasForeignKey("ClasificacionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PrimerParcial.Models.Tasas_de_Cambio", b =>
                {
                    b.HasOne("PrimerParcial.Models.Monedas", "Monedas")
                        .WithMany("TasasDeCambio")
                        .HasForeignKey("MonedasId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
