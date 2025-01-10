
using Buisness.Interfaces;
using Buisness.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WPF_MainApp.ViewModels;
using WPF_MainApp.Views;

namespace WPF_MainApp;


public partial class App : Application
{
    private IHost _host;

    public App()
    {
        _host = Host.CreateDefaultBuilder()
            .ConfigureServices(services =>
            {
                services.AddSingleton<IContactService, ContactService>();
                services.AddSingleton<IFileService, FileService>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddTransient<HomeView>();
                services.AddTransient<HomeViewModel>();

                services.AddTransient<ContactsViewModel>();
                services.AddTransient<ContactsView>();

                services.AddTransient<AddContactsViewModel>();
                services.AddTransient<AddContactView>();

                services.AddTransient<EditContactViewModel>();
                services.AddTransient<EditContactView>();

                services.AddTransient<ContactDetailsViewModel>();
                services.AddTransient<ContactDetailsView>();

            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
