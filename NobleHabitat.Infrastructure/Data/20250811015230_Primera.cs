using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NobleHabitat.Infrastructure.Data
{
    /// <inheritdoc />
    public partial class Primera : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "oficinas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_oficinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "usuarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EsAdmin = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuarios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "zonas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    OficinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_zonas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_zonas_oficinas_OficinaId",
                        column: x => x.OficinaId,
                        principalTable: "oficinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agentes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OficinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_agentes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_agentes_oficinas_OficinaId",
                        column: x => x.OficinaId,
                        principalTable: "oficinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_agentes_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Telefono = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_clientes_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propietarios",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UsuarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_propietarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_propietarios_usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "inmuebles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Superficie = table.Column<double>(type: "float", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PoseeLlaves = table.Column<bool>(type: "bit", nullable: false),
                    OficinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PropietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ZonaId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    AgenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_inmuebles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_inmuebles_agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "agentes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_inmuebles_oficinas_OficinaId",
                        column: x => x.OficinaId,
                        principalTable: "oficinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inmuebles_propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "propietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_inmuebles_zonas_ZonaId",
                        column: x => x.ZonaId,
                        principalTable: "zonas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "caracteristicaInmuebles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_caracteristicaInmuebles", x => x.Id);
                    table.ForeignKey(
                        name: "FK_caracteristicaInmuebles_inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "inmuebles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "estancias",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Tipo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Caracteristicas = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estancias", x => x.Id);
                    table.ForeignKey(
                        name: "FK_estancias_inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "inmuebles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ofertas",
                columns: table => new
                {
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EnVenta = table.Column<bool>(type: "bit", nullable: false),
                    EnAlquiler = table.Column<bool>(type: "bit", nullable: false),
                    PrecioVenta = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true),
                    PrecioAlquiler = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ofertas", x => x.InmuebleId);
                    table.ForeignKey(
                        name: "FK_ofertas_inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "inmuebles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "visitas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InmuebleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClienteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaHora = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PropietarioId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    OficinaId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AgenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_visitas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_visitas_agentes_AgenteId",
                        column: x => x.AgenteId,
                        principalTable: "agentes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_visitas_clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_visitas_inmuebles_InmuebleId",
                        column: x => x.InmuebleId,
                        principalTable: "inmuebles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_visitas_oficinas_OficinaId",
                        column: x => x.OficinaId,
                        principalTable: "oficinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_visitas_propietarios_PropietarioId",
                        column: x => x.PropietarioId,
                        principalTable: "propietarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_agentes_OficinaId",
                table: "agentes",
                column: "OficinaId");

            migrationBuilder.CreateIndex(
                name: "IX_agentes_UsuarioId",
                table: "agentes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_caracteristicaInmuebles_InmuebleId",
                table: "caracteristicaInmuebles",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_UsuarioId",
                table: "clientes",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_estancias_InmuebleId",
                table: "estancias",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_AgenteId",
                table: "inmuebles",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_OficinaId",
                table: "inmuebles",
                column: "OficinaId");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_PropietarioId",
                table: "inmuebles",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_inmuebles_ZonaId",
                table: "inmuebles",
                column: "ZonaId");

            migrationBuilder.CreateIndex(
                name: "IX_propietarios_UsuarioId",
                table: "propietarios",
                column: "UsuarioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_visitas_AgenteId",
                table: "visitas",
                column: "AgenteId");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_ClienteId",
                table: "visitas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_InmuebleId",
                table: "visitas",
                column: "InmuebleId");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_OficinaId",
                table: "visitas",
                column: "OficinaId");

            migrationBuilder.CreateIndex(
                name: "IX_visitas_PropietarioId",
                table: "visitas",
                column: "PropietarioId");

            migrationBuilder.CreateIndex(
                name: "IX_zonas_OficinaId",
                table: "zonas",
                column: "OficinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "caracteristicaInmuebles");

            migrationBuilder.DropTable(
                name: "estancias");

            migrationBuilder.DropTable(
                name: "ofertas");

            migrationBuilder.DropTable(
                name: "visitas");

            migrationBuilder.DropTable(
                name: "clientes");

            migrationBuilder.DropTable(
                name: "inmuebles");

            migrationBuilder.DropTable(
                name: "agentes");

            migrationBuilder.DropTable(
                name: "propietarios");

            migrationBuilder.DropTable(
                name: "zonas");

            migrationBuilder.DropTable(
                name: "usuarios");

            migrationBuilder.DropTable(
                name: "oficinas");
        }
    }
}
