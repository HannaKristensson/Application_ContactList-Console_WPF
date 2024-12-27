using Buisness.Models;

namespace Buisness.Interfaces
{
    public interface IContactService
    {
        bool CreateContact(ContactModel contact);
        IEnumerable<ContactModel> GetContacts();
    }
}