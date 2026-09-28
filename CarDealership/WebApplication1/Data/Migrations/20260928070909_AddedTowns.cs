using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WebApplication1.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddedTowns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TownId",
                table: "ApplicationUsers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Town",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Town", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 1,
                column: "TownId",
                value: 1);

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 2,
                column: "TownId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "ApplicationUsers",
                keyColumn: "Id",
                keyValue: 3,
                column: "TownId",
                value: 3);

            migrationBuilder.InsertData(
                table: "Town",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Sofia" },
                    { 2, "Plovdiv" },
                    { 3, "Varna" },
                    { 4, "Burgas" },
                    { 5, "Ruse" },
                    { 6, "Stara Zagora" },
                    { 7, "Pleven" },
                    { 8, "Sliven" },
                    { 9, "Dobrich" },
                    { 10, "Shumen" },
                    { 11, "Pernik" },
                    { 12, "Haskovo" },
                    { 13, "Yambol" },
                    { 14, "Pazardzhik" },
                    { 15, "Blagoevgrad" },
                    { 16, "Veliko Tarnovo" },
                    { 17, "Vratsa" },
                    { 18, "Gabrovo" },
                    { 19, "Vidin" },
                    { 20, "Montana" },
                    { 21, "Kyustendil" },
                    { 22, "Kardzhali" },
                    { 23, "Targovishte" },
                    { 24, "Lovech" },
                    { 25, "Silistra" },
                    { 26, "Razgrad" },
                    { 27, "Smolyan" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUsers_TownId",
                table: "ApplicationUsers",
                column: "TownId");

            migrationBuilder.AddForeignKey(
                name: "FK_ApplicationUsers_Town_TownId",
                table: "ApplicationUsers",
                column: "TownId",
                principalTable: "Town",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ApplicationUsers_Town_TownId",
                table: "ApplicationUsers");

            migrationBuilder.DropTable(
                name: "Town");

            migrationBuilder.DropIndex(
                name: "IX_ApplicationUsers_TownId",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "TownId",
                table: "ApplicationUsers");
        }
    }
}
