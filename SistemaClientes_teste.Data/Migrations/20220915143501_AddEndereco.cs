using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SistemaClientes_teste.Data.Migrations
{
    public partial class AddEndereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ENDERECO",
                columns: table => new
                {
                    IDENDERECO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IDCLIENTE = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NUMERO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    COMPLEMENTO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BAIRRO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CIDADE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ESTADO = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CEP = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ENDERECO", x => x.IDENDERECO);
                    table.ForeignKey(
                        name: "FK_ENDERECO_CLIENTE_IDCLIENTE",
                        column: x => x.IDCLIENTE,
                        principalTable: "CLIENTE",
                        principalColumn: "IDCLIENTE",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ENDERECO_IDCLIENTE",
                table: "ENDERECO",
                column: "IDCLIENTE");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ENDERECO");
        }
    }
}
