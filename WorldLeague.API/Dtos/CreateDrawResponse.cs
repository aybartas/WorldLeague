using WorldLeague.API.Entities;

namespace WorldLeague.API.Dtos
{
    public class CreateDrawResponse
    {
        public List<GroupDto> Groups { get; set; } = [];

        public static CreateDrawResponse MapFromEntity(Draw draw)
        {
            return new CreateDrawResponse
            {
                Groups = draw.Groups
                    .OrderBy(g => g.GroupName)
                    .Select(g => new GroupDto
                    {
                        GroupName = g.GroupName,
                        Teams = g.GroupTeams
                            .Select(gt => new TeamDto
                            {
                                Name = gt.Team.Name,
                                Country = gt.Team.Country
                            })
                            .ToList()
                    })
                    .ToList()
            };
        }
    }

    public class GroupDto
    {
        public string GroupName { get; set; }
        public List<TeamDto> Teams { get; set; } = [];
    }

    public class TeamDto
    {
        public string Name { get; set; }
        public string Country { get; set; }
    }
}
