
using Buisness.Helpers;
using Buisness.Interfaces;
using Buisness.Models;
using System.Diagnostics;
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
}
