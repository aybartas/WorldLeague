using Microsoft.EntityFrameworkCore;
using WorldLeague.API.Database;
using WorldLeague.API.Dtos;
using WorldLeague.API.Entities;

namespace WorldLeague.API.Services
{
    public class DrawGroupingService
    {
        private readonly AppDbContext _context;
        private readonly ILogger<DrawGroupingService> _logger;

        private static List<string> GroupNames = ["A", "B", "C", "D", "E", "F", "G", "H"];

        public DrawGroupingService(AppDbContext context, ILogger<DrawGroupingService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<CreateDrawResponse> CreateTeamGroups(CreateDrawRequest request)
        {
            try
            {
                var teams = await _context.Teams.ToListAsync();

                var randomizedTeams = teams.OrderBy(_ => Guid.NewGuid()).ToList();

                var teamsPerGroup = teams.Count / request.GroupCount;

                var groups = GroupNames
                    .Take(request.GroupCount)
                    .Select(name => new Group { GroupName = name })
                    .ToList();

                var usedTeamIds = new HashSet<int>();

                for (var currentIteration = 0; currentIteration < teamsPerGroup; currentIteration++)
                {
                    foreach (var group in groups)
                    {
                        var existingCountries = group.GroupTeams
                            .Select(gt => gt.Team.Country)
                            .ToHashSet();

                        var availableTeam = randomizedTeams.First(t =>
                            !usedTeamIds.Contains(t.Id) &&
                            !existingCountries.Contains(t.Country));

                        group.GroupTeams.Add(new GroupTeam
                        {
                            TeamId = availableTeam.Id,
                            Team = availableTeam
                        });

                        usedTeamIds.Add(availableTeam.Id);

                        _logger.LogInformation("Team {TeamName} assigned to group {GroupName}", availableTeam.Name, group.GroupName);
                    }
                }

                var draw = new Draw
                {
                    DrawerFirstName = request.DrawerFirstName,
                    DrawerLastName = request.DrawerLastName,
                    Groups = groups
                };

                _context.Draws.Add(draw);
                await _context.SaveChangesAsync();

                _logger.LogInformation("Draw successfully created with {GroupCount} groups.", groups.Count);

                var response = CreateDrawResponse.MapFromEntity(draw);

                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while creating draw groups.");
                throw;
            }
        }
    }
}