using System;
using System.Reactive;
using Grapher.Services;
using ReactiveUI;

namespace Grapher.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var graphPointService = new GraphPointService();
        GraphPointViewModel = new GraphPointViewModel(graphPointService);
        GraphViewModel = new GraphViewModel();
        
        GraphViewModel.InitializeGraph();
        GenerateDataCommand = ReactiveCommand.Create(GenerateData);
    }
    
    private void GenerateData()
    {
        Console.WriteLine("Generated Data:");
        foreach (var point in GraphPointViewModel.Points)
        {
            Console.WriteLine($"X: {point.X}, Y: {point.Y}");
        }
    }

    public ReactiveCommand<Unit, Unit> GenerateDataCommand { get; }
    public GraphPointViewModel GraphPointViewModel { get; }
    public GraphViewModel GraphViewModel { get; } 
}
