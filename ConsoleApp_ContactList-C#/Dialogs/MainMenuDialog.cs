
using Buisness.Interfaces;
using Buisness.Services;
using ConsoleApp_contactList_C_.Factories;
using ConsoleApp_ContactList_C_.Interfaces;
using System.Runtime.CompilerServices;

namespace ConsoleApp_ContactList_C_.Dialogs;


public class MainMenuDialog(IContactService contactService) : IMainMenuDialog
{
    private readonly IContactService _contactService = contactService;

    public void RunMenu()
    {
        bool isRunning = true;

        while (isRunning)
        {
            MainMenu();
        }
    }

    //Main menu:
    private void MainMenu()
    {
        Console.Clear();
        Console.WriteLine("_____ Main Menu _____");
        Console.WriteLine($"{"1.",-2} Add contact");
        Console.WriteLine($"{"2.",-2} View all contacts");
        Console.WriteLine($"{"3.",-2} Edit contact");
        Console.WriteLine($"{"Q.",-2} Quit");
        Console.WriteLine("");
        Console.Write("Choose your menu option: ");
        var option = Console.ReadLine()!;
        Console.WriteLine("");

        switch (option.ToLower())
        {
            case "q":
                QuitOption();
                break;
            case "1":
                CreateOption();
                break;
            case "2":
                ViewOption();
                break;
            case "3":
                EditOption();
                break;
            default:
                Console.WriteLine("Invalid option");
                Console.ReadKey();
                break;
        }
    }

    //Quit application:
    private static void QuitOption()
    {
        Console.Clear();
        Console.WriteLine("_______ Quit ________");
        Console.Write("Do you want to quit this application? y / n : ");
        var option = Console.ReadLine()!;

        if (option.Equals("y", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(0);
        }
    }


    //Create contact:
    private void CreateOption()
    {
        var contact = ContactFactory.Create();

        Console.Clear();

        Console.WriteLine("___ Create Contact ___");
        Console.WriteLine("Enter following contact information.");
        Console.Write("Firstname: ");
        contact.FirstName = Console.ReadLine()!;
        Console.Write("Lastname: ");
        contact.LastName = Console.ReadLine()!;
        Console.Write("Email: ");
        contact.Email = Console.ReadLine()!;
        Console.Write("Phonenumber: ");
        contact.Phone = Console.ReadLine()!;
        Console.Write("Street address: ");
        contact.StreetAddress = Console.ReadLine()!;
        Console.Write("Postal code: ");
        contact.PostalCode = Console.ReadLine()!;
        Console.Write("City: ");
        contact.City = Console.ReadLine()!;

        var result = _contactService.CreateContact(contact);
        if (result)
        {
            Console.Write("Contact was created successfully!");
        }
        else
        {
            Console.Write("Unable to create new contact");
        }
        Console.ReadKey();
    }


    //View all contacts:
    private void ViewOption()
    {
        var contacts = _contactService.GetContacts();
        Console.Clear();
        Console.WriteLine("___ Contact List ___");

        //If empty or not found
        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found, press any key to go back.");
            Console.ReadKey();
            return;
        }

        //If found:
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{"Phone number:",-15}{contact.Phone}");
            Console.WriteLine($"{"Email:",-15}{contact.Email}");
            Console.WriteLine($"{"Adress:",-15}{contact.StreetAddress}");
            Console.WriteLine($"{"",-15}{contact.PostalCode} {contact.City}");
            Console.WriteLine("");
        }
        Console.ReadKey();
    }



    private void EditOption()
    {
        Console.Clear();
        Console.WriteLine("___ Edit Contact ___");
        Console.WriteLine($"{"1.",-2} Edit contact");
        Console.WriteLine($"{"2.",-2} Delete contact");
        Console.WriteLine($"{"3.",-2} Return to main menu");
        var option = Console.ReadLine()!;
        Console.WriteLine("");

        switch (option.ToLower())
        {
            case "1":
                EditContact();
                break;
            case "2":
                DeleteContact();
                break;
            case "3":
                break;
            default:
                Console.WriteLine("Invalid option");
                Console.ReadKey();
                break;
        }

        void EditContact()
        {
            Console.Clear();
            var contacts = _contactService.GetContacts();
            Console.WriteLine("___ Edit Contact ___");

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
            }

            Console.WriteLine("Choose a contact to edit: ");
            var option = Console.ReadLine()!.ToLower();

            //Two Lines below is ChatGTP generated
            var selectedContact = contacts.FirstOrDefault(contact => $"{contact.FirstName} {contact.LastName}".ToLower() == option);
            if (selectedContact != null)
            {
                Console.Clear();
                Console.WriteLine($"_ You have selected _");
                Console.WriteLine($"{"Name:",-15}{selectedContact.FirstName} {selectedContact.LastName}");
                Console.WriteLine($"{"Phonenumber:",-15}{selectedContact.Phone}");
                Console.WriteLine($"{"Email:",-15}{selectedContact.Email}");
                Console.WriteLine($"{"Adress:",-15}{selectedContact.StreetAddress}");
                Console.WriteLine($"{"",-15}{selectedContact.PostalCode} {selectedContact.City}");

                Console.WriteLine("Do you want to edit this contact? y / n : ");
                var editOption = Console.ReadLine()!;

                if (editOption.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.Clear();
                    Console.WriteLine("___ Selected Contact ___");
                    Console.WriteLine($"{"Name:",-15}{selectedContact.FirstName} {selectedContact.LastName}");
                    Console.WriteLine($"{"Phonenumber:",-15}{selectedContact.Phone}");
                    Console.WriteLine($"{"Email:",-15}{selectedContact.Email}");
                    Console.WriteLine($"{"Adress:",-15}{selectedContact.StreetAddress}");
                    Console.WriteLine($"{"",-15}{selectedContact.PostalCode} {selectedContact.City}");

                    Console.WriteLine("");
                    Console.WriteLine($"Please enter the right information:");
                    Console.Write("Firstname: ");
                    selectedContact.FirstName = Console.ReadLine()!;
                    Console.Write("Lastname: ");
                    selectedContact.LastName = Console.ReadLine()!;
                    Console.Write("Email: ");
                    selectedContact.Email = Console.ReadLine()!;
                    Console.Write("Phonenumber: ");
                    selectedContact.Phone = Console.ReadLine()!;
                    Console.Write("Street address: ");
                    selectedContact.StreetAddress = Console.ReadLine()!;
                    Console.Write("Postal code: ");
                    selectedContact.PostalCode = Console.ReadLine()!;
                    Console.Write("City: ");
                    selectedContact.City = Console.ReadLine()!;

                    var result = _contactService.UpdateContact(selectedContact);
                    if (result)
                    {
                        Console.Write("Contact was updated successfully!");
                    }
                    else
                    {
                        Console.Write("Unable to update the contact.");
                    }

                } else if (editOption.Equals("n", StringComparison.CurrentCultureIgnoreCase))
                {
                    return;
                } else
                {
                    Console.WriteLine("Invalid option");
                    Console.ReadKey();
                    return;
                }


            }
            else
            {
                Console.WriteLine("Contact not found.");
            }
            Console.ReadKey();
        }

        void DeleteContact()
        {
            Console.Clear();
            var contacts = _contactService.GetContacts();
            Console.WriteLine("___ Delete Contact ___");

            foreach (var contact in contacts)
            {
                Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
            }

            Console.WriteLine("");
            Console.WriteLine("Choose a contact to delete: ");
            var option = Console.ReadLine()!.ToLower();

            //Two Lines below is ChatGTP generated
            var selectedContact = contacts.FirstOrDefault(contact => $"{contact.FirstName} {contact.LastName}".ToLower() == option);
            if (selectedContact != null)
            {
                Console.Clear();
                Console.WriteLine($"__ You have selected __");
                Console.WriteLine($"{"Name:",-15}{selectedContact.FirstName} {selectedContact.LastName}");
                Console.WriteLine($"{"Phonenumber:",-15}{selectedContact.Phone}");
                Console.WriteLine($"{"Email:",-15}{selectedContact.Email}");
                Console.WriteLine($"{"Adress:",-15}{selectedContact.StreetAddress}");
                Console.WriteLine($"{"",-15}{selectedContact.PostalCode} {selectedContact.City}");

                Console.WriteLine("");
                Console.WriteLine("Are you sure to delete this contact? y / n : ");
                var editOption = Console.ReadLine()!;

                if (editOption.Equals("y", StringComparison.CurrentCultureIgnoreCase))
                {
                    bool result = _contactService.DeleteContact(selectedContact);
                    if (result)
                    {
                        Console.WriteLine("Contact was deleted successfully!");
                    }
                    else
                    {
                        Console.WriteLine("Unable to delete the contact.");
                    }
                }
                else if (editOption.Equals("n", StringComparison.CurrentCultureIgnoreCase))
                {
                    Console.WriteLine("Contact was not deleted! Press any key to go back.");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid option");
                    return;
                }
                Console.ReadKey();
            }
        }
    }
}


