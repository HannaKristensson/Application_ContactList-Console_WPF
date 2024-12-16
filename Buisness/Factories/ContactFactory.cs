
using Buisness.Models;

namespace ConsoleApp_contactList_C_.Factories;

public static class ContactFactory
{
    public static ContactModel Create() => new ();


    //Här skapas en metodpå hur form ska fungera
    public static ContactEntity Create(ContactModel contact)
    {
        return new ContactEntity
        {
            Id = contact.Id,
            FirstName = contact.FirstName.Trim(),
            LastName = contact.LastName.Trim(),
            Email = contact.Email.Trim().ToLower(),
            Phone = contact.Phone.Trim(),
            StreetAddress = contact.StreetAddress.Trim(),
            PostalCode = contact.PostalCode,
            City = contact.City.Trim().ToUpper(),
        };
    }
}
