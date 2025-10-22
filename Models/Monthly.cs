namespace CrudParking.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Monthly
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID  { get; set; }
    
    [Required]
    [ForeignKey("VehicleMonthly")]
    public int VehicleMonthlyID { get; set; }
    public VehicleMonthly VehicleMonthly { get; set; }
    
    [Required]
    [DataType(dataType:DataType.Date)]
    public DateTime DateStart { get; set; }
    
    [Required]
    [DataType(dataType:DataType.Date)]
    public DateTime DateEnd { get; set; }
    
    [Required]
    public bool Status { get; set; }
    
    [NotMapped]
    public bool Overdue => DateEnd < DateTime.Now;
    
}