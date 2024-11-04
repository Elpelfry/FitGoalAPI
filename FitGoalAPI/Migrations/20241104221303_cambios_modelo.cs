using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitGoalAPI.Migrations
{
    /// <inheritdoc />
    public partial class cambios_modelo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "DuracionTotal",
                table: "Entrenamientos",
                type: "int",
                nullable: false,
                oldClrType: typeof(TimeSpan),
                oldType: "time(6)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<TimeSpan>(
                name: "DuracionTotal",
                table: "Entrenamientos",
                type: "time(6)",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");
        }
    }
}
