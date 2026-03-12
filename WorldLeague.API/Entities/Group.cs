namespace WorldLeague.API.Entities;

public class Group 
{
    public int Id { get; set; }
    public int DrawId { get; set; }
    public Draw Draw { get; set; } = null!;
    public string GroupName { get; set; }
    public List<GroupTeam> GroupTeams { get; set; } = [];
}