using System.ComponentModel.DataAnnotations;

namespace QuickMart_Ecommerce_API.DTOs
{
    public class AddressDto
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string Street { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string ZipCode { get; set; }
    }
}
