﻿
using System.Windows;
using System.Windows.Input;
using WPF_MainApp.ViewModels;


namespace WPF_MainApp;

public partial class MainWindow : Window
{
    public MainWindow(MainViewModel viewModel)
    {
        InitializeComponent();
        DataContext = viewModel;
    }

    private void TopBar_MouseDown(object sender, MouseButtonEventArgs e)
    {
        if (e.ChangedButton == MouseButton.Left)
        {
            DragMove();
        }
    }

    private void ExitButton_Click(object sender, RoutedEventArgs e)
    {
        Environment.Exit(0);
    }
}