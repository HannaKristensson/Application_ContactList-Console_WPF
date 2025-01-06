
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;
using WPF_MainApp.Models;
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
                services.AddSingleton<MainViewModel>();
                services.AddSingleton<MainWindow>();

                services.AddTransient<ContactsViewModel>();
                services.AddTransient<ContactModel>();

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
