using Buisness.Services;
using Buisness.Interfaces;
using Buisness.Models;
using Moq;
using System.Numerics;


namespace MainApp.Tests.Services_Tests;

public class ContactService_Tests
{
    private readonly Mock<IFileService> _fileServiceMock;
    private readonly Mock<IContactService> _contactServiceMock;
    private readonly IContactService _contactService;

    public ContactService_Tests()
    {
        _fileServiceMock = new Mock<IFileService>();
        _contactServiceMock = new Mock<IContactService>();
        _contactService = new ContactService( _fileServiceMock.Object );
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

    //[Fact]
    //public void GetContact_ShouldReturnContact_When()
    //{
    //    //arrange
    //    var contactId = 1;
    //    var expectedContact = new ContactModel { Id = contactId, Name = "name" };

    //    //act
    //    _contactServiceMock.Setup(service => service.GetContact(contactId))
    //        .Returns(expectedContact);

    //    //assert

    //}


    //[Fact]
    //public void GetContacts_ShouldReturnListOfContacts()
    //{
    ////arrange
    //var contacts = new List<ContactModel>()
    //{
    //    new() { FirstName = "firstname", LastName = "lastname", Email = "email", Phone = "phone", StreetAddress = "adress", PostalCode = "code", City = "city" },
    //    new() { FirstName = "firstname2", LastName = "lastname2", Email = "email2", Phone = "phone2", StreetAddress = "adress2", PostalCode = "code2", City = "city2" }
    //};
    //_fileServiceMock.Setup(ps => ps.()).Returns(contacts);

    ////act
    ////var result = _contactServiceMock.Object.GetContacts();
    //var result = _contactService.GetContacts();

    ////assert
    ////Result is not null
    //Assert.NotNull(result);
    ////Result shows two contacts in list
    //Assert.Equal(2, result.Count());
    ////Result shows FirstName is firstname in contact one. 
    //Assert.Equal("firstname", result.First().FirstName);

    //_contactService.GetContacts(TestData.)

    //}

}
