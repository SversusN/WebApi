namespace CustomerService.Models;

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class CreateFilial
{
    [Required]
   
    public string Name { get; set; }
    public string Address { get; set; }
    public decimal Langitude { get; set; }
    public decimal Latitude { get; set; }
    [Required]
    public bool? IsOpen { get; set; } = true;

}