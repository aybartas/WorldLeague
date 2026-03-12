namespace WorldLeague.API.Entities;

public class Team 
{
    public int Id { get; set; }
    public string Name { get; set; } 
    public string Country { get; set; }
    public List<GroupTeam> GroupTeams { get; set; } = [];
}
public class Draw
{
    public int Id { get; set; }
    public string DrawerFirstName { get; set; }      
    public string DrawerLastName { get; set; }      
    public List<Group> Groups { get; set; } = [];
}

public class Group 
{
    public int Id { get; set; }
    public int DrawId { get; set; }
    public Draw Draw { get; set; } = null!;
    public string GroupName { get; set; }
    public List<GroupTeam> GroupTeams { get; set; } = [];
}

public class GroupTeam 
{
    public int Id { get; set; }
    public int GroupId { get; set; }
    public Group Group { get; set; }
    public int TeamId { get; set; }
    public Team Team { get; set; }
}