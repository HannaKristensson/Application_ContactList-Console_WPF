using Buisness.Interfaces;
using Buisness.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Security.RightsManagement;

namespace WPF_MainApp.ViewModels;

public partial class ContactDetailsViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public ContactDetailsViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    private ContactModel _contact = new();


    [RelayCommand]
    private void EditContact()
    {
        var editContactViewModel = _serviceProvider.GetService<EditContactViewModel>();
        editContactViewModel.Contact = Contact;

        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = editContactViewModel;
    }

    [RelayCommand]
    private void ViewContacts()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactsViewModel>();
    }
}


