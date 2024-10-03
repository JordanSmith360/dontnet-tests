namespace DotnetTests.Database.Models;

public class Users : BaseEntity
{
    public int Id { get; set; } = 0;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Age { get; set; } = 0;
}
