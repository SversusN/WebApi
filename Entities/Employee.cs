namespace CustomerService.Entities;

using System.Text.Json.Serialization;
using System.Drawing;

public class Employee
{
    public int Id { get; set; }
    public Guid? IdGlobal { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? Comment { get; set; }
    public string PhotoFile { get; set; }
    public Rating? Rating { get; set; }
    public decimal? Coef { get; set; }
    public bool? IsWork { get; set; } = true;

}