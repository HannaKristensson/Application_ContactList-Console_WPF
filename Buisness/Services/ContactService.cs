
using Buisness.Interfaces;
using Buisness.Models;
using System.Text.Json;

namespace Buisness.Services;

public class ContactService(FileService fileService) : IContactService
{
    private readonly FileService _fileService = fileService;
    private List<ContactModel> _contactList = [];


    //Create contact:
    public void CreateContact(ContactModel contact)
    {
        contact.Id = Guid.NewGuid().ToString();
        _contactList.Add(contact);
        _fileService.SaveToFile(JsonSerializer.Serialize(contact));
    }


    //Get contacts:
    public IEnumerable<ContactModel> GetContacts(out bool hasError)
    {
        hasError = false;
        var json = _fileService.GetFromFile();

        if (!string.IsNullOrEmpty(json))
        {
            try
            {
                _contactList = JsonSerializer.Deserialize<List<ContactModel>>(json) ?? [];
            }
            catch (Exception ex)
            {
                hasError = true;
                Console.WriteLine(ex.Message);
                //ändra till andra errorsättet!!
                _contactList = [];
            }
        }
        return _contactList;
    }
}
