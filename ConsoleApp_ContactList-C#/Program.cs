
using ConsoleApp_ContactList_C_.Entities;
using ConsoleApp_ContactList_C_.Factories;

ContactRegistrationForm contactRegistrationFrom = ContactFactory.Create();
#region User Registration Input Dialog
Console.WriteLine("Enter contact-information below");
Console.Write("Firstname: ");
contactRegistrationFrom.FirstName = Console.ReadLine()!;
Console.Write("Lastname: ");
contactRegistrationFrom.LastName = Console.ReadLine()!;
Console.Write("Email: ");
contactRegistrationFrom.Email = Console.ReadLine()!;
Console.Write("Phonenumber: ");
contactRegistrationFrom.PhoneNumber = Console.ReadLine()!;
Console.Write("Street address: ");
contactRegistrationFrom.StreetAddress = Console.ReadLine()!;
Console.Write("Postal code: ");
contactRegistrationFrom.PostalCode = Console.ReadLine()!;
Console.Write("City: ");
contactRegistrationFrom.City = Console.ReadLine()!;


#endregion

// nu används entity:n för att spara ner infon i databasen
ContactEntity contactEntity = ContactFactory.Create(contactRegistrationFrom);
#region UserEntity Output Dialog

Console.WriteLine("");
Console.WriteLine("ContactEntity");
Console.WriteLine($"{"Id:",-15}{contactEntity.Id}");
Console.WriteLine($"{"Name:",-15}{contactEntity.FirstName} {contactEntity.LastName}");
Console.WriteLine($"{"Phonenumber:",-15}{contactEntity.PhoneNumber}");
Console.WriteLine($"{"Email:",-15}{contactEntity.Email}");
Console.WriteLine($"{"Adress:",-15}{contactEntity.StreetAddress}");
Console.WriteLine($"{"",-15}{contactEntity.PostalCode} {contactEntity.City}");
Console.ReadKey();

#endregion
