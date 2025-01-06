
using System.Windows;
using WPF_MainApp.ViewModels;


namespace WPF_MainApp;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }
}