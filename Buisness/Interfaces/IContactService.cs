using Buisness.Models;

namespace Buisness.Interfaces
{
    public interface IContactService
    {
        //bool CreateContact();
        bool CreateContact(ContactModel contact);
        IEnumerable<ContactModel> GetContacts(out bool hasError);
    }
}