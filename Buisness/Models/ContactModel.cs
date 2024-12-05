
namespace Buisness.Models;

public class ContactModel
{
    public int Id { get; set; }
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public string Email { get; set; } = null!;
    public DateTime CreatedDate { get; set; } = DateTime.Now;
}
