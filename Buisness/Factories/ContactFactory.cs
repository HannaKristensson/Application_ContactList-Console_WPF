
using Buisness.Models;
using System.Diagnostics;

namespace ConsoleApp_contactList_C_.Factories;

public static class ContactFactory
{


    public static ContactModel Create() => new ();


    //Här skapas en metodpå hur form ska fungera
    public static ContactEntity? Create(ContactModel contact)
    {
        try
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
        catch (Exception ex)
        {
            Debug.WriteLine($"Error creating UsserEntity: {ex.Message}");
            return null;
        }

    }
}
