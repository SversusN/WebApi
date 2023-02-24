namespace CustomerService.Entities;

using System.Text.Json.Serialization;

public class Filial
{
    public int Id { get; set; }
    public Guid? IdGlobal { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Langitude { get; set; }
    public decimal Latitude { get; set; }
    public bool? IsOpen { get; set; } = true;

}