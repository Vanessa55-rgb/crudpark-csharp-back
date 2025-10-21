namespace CrudParking.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Operator
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }

    [Required(ErrorMessage = "Name is required")]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(100)]
    [EmailAddress(ErrorMessage = "Email is invalid")]
    public string? Email { get; set; }
    
    [Required(ErrorMessage = "The user is required")]
    [StringLength(50)]
    public string UserName { get; set; }
    
    [Required(ErrorMessage = "Password is required")]
    [StringLength(100)]
    public string Password { get; set; }
    
    [Required]
    public bool Status { get; set; }
    
    //Relations with operator can register more tickets and pays
    public ICollection<Ticket>? Tickets { get; set; } = new List<Ticket>();
    public ICollection<Pay>? Pays { get; set; } = new List<Pay>();
}