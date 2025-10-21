namespace CrudParking.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Ticket
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    
    [Required]
    [StringLength(10)]
    public string Plate { get; set; }
    
    [Required]
    [DataType(DataType.Date)]
    public DateTime DateStart { get; set; }
    
    [DataType(DataType.Date)]
    public DateTime? DateEnd { get; set; }
    
    [Required]
    [ForeignKey("Operator")]
    public int OperatorID { get; set; }
    public Operator? Operator { get; set; }
    
    [Required]
    [StringLength(20)]
    public string Type { get; set; } //MOnthly or guest

    public bool Closed { get; set; } = false;
    
    //Relation with pay (if applicate)
    public Pay? Pay { get; set; }


}