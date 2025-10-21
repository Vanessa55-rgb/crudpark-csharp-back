namespace CrudParking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Rate
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    
    [Required]
    [Range(0,double.MaxValue)]
    public double BaseValueByHour { get; set; }
    
    [Required]
    [Range(0,double.MaxValue)]
    public double BaseValueByFraction { get; set; }
    
    [Range(0,double.MaxValue)]
    public decimal? MaxDay { get; set; }

    [Required] [Range(0, int.MaxValue)] public int TimeHopeMinutes { get; set; } = 30;
}