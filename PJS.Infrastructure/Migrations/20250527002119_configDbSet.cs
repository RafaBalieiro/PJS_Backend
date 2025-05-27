using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PJS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class configDbSet : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rotinas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataInicial = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "timestamp with time zone", nullable: true),
                    Periodicidade = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rotinas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Eventos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    DataExecucao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataFinalizacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    RotinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    RotinaEntityId = table.Column<Guid>(type: "uuid", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Eventos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Eventos_Rotinas_RotinaEntityId",
                        column: x => x.RotinaEntityId,
                        principalTable: "Rotinas",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tarefas",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Nome = table.Column<string>(type: "character varying(150)", maxLength: 150, nullable: false),
                    CategoriaTarefa = table.Column<int>(type: "integer", nullable: false),
                    NivelConhecimento = table.Column<int>(type: "integer", nullable: false),
                    Status = table.Column<int>(type: "integer", nullable: false),
                    Dificuldade = table.Column<int>(type: "integer", nullable: false),
                    TempoEstimado = table.Column<TimeSpan>(type: "interval", nullable: false),
                    PerfilId = table.Column<Guid>(type: "uuid", nullable: false),
                    RotinaId = table.Column<Guid>(type: "uuid", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    Ativo = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tarefas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tarefas_Perfis_PerfilId",
                        column: x => x.PerfilId,
                        principalTable: "Perfis",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Tarefas_Rotinas_RotinaId",
                        column: x => x.RotinaId,
                        principalTable: "Rotinas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_RotinaEntityId",
                table: "Eventos",
                column: "RotinaEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_PerfilId",
                table: "Tarefas",
                column: "PerfilId");

            migrationBuilder.CreateIndex(
                name: "IX_Tarefas_RotinaId",
                table: "Tarefas",
                column: "RotinaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Eventos");

            migrationBuilder.DropTable(
                name: "Tarefas");

            migrationBuilder.DropTable(
                name: "Rotinas");
        }
    }
}
