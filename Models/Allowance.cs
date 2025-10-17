namespace CrudPark.Models;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
public class Allowance
{
    [Key]
    public int ID { get; set; }
    
    [Required(ErrorMessage = "Name is required")]
    [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Name must contain only letters")]    
    public string Name { get; set; }
    
    [EmailAddress]
    public string Email { get; set; }
    
    public string Plate { get; set; }

    public DateTime DateStart { get; set; } = DateTime.UtcNow;

    public DateTime DateEnd { get; set; } = DateTime.UtcNow;
}