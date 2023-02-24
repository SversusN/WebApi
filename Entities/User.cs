namespace CustomerService.Entities;

using System.Text.Json.Serialization;

public class User
{
    public int Id { get; set; }
    public Guid? IdGlobal { get; set; } = Guid.NewGuid();
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public Role Role { get; set; }

    [JsonIgnore]
    public string PasswordHash { get; set; }
}