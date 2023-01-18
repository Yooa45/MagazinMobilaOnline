using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinMobilaOnline.Migrations
{
    public partial class Oferta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Oferta",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Reducere = table.Column<int>(type: "int", nullable: false),
                    DataExpirare = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProdusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Oferta", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Oferta_Produs_ProdusID",
                        column: x => x.ProdusID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Oferta_ProdusID",
                table: "Oferta",
                column: "ProdusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Oferta");
        }
    }
}
