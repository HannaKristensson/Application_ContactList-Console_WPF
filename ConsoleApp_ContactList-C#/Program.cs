using Microsoft.Extensions.Hosting;
using ConsoleApp_ContactList_C_.Dialogs;
using Microsoft.Extensions.DependencyInjection;
using Buisness.Interfaces;
using Buisness.Services;
using ConsoleApp_ContactList_C_.Interfaces;

var host = Host.CreateDefaultBuilder()
    .ConfigureServices(services =>
    {
        services.AddSingleton<IFileService, FileService>();
        services.AddTransient<IContactService, ContactService>();
        services.AddTransient<IMainMenuDialog, MainMenuDialog>();
    })
    .Build();


//Run applicaton-menu:
using var scope = host.Services.CreateScope();
var mainMenuDialog = scope.ServiceProvider.GetRequiredService<MainMenuDialog>();
mainMenuDialog.RunMenu();