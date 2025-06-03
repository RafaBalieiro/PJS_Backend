using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PJS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InserindoTabelaNiveisConquistas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "NivelId",
                table: "Perfis",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Conquistas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    Descricao = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    XpBonus = table.Column<int>(type: "integer", nullable: false),
                    Logo = table.Column<byte[]>(type: "bytea", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conquistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Niveis",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nivel = table.Column<int>(type: "integer", nullable: false),
                    QuantidadeXp = table.Column<int>(type: "integer", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Niveis", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ConquistasPerfisAssoc",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ConquistaId = table.Column<Guid>(type: "uuid", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConquistasPerfisAssoc", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConquistasPerfisAssoc_Conquistas_ConquistaId",
                        column: x => x.ConquistaId,
                        principalTable: "Conquistas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConquistasPerfisAssoc_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Perfis_NivelId",
                table: "Perfis",
                column: "NivelId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistasPerfisAssoc_ConquistaId",
                table: "ConquistasPerfisAssoc",
                column: "ConquistaId");

            migrationBuilder.CreateIndex(
                name: "IX_ConquistasPerfisAssoc_PerfilId",
                table: "ConquistasPerfisAssoc",
                column: "PerfilId");

            migrationBuilder.AddForeignKey(
                name: "FK_Perfis_Niveis_NivelId",
                table: "Perfis",
                column: "NivelId",
                principalTable: "Niveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perfis_Niveis_NivelId",
                table: "Perfis");

            migrationBuilder.DropTable(
                name: "ConquistasPerfisAssoc");

            migrationBuilder.DropTable(
                name: "Niveis");

            migrationBuilder.DropTable(
                name: "Conquistas");

            migrationBuilder.DropIndex(
                name: "IX_Perfis_NivelId",
                table: "Perfis");

            migrationBuilder.DropColumn(
                name: "NivelId",
                table: "Perfis");
        }
    }
}
