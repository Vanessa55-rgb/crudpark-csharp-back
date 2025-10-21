namespace CrudParking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class VehicleMonthly
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    
    [Required]
    [StringLength(10)]
    public string Plate { get; set; }
    
    [Required]
    [StringLength(100)]
    public string Titularname { get; set; }
    
    [StringLength(100)]
    [EmailAddress]
    public string?  Email { get; set; }
    
    //Relation with Monthly 
    public ICollection<VehicleMonthly>Monthlies { get; set; } = new List<VehicleMonthly>();
}