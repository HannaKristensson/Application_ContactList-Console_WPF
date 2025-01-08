
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
                services.AddTransient<IContactService, ContactService>();
                services.AddTransient<IFileService, FileService>();

                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddSingleton<HomeView>();
                services.AddSingleton<HomeViewModel>();

                services.AddTransient<ContactsViewModel>();
                services.AddTransient<ContactsView>();

                services.AddTransient<AddContactsViewModel>();
                services.AddTransient<AddContactView>();

            })
            .Build();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainWindow = _host.Services.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }
}
