
using CommunityToolkit.Mvvm.ComponentModel;

namespace WPF_MainApp.ViewModels;

public partial class ContactsViewModel : ObservableObject
{
    [ObservableProperty]
    //title på sidan
    private string _title = "Contacts";
}
