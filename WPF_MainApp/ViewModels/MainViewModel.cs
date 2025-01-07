

using CommunityToolkit.Mvvm.ComponentModel;
using Microsoft.Extensions.DependencyInjection;

namespace WPF_MainApp.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly IServiceProvider _serviceProvider;

    [ObservableProperty]
    private ObservableObject _CurrentViewModel = null!;

    public MainViewModel(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
        //_CurrentViewModel = _serviceProvider.GetRequiredService<ContactsViewModel>();
        _CurrentViewModel = _serviceProvider.GetRequiredService<HomeViewModel>();
    }
}
