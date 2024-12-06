using Buisness.Models;

namespace Buisness.Interfaces
{
    public interface IContactService
    {
        void CreateContact(ContactModel contact);
        IEnumerable<ContactModel> GetContacts(out bool hasError);
    }
}