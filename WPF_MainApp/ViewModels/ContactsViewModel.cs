
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.Extensions.DependencyInjection;

namespace WPF_MainApp.ViewModels;

public partial class ContactsViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public ContactsViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    //title på sidan
    private string _title = "Contacts";

    [RelayCommand]
    private void GoToContacts()
    {
        var mainViewModel = _serviceProvider.GetRequiredService<MainViewModel>();
        mainViewModel.CurrentViewModel = _serviceProvider.GetRequiredService<AddContactsViewModel>();
    }
}
