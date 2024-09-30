using System.ComponentModel.DataAnnotations;

namespace QuickMart_Ecommerce_API.DTOs.IdentityUser
{
    public class RegisterDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
