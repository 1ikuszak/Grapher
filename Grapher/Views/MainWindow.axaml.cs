using System;
using Avalonia.Controls;
using Grapher.ViewModels;

namespace Grapher.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var viewModel = new GraphPointViewModel();
        DataContext = viewModel;
    }
}