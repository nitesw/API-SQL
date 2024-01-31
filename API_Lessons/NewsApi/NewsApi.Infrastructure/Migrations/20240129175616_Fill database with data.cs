using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace NewsApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Filldatabasewithdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                table: "News",
                columns: new[] { "Id", "Author", "CategoryId", "Description", "Text", "Title" },
                values: new object[,]
                {
                    { 1, "Tim Bontemps", 1, "Our insiders makes the moves they think NBA GMs should be making ahead of Feb. 8, including a big deal to shake up the Lakers.", "The 2024 NBA trade deadline is fast approaching, and while some teams have already been active, there are still plenty of others who need to make moves.\r\n\r\nWith that in mind, we asked our experts to come up with trades they want to see at the Feb. 8 deadline, whether it's a smaller deal to help a contender fill a hole, or a bigger move that could shake up the entire league.\r\n\r\nThey worked their magic in the ESPN Trade Machine and came up with six deals they want to see over the next 10 days -- and yes, the Los Angeles Lakers are involved.", "Six big NBA trades we want to see before the deadline" },
                    { 2, "Bill Barnwell", 1, "The Lions surrendered a 17-point second-half lead, while the vaunted Ravens scored just 10 points. Here's how the 49ers and Chiefs won.", "Chiefs-Ravens was a slow burn, as Kansas City got out to an early lead and held onto it throughout. Baltimore got closer and closer to competing as the game went along, but mistakes at the wrong time shut down its chances. One year after he was the leading receiver for the Chiefs in the AFC Championship Game, Marquez Valdes-Scantling hauled in a 32-yard bomb on third-and-9 to break the Ravens and send the Chiefs back to the Super Bowl.\r\n\r\nLions-49ers was a slugfest, and could also be accurately described as a rope-a-dope. Detroit dominated early and jumped out to a 17-point lead, only for San Francisco to claw its way back in the second half. In a four-minute window, the 49ers pounced. They stopped the Lions on fourth down, scored a touchdown, forced a fumble and scored again to tie the game. While Detroit threatened later in the game, another failed fourth-down try put San Francisco in the driver's seat, sealing a Super Bowl LIV rematch against the Chiefs.", "Barnwell: The truth behind Detroit's disastrous second half and Baltimore's botched Super Bowl chance" },
                    { 3, "Laura Sanders", 2, "Alzheimer’s isn’t contagious. But contaminated growth hormone injections caused early-onset Alzheimer’s in some recipients, a new study suggests.", "Under extremely rare circumstances, it appears that Alzheimer’s disease can be transmitted between people. Five people who received contaminated injections of a growth hormone as children went on to develop Alzheimer’s unusually early, researchers report January 29 in Nature Medicine.", "Under very rare conditions, Alzheimer’s disease may be transmitted" },
                    { 4, "Bruce Bower", 2, "New climate data for ancient Italy point to temperature and rainfall influences on past infectious disease outbreaks.", "For those who enjoy pondering the Roman Empire’s rise and fall — you know who you are — consider the close link between ancient climate change and infectious disease outbreaks. Periods of increasingly cooler temperatures and rainfall declines coincided with three pandemics that struck the Roman Empire, historian Kyle Harper and colleagues report January 26 in Science Advances. Reasons for strong associations between cold, dry phases and those disease outbreaks are poorly understood. ", "Cold, dry snaps accompanied three plagues that struck the Roman Empire" },
                    { 5, "Aadel Chaudhuri", 3, "A lack of funding, mentorship, and compensation for clinician-researchers could threaten America's standing as the world leader in biomedicine.", "Recent reporting has shown that the number of physician-scientists — doctors who both practice medicine and perform scientific research — in the United States is dropping rapidly. That's a problem, because physician-scientists are uniquely equipped to make scientific discoveries in the laboratory and translate them to the clinic. Indeed, many of the discoveries that have transformed medicine for the better were made by physician-scientists. For example, Jonas Salk developed the polio vaccine, Timothy Ley sequenced the first cancer genome, and Anthony Fauci coordinated public health responses to both the HIV/AIDS and COVID-19 pandemics. Indicative of their sheer impact, at least a third and as many as half of all Nobel Prizes and Lasker Awards in physiology/medicine have gone to physician-scientists.", "The Emerging Physician-Scientist Crisis in America" },
                    { 6, "Katharine Lang", 3, "There is some evidence — both scientific and anecdotal — that some diets may help with the management of long COVID symptoms. Which...", "For many people, particularly following vaccination, infection with SARS-CoV-2, the virus that causes COVID-19, resolves within a few days. But for others, it results in long COVID, a variety of often debilitating symptoms that persist for weeks, months or even years. Why this happens in some is unclear, and there are currently no effective treatments. Some experts believe diet could be key to symptom management. What is the evidence for this?", "Could some diets help manage long COVID?" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "News",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
