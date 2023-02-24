namespace CustomerService.Entities;

using System.Text.Json.Serialization;
using System.Drawing;

public class Shedule
{
    public int Id { get; set; }
    public Guid? IdGlobal { get; set; } = Guid.NewGuid();
    public DateOnly? Date { get; set; }
    public Guid? IdUser { get; set; }
    public Guid? IdService { get; set; }
    public TimeOnly DateStart { get; set; }
    public DateTime DateEnd { get; set; }  
    public string? Comment { get; set; }
    public string? Name { get; set; }
    public bool IsCompleted { get; set; } = false;
    public decimal? Price { get; set; }
    public string? PhotoFile { get; set; }
    public Rating? Rating { get; set; }
    public decimal? Coef { get; set; }
}