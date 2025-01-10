using Buisness.Models;

namespace Buisness.Interfaces
{
    public interface IContactService
    {
        bool CreateContact(ContactModel contact);
        IEnumerable<ContactModel> GetContacts();
        //ContactModel GetContactById(string id);
        bool UpdateContact(ContactModel updatedContact);
    }
}