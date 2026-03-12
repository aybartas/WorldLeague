using WorldLeague.API.Entities;

namespace WorldLeague.API.Database
{
    public static class DatabaseSeeder
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.Teams.Any())
                return;

            var teams = new List<Team> {

                new() { Id = 1, Name = "Adesso İstanbul", Country = "Türkiye" },
                new() { Id = 2, Name = "Adesso Ankara", Country = "Türkiye" },
                new() { Id = 3, Name = "Adesso İzmir", Country = "Türkiye" },
                new() { Id = 4, Name = "Adesso Antalya", Country = "Türkiye" },

                new() { Id = 5, Name = "Adesso Berlin", Country = "Almanya" },
                new() { Id = 6, Name = "Adesso Frankfurt", Country = "Almanya" },
                new() { Id = 7, Name = "Adesso Münih", Country = "Almanya" },
                new() { Id = 8, Name = "Adesso Dortmund", Country = "Almanya" },

                new() { Id = 9, Name = "Adesso Paris", Country = "Fransa" },
                new() { Id = 10, Name = "Adesso Marsilya", Country = "Fransa" },
                new() { Id = 11, Name = "Adesso Nice", Country = "Fransa" },
                new() { Id = 12, Name = "Adesso Lyon", Country = "Fransa" },

                new() { Id = 13, Name = "Adesso Amsterdam", Country = "Hollanda" },
                new() { Id = 14, Name = "Adesso Rotterdam", Country = "Hollanda" },
                new() { Id = 15, Name = "Adesso Lahey", Country = "Hollanda" },
                new() { Id = 16, Name = "Adesso Eindhoven", Country = "Hollanda" },

                new() { Id = 17, Name = "Adesso Lisbon", Country = "Portekiz" },
                new() { Id = 18, Name = "Adesso Porto", Country = "Portekiz" },
                new() { Id = 19, Name = "Adesso Braga", Country = "Portekiz" },
                new() { Id = 20, Name = "Adesso Coimbra", Country = "Portekiz" },

                new() { Id = 21, Name = "Adesso Roma", Country = "İtalya" },
                new() { Id = 22, Name = "Adesso Milano", Country = "İtalya" },
                new() { Id = 23, Name = "Adesso Venedik", Country = "İtalya" },
                new() { Id = 24, Name = "Adesso Napoli", Country = "İtalya" },

                new() { Id = 25, Name = "Adesso Sevilla", Country = "İspanya" },
                new() { Id = 26, Name = "Adesso Madrid", Country = "İspanya" },
                new() { Id = 27, Name = "Adesso Barselona", Country = "İspanya" },
                new() { Id = 28, Name = "Adesso Granada", Country = "İspanya" },

                new() { Id = 29, Name = "Adesso Brüksel", Country = "Belçika" },
                new() { Id = 30, Name = "Adesso Brugge", Country = "Belçika" },
                new() { Id = 31, Name = "Adesso Gent", Country = "Belçika" },
                new() { Id = 32, Name = "Adesso Anvers", Country = "Belçika" }

            };

            await context.Teams.AddRangeAsync(teams);
            await context.SaveChangesAsync();
        }
    }
}
