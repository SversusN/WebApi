namespace CustomerService.Entities;

using System.Text.Json.Serialization;

public class ServiceSal
{
    public int Id { get; set; }
    public Guid? IdGlobal { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal SpecPrice { get; set; }
    public bool? IsReady { get; set; } = true;

}