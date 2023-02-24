using System.ComponentModel.DataAnnotations;

namespace CustomerService.Models.ServiceSal
{

    /*
      public int Id { get; set; }
    public Guid? IdGlobal { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public decimal Price { get; set; }
    public decimal SpecPrice { get; set; }
    public bool? IsReady { get; set; } = true;*/

    public class CreateServiceSal
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public decimal Price { get; set; }
        public decimal? SpecPrice { get; set; }
        [Required]
        public bool IsReady { get; set; }


    }
}
