using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Addstatisticstableandseededit : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalVisits",
                table: "News",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Statistics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VisitorIp = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    VisitorBrowser = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VisitorCountry = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NewsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Statistics", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Statistics_News_NewsId",
                        column: x => x.NewsId,
                        principalTable: "News",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1,
                column: "TotalVisits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2,
                column: "TotalVisits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3,
                column: "TotalVisits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4,
                column: "TotalVisits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5,
                column: "TotalVisits",
                value: 0);

            migrationBuilder.UpdateData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6,
                column: "TotalVisits",
                value: 0);

            migrationBuilder.InsertData(
                table: "Statistics",
                columns: new[] { "Id", "NewsId", "VisitorBrowser", "VisitorCountry", "VisitorIp" },
                values: new object[,]
                {
                    { 1, 1, "Chrome", "US", "123.456.789.0" },
                    { 2, 1, "Opera", "US", "133.446.799.1" },
                    { 3, 2, "Mozilla Firefox", "Canada", "333.126.439.5" },
                    { 4, 2, "Chrome", "France", "232.116.654.2" },
                    { 5, 3, "Chrome", "Ukraine", "196.226.743.0" },
                    { 6, 5, "Opera", "US", "133.446.799.1" },
                    { 7, 4, "Mozilla Firefox", "Canada", "333.126.439.5" },
                    { 8, 6, "Chrome", "France", "232.116.654.2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_NewsId",
                table: "Statistics",
                column: "NewsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropColumn(
                name: "TotalVisits",
                table: "News");
        }
    }
}
