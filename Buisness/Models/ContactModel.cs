
namespace Buisness.Models;

public class ContactModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string Phone { get; set; } = null!;
    public string StreetAddress { get; set; } = null!;
    public string PostalCode {  get; set; } = null!;
    public string City { get; set; } = null!;
}
