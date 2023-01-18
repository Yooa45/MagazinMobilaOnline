using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinMobilaOnline.Migrations
{
    public partial class Produs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comanda",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataComanda = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClientID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comanda", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Comanda_Client_ClientID",
                        column: x => x.ClientID,
                        principalTable: "Client",
                        principalColumn: "ClientID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Pret = table.Column<int>(type: "int", nullable: false),
                    Stoc = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ComandaProdus",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComandaID = table.Column<int>(type: "int", nullable: false),
                    ProdusID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComandaProdus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ComandaProdus_Comanda_ComandaID",
                        column: x => x.ComandaID,
                        principalTable: "Comanda",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComandaProdus_Produs_ProdusID",
                        column: x => x.ProdusID,
                        principalTable: "Produs",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Comanda_ClientID",
                table: "Comanda",
                column: "ClientID");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaProdus_ComandaID",
                table: "ComandaProdus",
                column: "ComandaID");

            migrationBuilder.CreateIndex(
                name: "IX_ComandaProdus_ProdusID",
                table: "ComandaProdus",
                column: "ProdusID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComandaProdus");

            migrationBuilder.DropTable(
                name: "Comanda");

            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}
