﻿
using Buisness.Interfaces;
using Buisness.Services;
using ConsoleApp_contactList_C_.Factories;
using ConsoleApp_ContactList_C_.Interfaces;

namespace ConsoleApp_ContactList_C_.Dialogs;

//public class MainMenuDialog(IContactService contactService) : IMainMenuDialog
//{
//    private readonly IContactService _contactService = contactService;
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
        Console.WriteLine($"{"Q.",-2} Quit");
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
        bool hasError;
        var contacts = _contactService.GetContacts(out hasError);
        Console.Clear();
        Console.WriteLine("___ Contact List ___");

        //If error:
        if (hasError)
        {
            Console.WriteLine("Something went wrong, please try again later.");
            Console.ReadKey();
            return;
        }
        //If none found:
        if (!contacts.Any())
        {
            Console.WriteLine("No contacts found, press any key to go back.");
            Console.ReadKey();
            return;
        }

        //If found:
        foreach (var contact in contacts)
        {
            Console.WriteLine($"{"Id:",-15}{contact.Id}");
            Console.WriteLine($"{"Name:",-15}{contact.FirstName} {contact.LastName}");
            Console.WriteLine($"{"Phonenumber:",-15}{contact.Phone}");
            Console.WriteLine($"{"Email:",-15}{contact.Email}");
            Console.WriteLine($"{"Adress:",-15}{contact.StreetAddress}");
            Console.WriteLine($"{"",-15}{contact.PostalCode} {contact.City}");
            Console.ReadKey();
        }

    }


}
