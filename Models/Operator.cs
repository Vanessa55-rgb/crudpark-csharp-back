using System;
using System.ComponentModel.DataAnnotations;

namespace CrudPark.Models
{
    public class Operator
    {
        [Key]
        public int ID { get; set; }

        [Required(ErrorMessage = "The name is required")]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "The content of the name is only letters")]
        public string Name { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}