using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MagazinMobilaOnline.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    ClientID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientNume = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientAdresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientNrTelefon = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.ClientID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Client");
        }
    }
}
