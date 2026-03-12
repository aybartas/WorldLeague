namespace WorldLeague.API.Entities;

public class Draw
{
    public int Id { get; set; }
    public string DrawerFirstName { get; set; }      
    public string DrawerLastName { get; set; }      
    public List<Group> Groups { get; set; } = [];
}