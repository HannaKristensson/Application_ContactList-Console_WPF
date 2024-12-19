
using Buisness.Models;
using ConsoleApp_contactList_C_.Factories;

namespace ConsoleApp.Tests.Factories_Tests;

public class ProdcutFactory_Tests
{
    [Fact]
    public void Create_ShouldReturnContactModel()
    {
        //arrange 

        //act
        ContactModel result = ContactFactory.Create();
        //assert
        Assert.IsType<ContactModel>(result);

    }

    [Theory]
    [InlineData("test", "test", "test", "test", "test", "test", "test")]
    [InlineData(  "", "test", "test", "test", "test", "test", "test")]
    public void Create_ShouldReturnContact_WhenProductModelIsSupplied(string firstname, string lastname, string email, string phone, string streetAddress, string postalCode, string city )
    {
        //arrange 
        ContactModel contactModel = new() { FirstName = firstname, LastName = lastname , Email = email, Phone = phone, StreetAddress = streetAddress, PostalCode = postalCode, City = city };

        //act 
        ContactEntity result = ContactFactory.Create(contactModel);

        //assert
        Assert.IsType<ContactEntity>(result);
        Assert.Equal(contactModel.FirstName, result.FirstName);
        Assert.Equal(contactModel.LastName, result.LastName);
    }
}
