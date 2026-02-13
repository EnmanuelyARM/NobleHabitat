using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NobleHabitat.Infrastructure.Data
{
    /// <inheritdoc />
    public partial class RefactorDbContext : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_agentes_oficinas_OficinaId",
                table: "agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_agentes_usuarios_UsuarioId",
                table: "agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_caracteristicaInmuebles_inmuebles_InmuebleId",
                table: "caracteristicaInmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_clientes_usuarios_UsuarioId",
                table: "clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_estancias_inmuebles_InmuebleId",
                table: "estancias");

            migrationBuilder.DropForeignKey(
                name: "FK_inmuebles_agentes_AgenteId",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_inmuebles_oficinas_OficinaId",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_inmuebles_propietarios_PropietarioId",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_inmuebles_zonas_ZonaId",
                table: "inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_ofertas_inmuebles_InmuebleId",
                table: "ofertas");

            migrationBuilder.DropForeignKey(
                name: "FK_propietarios_usuarios_UsuarioId",
                table: "propietarios");

            migrationBuilder.DropForeignKey(
                name: "FK_visitas_agentes_AgenteId",
                table: "visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_visitas_clientes_ClienteId",
                table: "visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_visitas_inmuebles_InmuebleId",
                table: "visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_visitas_oficinas_OficinaId",
                table: "visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_visitas_propietarios_PropietarioId",
                table: "visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_zonas_oficinas_OficinaId",
                table: "zonas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_zonas",
                table: "zonas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_visitas",
                table: "visitas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_propietarios",
                table: "propietarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_oficinas",
                table: "oficinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ofertas",
                table: "ofertas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_inmuebles",
                table: "inmuebles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_estancias",
                table: "estancias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_clientes",
                table: "clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_caracteristicaInmuebles",
                table: "caracteristicaInmuebles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_agentes",
                table: "agentes");

            migrationBuilder.RenameTable(
                name: "zonas",
                newName: "Zonas");

            migrationBuilder.RenameTable(
                name: "visitas",
                newName: "Visitas");

            migrationBuilder.RenameTable(
                name: "usuarios",
                newName: "Usuarios");

            migrationBuilder.RenameTable(
                name: "propietarios",
                newName: "Propietarios");

            migrationBuilder.RenameTable(
                name: "oficinas",
                newName: "Oficinas");

            migrationBuilder.RenameTable(
                name: "ofertas",
                newName: "Ofertas");

            migrationBuilder.RenameTable(
                name: "inmuebles",
                newName: "Inmuebles");

            migrationBuilder.RenameTable(
                name: "estancias",
                newName: "Estancias");

            migrationBuilder.RenameTable(
                name: "clientes",
                newName: "Clientes");

            migrationBuilder.RenameTable(
                name: "caracteristicaInmuebles",
                newName: "CaracteristicaInmuebles");

            migrationBuilder.RenameTable(
                name: "agentes",
                newName: "Agentes");

            migrationBuilder.RenameIndex(
                name: "IX_zonas_OficinaId",
                table: "Zonas",
                newName: "IX_Zonas_OficinaId");

            migrationBuilder.RenameIndex(
                name: "IX_visitas_PropietarioId",
                table: "Visitas",
                newName: "IX_Visitas_PropietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_visitas_OficinaId",
                table: "Visitas",
                newName: "IX_Visitas_OficinaId");

            migrationBuilder.RenameIndex(
                name: "IX_visitas_InmuebleId",
                table: "Visitas",
                newName: "IX_Visitas_InmuebleId");

            migrationBuilder.RenameIndex(
                name: "IX_visitas_ClienteId",
                table: "Visitas",
                newName: "IX_Visitas_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_visitas_AgenteId",
                table: "Visitas",
                newName: "IX_Visitas_AgenteId");

            migrationBuilder.RenameIndex(
                name: "IX_propietarios_UsuarioId",
                table: "Propietarios",
                newName: "IX_Propietarios_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_inmuebles_ZonaId",
                table: "Inmuebles",
                newName: "IX_Inmuebles_ZonaId");

            migrationBuilder.RenameIndex(
                name: "IX_inmuebles_PropietarioId",
                table: "Inmuebles",
                newName: "IX_Inmuebles_PropietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_inmuebles_OficinaId",
                table: "Inmuebles",
                newName: "IX_Inmuebles_OficinaId");

            migrationBuilder.RenameIndex(
                name: "IX_inmuebles_AgenteId",
                table: "Inmuebles",
                newName: "IX_Inmuebles_AgenteId");

            migrationBuilder.RenameIndex(
                name: "IX_estancias_InmuebleId",
                table: "Estancias",
                newName: "IX_Estancias_InmuebleId");

            migrationBuilder.RenameIndex(
                name: "IX_clientes_UsuarioId",
                table: "Clientes",
                newName: "IX_Clientes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_caracteristicaInmuebles_InmuebleId",
                table: "CaracteristicaInmuebles",
                newName: "IX_CaracteristicaInmuebles_InmuebleId");

            migrationBuilder.RenameIndex(
                name: "IX_agentes_UsuarioId",
                table: "Agentes",
                newName: "IX_Agentes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_agentes_OficinaId",
                table: "Agentes",
                newName: "IX_Agentes_OficinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Zonas",
                table: "Zonas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Visitas",
                table: "Visitas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Propietarios",
                table: "Propietarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Oficinas",
                table: "Oficinas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Ofertas",
                table: "Ofertas",
                column: "InmuebleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Inmuebles",
                table: "Inmuebles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Estancias",
                table: "Estancias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CaracteristicaInmuebles",
                table: "CaracteristicaInmuebles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Agentes",
                table: "Agentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Oficinas_OficinaId",
                table: "Agentes",
                column: "OficinaId",
                principalTable: "Oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Agentes_Usuarios_UsuarioId",
                table: "Agentes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CaracteristicaInmuebles_Inmuebles_InmuebleId",
                table: "CaracteristicaInmuebles",
                column: "InmuebleId",
                principalTable: "Inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Clientes_Usuarios_UsuarioId",
                table: "Clientes",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Estancias_Inmuebles_InmuebleId",
                table: "Estancias",
                column: "InmuebleId",
                principalTable: "Inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inmuebles_Agentes_AgenteId",
                table: "Inmuebles",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Inmuebles_Oficinas_OficinaId",
                table: "Inmuebles",
                column: "OficinaId",
                principalTable: "Oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inmuebles_Propietarios_PropietarioId",
                table: "Inmuebles",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Inmuebles_Zonas_ZonaId",
                table: "Inmuebles",
                column: "ZonaId",
                principalTable: "Zonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Ofertas_Inmuebles_InmuebleId",
                table: "Ofertas",
                column: "InmuebleId",
                principalTable: "Inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Propietarios_Usuarios_UsuarioId",
                table: "Propietarios",
                column: "UsuarioId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Agentes_AgenteId",
                table: "Visitas",
                column: "AgenteId",
                principalTable: "Agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Clientes_ClienteId",
                table: "Visitas",
                column: "ClienteId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Inmuebles_InmuebleId",
                table: "Visitas",
                column: "InmuebleId",
                principalTable: "Inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Oficinas_OficinaId",
                table: "Visitas",
                column: "OficinaId",
                principalTable: "Oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Visitas_Propietarios_PropietarioId",
                table: "Visitas",
                column: "PropietarioId",
                principalTable: "Propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Zonas_Oficinas_OficinaId",
                table: "Zonas",
                column: "OficinaId",
                principalTable: "Oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Oficinas_OficinaId",
                table: "Agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_Agentes_Usuarios_UsuarioId",
                table: "Agentes");

            migrationBuilder.DropForeignKey(
                name: "FK_CaracteristicaInmuebles_Inmuebles_InmuebleId",
                table: "CaracteristicaInmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_Clientes_Usuarios_UsuarioId",
                table: "Clientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Estancias_Inmuebles_InmuebleId",
                table: "Estancias");

            migrationBuilder.DropForeignKey(
                name: "FK_Inmuebles_Agentes_AgenteId",
                table: "Inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_Inmuebles_Oficinas_OficinaId",
                table: "Inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_Inmuebles_Propietarios_PropietarioId",
                table: "Inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_Inmuebles_Zonas_ZonaId",
                table: "Inmuebles");

            migrationBuilder.DropForeignKey(
                name: "FK_Ofertas_Inmuebles_InmuebleId",
                table: "Ofertas");

            migrationBuilder.DropForeignKey(
                name: "FK_Propietarios_Usuarios_UsuarioId",
                table: "Propietarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_Agentes_AgenteId",
                table: "Visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_Clientes_ClienteId",
                table: "Visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_Inmuebles_InmuebleId",
                table: "Visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_Oficinas_OficinaId",
                table: "Visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Visitas_Propietarios_PropietarioId",
                table: "Visitas");

            migrationBuilder.DropForeignKey(
                name: "FK_Zonas_Oficinas_OficinaId",
                table: "Zonas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Zonas",
                table: "Zonas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Visitas",
                table: "Visitas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Usuarios",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Propietarios",
                table: "Propietarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Oficinas",
                table: "Oficinas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Ofertas",
                table: "Ofertas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Inmuebles",
                table: "Inmuebles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Estancias",
                table: "Estancias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CaracteristicaInmuebles",
                table: "CaracteristicaInmuebles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Agentes",
                table: "Agentes");

            migrationBuilder.RenameTable(
                name: "Zonas",
                newName: "zonas");

            migrationBuilder.RenameTable(
                name: "Visitas",
                newName: "visitas");

            migrationBuilder.RenameTable(
                name: "Usuarios",
                newName: "usuarios");

            migrationBuilder.RenameTable(
                name: "Propietarios",
                newName: "propietarios");

            migrationBuilder.RenameTable(
                name: "Oficinas",
                newName: "oficinas");

            migrationBuilder.RenameTable(
                name: "Ofertas",
                newName: "ofertas");

            migrationBuilder.RenameTable(
                name: "Inmuebles",
                newName: "inmuebles");

            migrationBuilder.RenameTable(
                name: "Estancias",
                newName: "estancias");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "clientes");

            migrationBuilder.RenameTable(
                name: "CaracteristicaInmuebles",
                newName: "caracteristicaInmuebles");

            migrationBuilder.RenameTable(
                name: "Agentes",
                newName: "agentes");

            migrationBuilder.RenameIndex(
                name: "IX_Zonas_OficinaId",
                table: "zonas",
                newName: "IX_zonas_OficinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_PropietarioId",
                table: "visitas",
                newName: "IX_visitas_PropietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_OficinaId",
                table: "visitas",
                newName: "IX_visitas_OficinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_InmuebleId",
                table: "visitas",
                newName: "IX_visitas_InmuebleId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_ClienteId",
                table: "visitas",
                newName: "IX_visitas_ClienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Visitas_AgenteId",
                table: "visitas",
                newName: "IX_visitas_AgenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Propietarios_UsuarioId",
                table: "propietarios",
                newName: "IX_propietarios_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Inmuebles_ZonaId",
                table: "inmuebles",
                newName: "IX_inmuebles_ZonaId");

            migrationBuilder.RenameIndex(
                name: "IX_Inmuebles_PropietarioId",
                table: "inmuebles",
                newName: "IX_inmuebles_PropietarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Inmuebles_OficinaId",
                table: "inmuebles",
                newName: "IX_inmuebles_OficinaId");

            migrationBuilder.RenameIndex(
                name: "IX_Inmuebles_AgenteId",
                table: "inmuebles",
                newName: "IX_inmuebles_AgenteId");

            migrationBuilder.RenameIndex(
                name: "IX_Estancias_InmuebleId",
                table: "estancias",
                newName: "IX_estancias_InmuebleId");

            migrationBuilder.RenameIndex(
                name: "IX_Clientes_UsuarioId",
                table: "clientes",
                newName: "IX_clientes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_CaracteristicaInmuebles_InmuebleId",
                table: "caracteristicaInmuebles",
                newName: "IX_caracteristicaInmuebles_InmuebleId");

            migrationBuilder.RenameIndex(
                name: "IX_Agentes_UsuarioId",
                table: "agentes",
                newName: "IX_agentes_UsuarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Agentes_OficinaId",
                table: "agentes",
                newName: "IX_agentes_OficinaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_zonas",
                table: "zonas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_visitas",
                table: "visitas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_usuarios",
                table: "usuarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_propietarios",
                table: "propietarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_oficinas",
                table: "oficinas",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ofertas",
                table: "ofertas",
                column: "InmuebleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_inmuebles",
                table: "inmuebles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_estancias",
                table: "estancias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_clientes",
                table: "clientes",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_caracteristicaInmuebles",
                table: "caracteristicaInmuebles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_agentes",
                table: "agentes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_agentes_oficinas_OficinaId",
                table: "agentes",
                column: "OficinaId",
                principalTable: "oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_agentes_usuarios_UsuarioId",
                table: "agentes",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_caracteristicaInmuebles_inmuebles_InmuebleId",
                table: "caracteristicaInmuebles",
                column: "InmuebleId",
                principalTable: "inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_clientes_usuarios_UsuarioId",
                table: "clientes",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_estancias_inmuebles_InmuebleId",
                table: "estancias",
                column: "InmuebleId",
                principalTable: "inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inmuebles_agentes_AgenteId",
                table: "inmuebles",
                column: "AgenteId",
                principalTable: "agentes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_inmuebles_oficinas_OficinaId",
                table: "inmuebles",
                column: "OficinaId",
                principalTable: "oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inmuebles_propietarios_PropietarioId",
                table: "inmuebles",
                column: "PropietarioId",
                principalTable: "propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_inmuebles_zonas_ZonaId",
                table: "inmuebles",
                column: "ZonaId",
                principalTable: "zonas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ofertas_inmuebles_InmuebleId",
                table: "ofertas",
                column: "InmuebleId",
                principalTable: "inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_propietarios_usuarios_UsuarioId",
                table: "propietarios",
                column: "UsuarioId",
                principalTable: "usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_agentes_AgenteId",
                table: "visitas",
                column: "AgenteId",
                principalTable: "agentes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_clientes_ClienteId",
                table: "visitas",
                column: "ClienteId",
                principalTable: "clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_inmuebles_InmuebleId",
                table: "visitas",
                column: "InmuebleId",
                principalTable: "inmuebles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_oficinas_OficinaId",
                table: "visitas",
                column: "OficinaId",
                principalTable: "oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_visitas_propietarios_PropietarioId",
                table: "visitas",
                column: "PropietarioId",
                principalTable: "propietarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_zonas_oficinas_OficinaId",
                table: "zonas",
                column: "OficinaId",
                principalTable: "oficinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
