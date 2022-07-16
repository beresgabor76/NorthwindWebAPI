using System.ComponentModel.DataAnnotations;

namespace NwOrdersAPI.DTOs
{
    public class RegisterUserDto
    {
        [Required]
        [MinLength(3)]
        [MaxLength(255)]
        public string Username { get; set; }
        [Required]
        [MinLength(4)]        
        public string Password { get; set; }
    }
}
