namespace CustomerService.Models
{
   

    using System.ComponentModel.DataAnnotations;
    using CustomerService.Entities;


    /*
    public int Id { get; set; }
    public Guid? IdGlobal { get; set; } = Guid.NewGuid();
    public string? Name { get; set; }
    public string? Comment { get; set; }
    public string PhotoFile { get; set; }
    public Rating? Rating { get; set; }
    public decimal? Coef { get; set; }
    public bool? IsWork { get; set; } = true;

     */
    public class CreateEmployee
    {
        [Required]
        public string? Name { get; set; }

        [Required]
        public string Comment { get; set; }

        public string? PhotoFile { get; set; }

        [Required]
        [EnumDataType(typeof(Rating))]
        public string Rating { get; set; }

        [Required]
      
        public decimal? Coef { get; set; }

        [Required]
        public bool IsWork { get; set; }
    }
}
