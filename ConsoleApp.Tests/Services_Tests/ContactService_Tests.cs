using Buisness.Services;
using Buisness.Interfaces;
using Buisness.Models;
using Moq;
using System.Text.Json;


namespace MainApp.Tests.Services_Tests;

public class ContactService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly ContactService _contactService;

    public ContactService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactServiceMock = new Mock<IContactService>();
        _contactService = new ContactService(_fileServiceMock.Object);
    }


    [Fact]
    public void CreateContact_ShouldAddProductToList_AndSaveToFile()
    {
        //arrange
        var contactModel = new ContactModel();
        _fileServiceMock
            .Setup(fileservice => fileservice.SaveListToFile(It.IsAny<string>()))
            .Returns(true);

        //act
        var result = _contactService.CreateContact(contactModel);

        //assert
        Assert.True(result);
        _fileServiceMock.Verify(service => service.SaveListToFile(It.IsAny<string>()), Times.Once );
    }


    [Fact]
    public void GetContacts_ShouldReturnListOfContacts()
    {
        //arrange
        var contacts = new List<ContactModel>
    {
        new ContactModel { FirstName = "firstname", LastName = "lastname", Email = "email", Phone = "phone", StreetAddress = "adress", PostalCode = "code", City = "city" },
        new ContactModel { FirstName = "firstname2", LastName = "lastname2", Email = "email2", Phone = "phone2", StreetAddress = "adress2", PostalCode = "code2", City = "city2" }
    };
        var json = JsonSerializer.Serialize(contacts);
        _fileServiceMock.Setup(fileservice => fileservice.GetListFromFile()).Returns(json);

        //act
        var result = _contactService.GetContacts();

        //assert
        Assert.NotNull(result);
        Assert.Equal(2, result.Count()); 
        Assert.Equal("firstname", result.First().FirstName);
    }


    //Mock created by chatGPT, with a few own changes.
    [Fact]
    public void UpdateContact_ShouldEditContactInList_AndSaveChangesToFile()
    {
        //arrange
        var contacts = new List<ContactModel>
    {
        new ContactModel { Id="1", FirstName = "firstname", LastName = "lastname", Email = "email", Phone = "phone", StreetAddress = "adress", PostalCode = "code", City = "city" },
        new ContactModel { Id="2", FirstName = "firstname2", LastName = "lastname2", Email = "email2", Phone = "phone2", StreetAddress = "adress2", PostalCode = "code2", City = "city2" },
        new ContactModel { Id="3", FirstName = "firstname3", LastName = "lastname3", Email = "email3", Phone = "phone3", StreetAddress = "adress3", PostalCode = "code3", City = "city3" }
    };
        var json = JsonSerializer.Serialize(contacts);
        _fileServiceMock.Setup(fileservice => fileservice.GetListFromFile()).Returns(json);
        _fileServiceMock.Setup(fileservice => fileservice.SaveListToFile(It.IsAny<string>()));

        //act
        var selectedContact = contacts.FirstOrDefault(contact => contact.Id == "1");
        if (selectedContact != null)
        {
            selectedContact.FirstName = "NewFirstName";

            var result = _contactService.UpdateContact(selectedContact);
        }

        var newList = contacts.Select(c => c.Id == "2" ? selectedContact : c).ToList();
        _fileServiceMock.Setup(fs => fs.GetListFromFile()).Returns(JsonSerializer.Serialize(newList));

        var updatedContacts = _contactService.GetContacts();

        //assert
        Assert.Equal(3, updatedContacts.Count());
        Assert.Contains(updatedContacts, contact => contact.Id == "1" && contact.FirstName == "NewFirstName");
    }


    //Mock created by chatGPT, with a few own changes.
    [Fact]
    public void DeleteContact_ShouldDeleteContactFromList_AndSaveChangesToFile()
    {
        //arrange
        var contacts = new List<ContactModel>
    {
        new ContactModel { Id="1", FirstName = "firstname", LastName = "lastname", Email = "email", Phone = "phone", StreetAddress = "adress", PostalCode = "code", City = "city" },
        new ContactModel { Id="2", FirstName = "firstname2", LastName = "lastname2", Email = "email2", Phone = "phone2", StreetAddress = "adress2", PostalCode = "code2", City = "city2" },
        new ContactModel { Id="3", FirstName = "firstname3", LastName = "lastname3", Email = "email3", Phone = "phone3", StreetAddress = "adress3", PostalCode = "code3", City = "city3" }
    };
        var json = JsonSerializer.Serialize(contacts);
        _fileServiceMock.Setup(fileservice => fileservice.GetListFromFile()).Returns(json);
        _fileServiceMock.Setup(fileservice => fileservice.SaveListToFile(It.IsAny<string>()));

        //act
        var selectedContact = contacts.FirstOrDefault(contact => contact.Id == "3");
        var result = _contactService.DeleteContact(selectedContact);


        var newList = contacts.Where(c => c.Id != "3").ToList();
        _fileServiceMock.Setup(fs => fs.GetListFromFile()).Returns(JsonSerializer.Serialize(newList));

        var updatedContacts = _contactService.GetContacts();

        //assert
        Assert.Equal(2, updatedContacts.Count());
        Assert.DoesNotContain(updatedContacts, contact => contact.Id == "3");
    }
}
