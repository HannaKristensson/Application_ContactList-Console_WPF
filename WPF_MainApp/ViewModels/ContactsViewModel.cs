using Buisness.Interfaces;
using Buisness.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace WPF_MainApp.ViewModels;

public partial class ContactsViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    public ContactsViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;

        _contacts = new ObservableCollection<ContactModel>(_contactService.GetContacts());
    }

    [ObservableProperty]
    private ObservableCollection<ContactModel> _contacts = [];

    [RelayCommand]
    private void ContactDetails(ContactModel contact)
    { 
        var ContactDetailsViewModel = _serviceProvider.GetRequiredService<ContactDetailsViewModel>();
        ContactDetailsViewModel.Contact = contact;


        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = ContactDetailsViewModel;
    }

    [RelayCommand]
    private void Home()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
    }
}
