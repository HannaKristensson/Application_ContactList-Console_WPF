using Buisness.Helpers;
using Buisness.Interfaces;
using Buisness.Models;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;

namespace Buisness.Services;


public class ContactService(IFileService fileService) : IContactService
{
    private readonly IFileService _fileService = fileService;
    private List<ContactModel> _contactList = [];



    //Create contact:
    public bool CreateContact(ContactModel contact)
    {
        try
        {
            contact.Id = UniqeIdGenerator.GenerateUniqeId();
            _contactList.Add(contact);

            var json = JsonSerializer.Serialize(_contactList);
            bool result = _fileService.SaveListToFile(json);
            return result;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to create contact: {ex.Message}");
            return false;
        }
    }


    //Get contacts:
    public IEnumerable<ContactModel> GetContacts()
    {
        try
        {
            var json = _fileService.GetListFromFile();

            if (!string.IsNullOrEmpty(json))
            {
                try
                {
                    _contactList = JsonSerializer.Deserialize<List<ContactModel>>(json) ?? [];
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    _contactList = [];
                }
            }
            else
            {
               Console.WriteLine("No contacts found in file.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error finding contacts: {ex.Message}");
        }

        return _contactList;
    }


    //Update contact:
    // Method below is created with help of ChatGTP. My biggest struggle was how to save the info back info the json file, which line 87-88 finally solved for me. 
    public bool UpdateContact(ContactModel selectedContact)
    {

            var contact = _contactList.FirstOrDefault(c => c.Id == selectedContact.Id);

            if (contact != null)
            {
                contact.FirstName = selectedContact.FirstName;
                contact.LastName = selectedContact.LastName;
                contact.Email = selectedContact.Email;
                contact.Phone = selectedContact.Phone;
                contact.StreetAddress = selectedContact.StreetAddress;
                contact.PostalCode = selectedContact.PostalCode;
                contact.City = selectedContact.City;

                var json = JsonSerializer.Serialize(_contactList);
                bool result = _fileService.SaveListToFile(json);

                return true;
            }
        else
        {
            return false;
        }
    }

    public bool DeleteContact(ContactModel selectedContact)
    {
        var contact = _contactList.FirstOrDefault(c => c.Id == selectedContact.Id);
        if (contact != null)
        {
            _contactList.Remove(contact);

            var json = JsonSerializer.Serialize(_contactList);
            bool result = _fileService.SaveListToFile(json);
            return true;
        } else
        {
            return false;
        }
    }

}
