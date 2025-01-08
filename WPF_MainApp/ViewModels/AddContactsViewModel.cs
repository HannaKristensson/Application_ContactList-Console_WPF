using Buisness.Interfaces;
using Buisness.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Windows.Controls;

namespace WPF_MainApp.ViewModels;

public partial class AddContactsViewModel(IServiceProvider serviceProvider, IContactService contactService) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;

    [ObservableProperty]
    private string _title = "Add New Contact";

    [ObservableProperty]
    private ContactModel _contact = new();

    [RelayCommand]
    private void Save()
    {
        var result = _contactService.CreateContact(Contact);
        if(result)
        {
            //TextBlock = "it worked";
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
        }

    }

    [RelayCommand]
    private void Home()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
    }
}
