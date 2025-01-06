using CommunityToolkit.Mvvm.ComponentModel;

namespace WPF_MainApp.ViewModels;

public partial class AddContactsViewModel : ObservableObject
{
    [ObservableProperty]
    private string _title = "Add New Contact";
}
