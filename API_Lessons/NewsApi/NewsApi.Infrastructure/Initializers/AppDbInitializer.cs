using Microsoft.EntityFrameworkCore;
using NewsApi.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NewsApi.Infrastructure.Initializers
{
    internal static class AppDbInitializer
    {
        public static async Task SeedCategory(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category[]
                {
                    new Category() { Id = 1, Name = "Sport", Description = "Category about sport" },
                    new Category() { Id = 2, Name = "Science", Description = "Category about science" },
                    new Category() { Id = 3, Name = "Medicine", Description = "Category about medicine" }
                }
            );
        }
        public static async Task SeedNews(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<News>().HasData(new News[]
                {
                    new News() { Id = 1, Title = "Six big NBA trades we want to see before the deadline",
                        Description = "Our insiders makes the moves they think NBA GMs should be making ahead of Feb. " +
                        "8, including a big deal to shake up the Lakers.",
                        Text = "The 2024 NBA trade deadline is fast approaching, and while some teams have already been " +
                        "active, there are still plenty of others who need to make moves.\r\n\r\nWith that in mind, we asked our" +
                        " experts to come up with trades they want to see at the Feb. 8 deadline, whether it's a smaller deal" +
                        " to help a contender fill a hole, or a bigger move that could shake up the entire league." +
                        "\r\n\r\nThey worked their magic in the ESPN Trade Machine and came up with six deals they want" +
                        " to see over the next 10 days -- and yes, the Los Angeles Lakers are involved.",
                        AuthorId = 1, CategoryId = 1 },
                    new News() { Id = 2, Title = "Barnwell: The truth behind Detroit's disastrous second half and Baltimore's " +
                        "botched Super Bowl chance",
                        Description = "The Lions surrendered a 17-point second-half lead, while the " +
                        "vaunted Ravens scored just 10 points. Here's how the 49ers and Chiefs won.",
                        Text = "Chiefs-Ravens was a slow burn, as Kansas City got out to an early lead and held onto it " +
                        "throughout. Baltimore got closer and closer to competing as the game went along, but mistakes at " +
                        "the wrong time shut down its chances. One year after he was the leading receiver for the Chiefs " +
                        "in the AFC Championship Game, Marquez Valdes-Scantling hauled in a 32-yard bomb on third-and-9" +
                        " to break the Ravens and send the Chiefs back to the Super Bowl.\r\n\r\nLions-49ers was a slugfest," +
                        " and could also be accurately described as a rope-a-dope. Detroit dominated early and jumped" +
                        " out to a 17-point lead, only for San Francisco to claw its way back in the second half." +
                        " In a four-minute window, the 49ers pounced. They stopped the Lions on fourth down, scored a " +
                        "touchdown, forced a fumble and scored again to tie the game. While Detroit threatened later " +
                        "in the game, another failed fourth-down try put San Francisco in the driver's seat, " +
                        "sealing a Super Bowl LIV rematch against the Chiefs.",
                        AuthorId = 2, CategoryId = 1 },
                    new News() { Id = 3, Title = "Under very rare conditions, Alzheimer’s disease may be transmitted",
                        Description = "Alzheimer’s isn’t contagious. But contaminated growth hormone injections caused " +
                        "early-onset Alzheimer’s in some recipients, a new study suggests.",
                        Text = "Under extremely rare circumstances, it appears that Alzheimer’s " +
                        "disease can be transmitted between people. Five people who received " +
                        "contaminated injections of a growth hormone as children went on to develop " +
                        "Alzheimer’s unusually early, researchers report January 29 in Nature Medicine.",
                        AuthorId = 3, CategoryId = 2 },
                    new News() { Id = 4, Title = "Cold, dry snaps accompanied three plagues that struck the Roman Empire",
                        Description = "New climate data for ancient Italy point to temperature and " +
                        "rainfall influences on past infectious disease outbreaks.",
                        Text = "For those who enjoy pondering the Roman Empire’s rise and fall — you know who " +
                        "you are — consider the close link between ancient climate change and infectious disease outbreaks. " +
                        "Periods of increasingly cooler temperatures and rainfall declines coincided with three " +
                        "pandemics that struck the Roman Empire, historian Kyle Harper and colleagues report" +
                        " January 26 in Science Advances. " +
                        "Reasons for strong associations between cold, dry phases and those disease outbreaks " +
                        "are poorly understood. ",
                        AuthorId = 4, CategoryId = 2 },
                    new News() { Id = 5, Title = "The Emerging Physician-Scientist Crisis in America",
                        Description = "A lack of funding, mentorship, and compensation for clinician-researchers could " +
                        "threaten America's standing as the world leader in biomedicine.",
                        Text = "Recent reporting has shown that the number of physician-scientists — doctors who " +
                        "both practice medicine and perform scientific research — in the United States is dropping rapidly." +
                        " That's a problem, because physician-scientists are uniquely equipped to make scientific" +
                        " discoveries in the laboratory and translate them to the clinic. Indeed, many of the" +
                        " discoveries that have transformed medicine for the better were made by physician-scientists." +
                        " For example, Jonas Salk developed the polio vaccine, Timothy Ley sequenced the first cancer" +
                        " genome, and Anthony Fauci coordinated public health responses to both the HIV/AIDS and COVID-19" +
                        " pandemics. Indicative of their sheer impact, at least a third and as many as half of all" +
                        " Nobel Prizes and Lasker Awards in physiology/medicine have gone to physician-scientists.",
                        AuthorId = 5, CategoryId = 3 },
                    new News() { Id = 6, Title = "Could some diets help manage long COVID?",
                        Description = "There is some evidence — both scientific and anecdotal — " +
                        "that some diets may help with the management of long COVID symptoms. Which...",
                        Text = "For many people, particularly following vaccination, infection with " +
                        "SARS-CoV-2, the virus that causes COVID-19, resolves within a few days. " +
                        "But for others, it results in long COVID, a variety of often debilitating " +
                        "symptoms that persist for weeks, months or even years. Why this happens in some is unclear," +
                        " and there are currently no effective treatments. Some experts believe diet could be key " +
                        "to symptom management. What is the evidence for this?",
                        AuthorId = 6, CategoryId = 3 }
                }
            );
        }
        public static async Task SeedAuthor(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(new Author[]
                {
                    new Author() { Id = 1, Name = "Tim", Surname = "Bontemps", Age = 37 },
                    new Author() { Id = 2, Name = "Bill", Surname = "Barnwell", Age = 39 },
                    new Author() { Id = 3, Name = "Laura", Surname = "Sanders", Age = 42 },
                    new Author() { Id = 4, Name = "Bruce", Surname = "Bower", Age = 53 },
                    new Author() { Id = 5, Name = "Aadel", Surname = "Chaudhuri", Age = 32 },
                    new Author() { Id = 6, Name = "Katharine", Surname = "Lang", Age = 44 }
                }
            );
        }
        public static async Task SeedStatistics(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Statistics>().HasData(new Statistics[]
                {
                    new Statistics() { Id = 1, VisitorIp = "123.456.789.0", VisitorBrowser = "Chrome", 
                        VisitorCountry = "US", NewsId = 1 },
                    new Statistics() { Id = 2, VisitorIp = "133.446.799.1", VisitorBrowser = "Opera",
                        VisitorCountry = "US", NewsId = 1 },
                    new Statistics() { Id = 3, VisitorIp = "333.126.439.5", VisitorBrowser = "Mozilla Firefox",
                        VisitorCountry = "Canada", NewsId = 2 },
                    new Statistics() { Id = 4, VisitorIp = "232.116.654.2", VisitorBrowser = "Chrome",
                        VisitorCountry = "France", NewsId = 2 },
                    new Statistics() { Id = 5, VisitorIp = "196.226.743.0", VisitorBrowser = "Chrome",
                        VisitorCountry = "Ukraine", NewsId = 3 },
                    new Statistics() { Id = 6, VisitorIp = "133.446.799.1", VisitorBrowser = "Opera",
                        VisitorCountry = "US", NewsId = 5 },
                    new Statistics() { Id = 7, VisitorIp = "333.126.439.5", VisitorBrowser = "Mozilla Firefox",
                        VisitorCountry = "Canada", NewsId = 4 },
                    new Statistics() { Id = 8, VisitorIp = "232.116.654.2", VisitorBrowser = "Chrome",
                        VisitorCountry = "France", NewsId = 6 }
                }
            );
        }
        public static async Task SeedRole(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role[]
                {
                    new Role() { Id = 1, Name = "Admin" },
                    new Role() { Id = 2, Name = "Editor" },
                    new Role() { Id = 3, Name = "Writer" }
                }
            );
        }
        public static async Task SeedUser(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(new User[]
                {
                    new User() { Id = 1, Name = "Bill", Surname = "Johnson", Username = "Bjohn",
                        Age = 18, Email = "bbjohn@mail.com", Phone = "+111111111", RoleId = 3 },
                    new User() { Id = 2, Name = "Steph", Surname = "Jube", Username = "Steph111",
                        Age = 26, Email = "steph111@gmail.com", Phone = "+222222222", RoleId = 2 },
                    new User() { Id = 3, Name = "Tracy", Surname = "Minaji", Username = "tracyminaji",
                        Age = 25, Email = "tracy@gmail.com", Phone = "+333333333", RoleId = 1 },
                    new User() { Id = 4, Name = "Gus", Surname = "Peep", Username = "peeep",
                        Age = 31, Email = "guspeep@mail.com", Phone = "+444444444", RoleId = 3 },
                    new User() { Id = 5, Name = "Max", Surname = "Fosh", Username = "mfosh",
                        Age = 22, Email = "mfosh@mail.com", Phone = "+555555555", RoleId = 2 },
                    new User() { Id = 6, Name = "Max", Surname = "Bosh", Username = "mbosh",
                        Age = 21, Email = "mbosh@mail.com", Phone = "+666666666", RoleId = 1 }
                }
            );
        }
    }
}
