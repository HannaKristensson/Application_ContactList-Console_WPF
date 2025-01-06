using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace WPF_MainApp.ViewModels;

public partial class AddContactsViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    public AddContactsViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    [ObservableProperty]
    private string _title = "Add New Contact";

    [RelayCommand]
    private void GoToContacts()
    {

    }
}
