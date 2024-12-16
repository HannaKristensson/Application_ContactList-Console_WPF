﻿
using Buisness.Helpers;
using Buisness.Interfaces;
using Buisness.Models;
using System.Diagnostics;
using System.Text.Json;

namespace Buisness.Services;

//public class ContactService(IFileService fileService) : IContactService
//{
//    private readonly IFileService _fileService = fileService;
//    private List<ContactModel> _contactList = [];
public class ContactService
{
    private readonly FileService _fileService = new FileService();
    private List<ContactModel> _contactList = [];

    //Create contact:
    public bool CreateContact(ContactModel contact)
    {
        try
        {
        contact.Id = UniqeIdGenerator.GenerateUniqeId();

            _contactList.Add(contact);

            var json = JsonSerializer.Serialize(_contactList);
            var result = _fileService.SaveListToFile(json);
            return true;
        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Failed to create contact {ex.Message}");
            return false;
        }
    }


    //Get contacts:
    public IEnumerable<ContactModel> GetContacts(out bool hasError)
    {
        hasError = false;
        var json = _fileService.GetListFromFile();

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
        else
        {
            Debug.WriteLine("No contacts found in file.");
        }
        return _contactList;
    }





}
