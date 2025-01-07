
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

    public ContactsViewModel(IContactService contactService)
    {
        _contactService = contactService;
        _contactModel = new ObservableCollection<ContactModel>();
    }

    public ContactsViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    private ObservableCollection<ContactModel> _contactModel;


    [ObservableProperty]
    //title på sidan
    private string _title = "Contacts";

    [RelayCommand]
    private void Home()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
    }
}
