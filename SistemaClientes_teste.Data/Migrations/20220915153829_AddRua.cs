using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaClientes_teste.Data.Migrations
{
    public partial class AddRua : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RUA",
                table: "ENDERECO",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RUA",
                table: "ENDERECO");
        }
    }
}
