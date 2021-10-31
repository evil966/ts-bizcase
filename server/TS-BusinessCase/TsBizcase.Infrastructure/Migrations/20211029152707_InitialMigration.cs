using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TsBizcase.Infrastructure.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tenders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReferenceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReleaseDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ClosingDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tenders_AppUsers_CreatorId",
                        column: x => x.CreatorId,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Email", "HashedPassword", "Name" },
                values: new object[] { 1, "anita.herrera@houseoffoo.com", "AQAAAAEAACcQAAAAEG8W4Xu0BxhbTMb7qOpixB47PGMKTqS66OzGQrihsvXFLXTYS4I0KDJPR/TIEIvx1w==", "Anita Herrera" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Email", "HashedPassword", "Name" },
                values: new object[] { 2, "brooklyn.hamilton@hamiltonbrook.com", "AQAAAAEAACcQAAAAELWpKaj6KMCYfN23Y0yY+g5fDxu07aeAf67fqu2frjkDF/rs4GNTl3JT5sD7ouDRzA==", "Brooklyn Hamilton" });

            migrationBuilder.InsertData(
                table: "AppUsers",
                columns: new[] { "Id", "Email", "HashedPassword", "Name" },
                values: new object[] { 3, "liam.davidson@lidavman.com", "AQAAAAEAACcQAAAAEKvsxNN3F2vWp0NrsjGyqEyJREvoydZA+U4mR5WwtNJAn9mD5HgngFov0AsMzFc1/g==", "Liam Davidson" });

            migrationBuilder.CreateIndex(
                name: "IX_AppUser_Email",
                table: "AppUsers",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Tenders_CreatorId",
                table: "Tenders",
                column: "CreatorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Tenders");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
