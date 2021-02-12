using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PrimerParcial.Migrations
{
    public partial class AddedDbSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_Clasificacion_Articulos_ClasificacionArticulosId",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Suplidores_Clasificacion_Suplidores_ClasificacionId",
                table: "Suplidores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clasificacion_Suplidores",
                table: "Clasificacion_Suplidores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clasificacion_Articulos",
                table: "Clasificacion_Articulos");

            migrationBuilder.RenameTable(
                name: "Clasificacion_Suplidores",
                newName: "ClasificacionSuplidores");

            migrationBuilder.RenameTable(
                name: "Clasificacion_Articulos",
                newName: "ClasificacionArticulos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClasificacionSuplidores",
                table: "ClasificacionSuplidores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ClasificacionArticulos",
                table: "ClasificacionArticulos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ClasificacionClientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Clasificacion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormasEnvio",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasEnvio", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FormasPago",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descripcion = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormasPago", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Monedas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Monedas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PuestosTrabajo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PuestosTrabajo", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(nullable: true),
                    ClasificacionId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_ClasificacionClientes_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "ClasificacionClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Ciudades",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    PaisId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ciudades", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ciudades_Paises_PaisId",
                        column: x => x.PaisId,
                        principalTable: "Paises",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Empleados",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: false),
                    DateOfBirth = table.Column<DateTime>(nullable: false),
                    HiredDate = table.Column<DateTime>(nullable: false),
                    JobTitleId = table.Column<int>(nullable: false),
                    EmpresaId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleados", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Empleados_Empresas_EmpresaId",
                        column: x => x.EmpresaId,
                        principalTable: "Empresas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Empleados_PuestosTrabajo_JobTitleId",
                        column: x => x.JobTitleId,
                        principalTable: "PuestosTrabajo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ciudades_PaisId",
                table: "Ciudades",
                column: "PaisId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClasificacionId",
                table: "Clientes",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_EmpresaId",
                table: "Empleados",
                column: "EmpresaId");

            migrationBuilder.CreateIndex(
                name: "IX_Empleados_JobTitleId",
                table: "Empleados",
                column: "JobTitleId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_ClasificacionArticulos_ClasificacionArticulosId",
                table: "Articulos",
                column: "ClasificacionArticulosId",
                principalTable: "ClasificacionArticulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suplidores_ClasificacionSuplidores_ClasificacionId",
                table: "Suplidores",
                column: "ClasificacionId",
                principalTable: "ClasificacionSuplidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articulos_ClasificacionArticulos_ClasificacionArticulosId",
                table: "Articulos");

            migrationBuilder.DropForeignKey(
                name: "FK_Suplidores_ClasificacionSuplidores_ClasificacionId",
                table: "Suplidores");

            migrationBuilder.DropTable(
                name: "Ciudades");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleados");

            migrationBuilder.DropTable(
                name: "FormasEnvio");

            migrationBuilder.DropTable(
                name: "FormasPago");

            migrationBuilder.DropTable(
                name: "Monedas");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.DropTable(
                name: "ClasificacionClientes");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropTable(
                name: "PuestosTrabajo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClasificacionSuplidores",
                table: "ClasificacionSuplidores");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ClasificacionArticulos",
                table: "ClasificacionArticulos");

            migrationBuilder.RenameTable(
                name: "ClasificacionSuplidores",
                newName: "Clasificacion_Suplidores");

            migrationBuilder.RenameTable(
                name: "ClasificacionArticulos",
                newName: "Clasificacion_Articulos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clasificacion_Suplidores",
                table: "Clasificacion_Suplidores",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clasificacion_Articulos",
                table: "Clasificacion_Articulos",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Articulos_Clasificacion_Articulos_ClasificacionArticulosId",
                table: "Articulos",
                column: "ClasificacionArticulosId",
                principalTable: "Clasificacion_Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Suplidores_Clasificacion_Suplidores_ClasificacionId",
                table: "Suplidores",
                column: "ClasificacionId",
                principalTable: "Clasificacion_Suplidores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
