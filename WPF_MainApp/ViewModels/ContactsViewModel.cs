
using Buisness.Interfaces;
using Buisness.Models;
using Buisness.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace WPF_MainApp.ViewModels;

public partial class ContactsViewModel(IContactService contactService, IServiceProvider serviceProvider) : ObservableObject
{
    private readonly IServiceProvider _serviceProvider = serviceProvider;
    private readonly IContactService _contactService = contactService;

    [ObservableProperty]
    private ObservableCollection<ContactModel> _contactModel = [];



    //public ContactsViewModel(IServiceProvider serviceProvider)
    //{
    //    _serviceProvider = serviceProvider;
    //}

    //[ObservableProperty]
    ////title på sidan
    //private string _title = "Contacts";

    [RelayCommand]
    private void Home()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
    }
}
