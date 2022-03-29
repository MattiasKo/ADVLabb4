using Microsoft.EntityFrameworkCore.Migrations;

namespace IntresseKlubbenAPI.Migrations
{
    public partial class MigIntresseklubben : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Interests",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    PersId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interests", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Linkss",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    strLink = table.Column<string>(nullable: true),
                    PersID = table.Column<int>(nullable: false),
                    InterestID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Linkss", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Personers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Phone = table.Column<int>(nullable: false),
                    Email = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Personers", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Interests",
                columns: new[] { "ID", "Description", "PersId", "Title" },
                values: new object[,]
                {
                    { 1, "Fiska fiskar i havet.", 1, "Sportfiske" },
                    { 2, "Sparka bollar i mål.", 1, "Fotboll" },
                    { 3, "Lyfta skrot i gymmet.", 2, "Styrketräning" },
                    { 4, "Kolla på katter på youtube", 3, "Youtube" }
                });

            migrationBuilder.InsertData(
                table: "Linkss",
                columns: new[] { "ID", "InterestID", "PersID", "strLink" },
                values: new object[,]
                {
                    { 1, 2, 1, "www.nånting.com" },
                    { 2, 1, 1, "www.nånting2.com" },
                    { 3, 2, 2, "www.nånting3.com" },
                    { 4, 3, 3, "www.nånting4.com" }
                });

            migrationBuilder.InsertData(
                table: "Personers",
                columns: new[] { "Id", "Email", "Name", "Phone" },
                values: new object[,]
                {
                    { 1, "Anas@qlok.com", "Anas", 7055555 },
                    { 2, "Tobias@qlok.com", "Tobias", 7066666 },
                    { 3, "Riedar@qlok.com", "Riedar", 7077777 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interests");

            migrationBuilder.DropTable(
                name: "Linkss");

            migrationBuilder.DropTable(
                name: "Personers");
        }
    }
}
