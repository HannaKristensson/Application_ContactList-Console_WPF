using Microsoft.Extensions.Hosting;
using ConsoleApp_ContactList_C_.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Buisness.Interfaces;
using Buisness.Services;
using ConsoleApp_ContactList_C_.Interfaces;


IHost host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddTransient<IContactService, ContactService>();
        services.AddTransient< IFileService, FileService>();
        services.AddTransient<IMainMenuDialog, MainMenuDialog>();
    })
    .Build();

var menuDialog = host.Services.GetRequiredService<IMainMenuDialog>();
menuDialog.RunMenu();


