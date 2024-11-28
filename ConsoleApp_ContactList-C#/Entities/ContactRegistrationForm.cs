
using System.ComponentModel.DataAnnotations;

namespace ConsoleApp_ContactList_C_.Entities
{
    public class ContactRegistrationForm
    {
        [Required]
        public string FirstName { get; set; } = null!;

        [Required]
        public string LastName { get; set; } = null!;

        [Required]
        [EmailAddress]
        //[RegularExpression(@"^[^@\s]+[^@\s]+\.[^@\s]+$"), ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = null!;

        [Required]
        public string PhoneNumber { get; set; } = null!;

        [Required]
        public string StreetAddress { get; set; } = null!;

        [Required]
        public string PostalCode { get; set; } = null!;

        [Required]
        public string City { get; set; } = null!;

    }
}
