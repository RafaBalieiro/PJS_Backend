using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PJS.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class corrigindoRelacionamentoEventosRotina : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Rotinas_RotinaEntityId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_RotinaEntityId",
                table: "Eventos");

            migrationBuilder.DropColumn(
                name: "RotinaEntityId",
                table: "Eventos");

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_RotinaId",
                table: "Eventos",
                column: "RotinaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Rotinas_RotinaId",
                table: "Eventos",
                column: "RotinaId",
                principalTable: "Rotinas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Eventos_Rotinas_RotinaId",
                table: "Eventos");

            migrationBuilder.DropIndex(
                name: "IX_Eventos_RotinaId",
                table: "Eventos");

            migrationBuilder.AddColumn<Guid>(
                name: "RotinaEntityId",
                table: "Eventos",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Eventos_RotinaEntityId",
                table: "Eventos",
                column: "RotinaEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Eventos_Rotinas_RotinaEntityId",
                table: "Eventos",
                column: "RotinaEntityId",
                principalTable: "Rotinas",
                principalColumn: "Id");
        }
    }
}
