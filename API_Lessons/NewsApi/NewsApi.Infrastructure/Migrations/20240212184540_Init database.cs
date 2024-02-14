using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initdatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "News",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false),
                    CategoryId = table.Column<int>(type: "int", nullable: false),
                    TotalVisits = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_News", x => x.Id);
                    table.ForeignKey(
                        name: "FK_News_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_News_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Surname = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Username = table.Column<string>(type: "nvarchar(128)", maxLength: 128, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Phone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                    table.ForeignKey(
                        name: "FK_User_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Age", "Name", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, 37, "Tim", "Bontemps", "TB11" },
                    { 2, 39, "Bill", "Barnwell", "Bill39" },
                    { 3, 42, "Laura", "Sanders", "Lau22" },
                    { 4, 53, "Bruce", "Bower", "Bower33" },
                    { 5, 32, "Aadel", "Chaudhuri", "Aadel101" },
                    { 6, 44, "Katharine", "Lang", "Lang1000" },
                    { 7, 29, "Bruce", "William", "Brll33" }
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "Category about sport", "Sport" },
                    { 2, "Category about science", "Science" },
                    { 3, "Category about medicine", "Medicine" }
                });

            migrationBuilder.InsertData(
                table: "Role",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Editor" },
                    { 3, "Writer" }
                });

            migrationBuilder.InsertData(
                table: "News",
                columns: new[] { "Id", "AuthorId", "CategoryId", "Description", "Image", "Text", "Title", "TotalVisits" },
                values: new object[,]
                {
                    { 1, 1, 1, "Our insiders makes the moves they think NBA GMs should be making ahead of Feb. 8, including a big deal to shake up the Lakers.", "", "The 2024 NBA trade deadline is fast approaching, and while some teams have already been active, there are still plenty of others who need to make moves.\r\n\r\nWith that in mind, we asked our experts to come up with trades they want to see at the Feb. 8 deadline, whether it's a smaller deal to help a contender fill a hole, or a bigger move that could shake up the entire league.\r\n\r\nThey worked their magic in the ESPN Trade Machine and came up with six deals they want to see over the next 10 days -- and yes, the Los Angeles Lakers are involved.", "Six big NBA trades we want to see before the deadline", 0 },
                    { 2, 2, 1, "The Lions surrendered a 17-point second-half lead, while the vaunted Ravens scored just 10 points. Here's how the 49ers and Chiefs won.", "", "Chiefs-Ravens was a slow burn, as Kansas City got out to an early lead and held onto it throughout. Baltimore got closer and closer to competing as the game went along, but mistakes at the wrong time shut down its chances. One year after he was the leading receiver for the Chiefs in the AFC Championship Game, Marquez Valdes-Scantling hauled in a 32-yard bomb on third-and-9 to break the Ravens and send the Chiefs back to the Super Bowl.\r\n\r\nLions-49ers was a slugfest, and could also be accurately described as a rope-a-dope. Detroit dominated early and jumped out to a 17-point lead, only for San Francisco to claw its way back in the second half. In a four-minute window, the 49ers pounced. They stopped the Lions on fourth down, scored a touchdown, forced a fumble and scored again to tie the game. While Detroit threatened later in the game, another failed fourth-down try put San Francisco in the driver's seat, sealing a Super Bowl LIV rematch against the Chiefs.", "Barnwell: The truth behind Detroit's disastrous second half and Baltimore's botched Super Bowl chance", 0 },
                    { 3, 3, 2, "Alzheimer’s isn’t contagious. But contaminated growth hormone injections caused early-onset Alzheimer’s in some recipients, a new study suggests.", "", "Under extremely rare circumstances, it appears that Alzheimer’s disease can be transmitted between people. Five people who received contaminated injections of a growth hormone as children went on to develop Alzheimer’s unusually early, researchers report January 29 in Nature Medicine.", "Under very rare conditions, Alzheimer’s disease may be transmitted", 0 },
                    { 4, 4, 2, "New climate data for ancient Italy point to temperature and rainfall influences on past infectious disease outbreaks.", "", "For those who enjoy pondering the Roman Empire’s rise and fall — you know who you are — consider the close link between ancient climate change and infectious disease outbreaks. Periods of increasingly cooler temperatures and rainfall declines coincided with three pandemics that struck the Roman Empire, historian Kyle Harper and colleagues report January 26 in Science Advances. Reasons for strong associations between cold, dry phases and those disease outbreaks are poorly understood. ", "Cold, dry snaps accompanied three plagues that struck the Roman Empire", 0 },
                    { 5, 5, 3, "A lack of funding, mentorship, and compensation for clinician-researchers could threaten America's standing as the world leader in biomedicine.", "", "Recent reporting has shown that the number of physician-scientists — doctors who both practice medicine and perform scientific research — in the United States is dropping rapidly. That's a problem, because physician-scientists are uniquely equipped to make scientific discoveries in the laboratory and translate them to the clinic. Indeed, many of the discoveries that have transformed medicine for the better were made by physician-scientists. For example, Jonas Salk developed the polio vaccine, Timothy Ley sequenced the first cancer genome, and Anthony Fauci coordinated public health responses to both the HIV/AIDS and COVID-19 pandemics. Indicative of their sheer impact, at least a third and as many as half of all Nobel Prizes and Lasker Awards in physiology/medicine have gone to physician-scientists.", "The Emerging Physician-Scientist Crisis in America", 0 },
                    { 6, 6, 3, "There is some evidence — both scientific and anecdotal — that some diets may help with the management of long COVID symptoms. Which...", "", "For many people, particularly following vaccination, infection with SARS-CoV-2, the virus that causes COVID-19, resolves within a few days. But for others, it results in long COVID, a variety of often debilitating symptoms that persist for weeks, months or even years. Why this happens in some is unclear, and there are currently no effective treatments. Some experts believe diet could be key to symptom management. What is the evidence for this?", "Could some diets help manage long COVID?", 0 }
                });

            migrationBuilder.InsertData(
                table: "User",
                columns: new[] { "Id", "Age", "Email", "Name", "Phone", "RoleId", "Surname", "Username" },
                values: new object[,]
                {
                    { 1, 18, "bbjohn@mail.com", "Bill", "+111111111", 3, "Johnson", "Bjohn" },
                    { 2, 26, "steph111@gmail.com", "Steph", "+222222222", 2, "Jube", "Steph111" },
                    { 3, 25, "tracy@gmail.com", "Tracy", "+333333333", 1, "Minaji", "tracyminaji" },
                    { 4, 31, "guspeep@mail.com", "Gus", "+444444444", 3, "Peep", "peeep" },
                    { 5, 22, "mfosh@mail.com", "Max", "+555555555", 2, "Fosh", "mfosh" },
                    { 6, 21, "mbosh@mail.com", "Max", "+666666666", 1, "Bosh", "mbosh" }
                });

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
                name: "IX_Authors_Username",
                table: "Authors",
                column: "Username",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_News_AuthorId",
                table: "News",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_News_CategoryId",
                table: "News",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Statistics_NewsId",
                table: "Statistics",
                column: "NewsId");

            migrationBuilder.CreateIndex(
                name: "IX_User_RoleId",
                table: "User",
                column: "RoleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Statistics");

            migrationBuilder.DropTable(
                name: "User");

            migrationBuilder.DropTable(
                name: "News");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
