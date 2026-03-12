namespace WorldLeague.API.Entities;

public class Team 
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Country { get; set; }
    public List<GroupTeam> GroupTeams { get; set; } = [];
}