using System.Runtime.CompilerServices;

namespace CrudParking.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Pay
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int ID { get; set; }
    
    [Required]
    [ForeignKey("Ticket")]
    public int TicketID { get; set; }
    public  Ticket? Ticket { get; set; }
    
    [Required]
    [ForeignKey("Operator")]
    public int OperatorID { get; set; }
    public Operator? Operator { get; set; }
    
    [Required]
    [Range(0,double.MaxValue)]
    public decimal Amount { get; set; }
    
    [Required]
    [StringLength(50)]
    public string PayMethod { get; set; } //Cash,DebitCard,CreditCard,Transference
    
    [Required]
    [DataType(dataType:DataType.DateTime)]
    public DateTime DatePay { get; set; }=DateTime.Now;
    
}