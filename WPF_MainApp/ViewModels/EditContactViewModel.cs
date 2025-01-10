﻿using Buisness.Interfaces;
using Buisness.Models;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace WPF_MainApp.ViewModels;

public partial class EditContactViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;
    private readonly IContactService _contactService;

    public EditContactViewModel(IServiceProvider serviceProvider, IContactService contactService)
    {
        _serviceProvider = serviceProvider;
        _contactService = contactService;
    }

    [ObservableProperty]
    private ContactModel _contact = new();


    [RelayCommand]
    private void UpdateUser()
    {
        //var result = _contactService.UpdateUser(User);
        //if (result)
        {
            //TextBlock = "it worked";
            var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
            mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
        }
    }

    [RelayCommand]
    private void ViewContacts()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<ContactsViewModel>();
    }
}
