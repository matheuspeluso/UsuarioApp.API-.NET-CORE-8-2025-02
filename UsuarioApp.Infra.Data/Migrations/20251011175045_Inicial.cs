using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UsuarioApp.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PERFIL",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PERFIL", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "USUARIO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    SENHA = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    PERFIL_ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USUARIO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_USUARIO_PERFIL_PERFIL_ID",
                        column: x => x.PERFIL_ID,
                        principalTable: "PERFIL",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PERFIL_NOME",
                table: "PERFIL",
                column: "NOME",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_PERFIL_ID",
                table: "USUARIO",
                column: "PERFIL_ID");

            // Inserindo perfis iniciais
            var adminId = Guid.NewGuid();
            var usuarioId = Guid.NewGuid();

            migrationBuilder.InsertData(
                table: "PERFIL",
                columns: new[] { "ID", "NOME" },
                values: new object[,]
                {
                    { adminId, "Administrador" },
                    { usuarioId, "Usuario" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Remover perfis inseridos
            migrationBuilder.Sql("DELETE FROM PERFIL WHERE NOME IN ('Administrador', 'Usuario');");

            migrationBuilder.DropTable(
                name: "USUARIO");

            migrationBuilder.DropTable(
                name: "PERFIL");
        }
    }
}
