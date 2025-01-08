
using Buisness.Interfaces;
using Buisness.Models;
using Buisness.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;
using System.Collections.ObjectModel;

namespace WPF_MainApp.ViewModels;

public partial class ContactsViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;
    private readonly IFileService _fileService;

    public ContactsViewModel(IServiceProvider serviceProvider, IContactService contactService, IFileService fileService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
        _fileService = fileService;

        _contacts = new ObservableCollection<ContactModel>(_contactService.GetContacts());
    }


    [ObservableProperty]
    private ObservableCollection<ContactModel> _contacts = [];



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
