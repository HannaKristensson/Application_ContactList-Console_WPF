
using Buisness.Models;
using System.Text.Json;

namespace Buisness.Services;

public class ContactService
{
    private readonly FileService _fileService = new FileService();
    private List<ContactModel> _contactList = [];


    //Create contact:
    public void CreateContact(ContactModel contact)
    {
        contact.Id = _contactList.Count > 0 ? _contactList[^1].Id + 1 : 1;
        _contactList.Add(contact);

        var json = JsonSerializer.Serialize(contact);
        _fileService.SaveToFile(json);
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
