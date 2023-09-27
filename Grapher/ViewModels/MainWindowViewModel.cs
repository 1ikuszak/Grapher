using System;
using System.Reactive;
using Grapher.Services;
using Grapher.ViewModels;
using ReactiveUI;

public class MainWindowViewModel : ViewModelBase
{
    public MainWindowViewModel()
    {
        var graphPointService = new GraphPointService();
        GraphPointViewModel = new GraphPointViewModel(graphPointService);
        LineGraphViewModel = new LineGraphViewModel();
        ScatterGraphViewModel = new ScatterGraphViewModel();
        
        _contentToDisplay = ScatterGraphViewModel;
        
        GenerateDataCommand = ReactiveCommand.Create(GenerateData);
        RandomizeCommand = ReactiveCommand.Create(Randomize);
        GenerateData();
    }

    private void GenerateData()
    {
        Console.WriteLine("Generated Data:");
        foreach (var point in GraphPointViewModel.Points)
        {
            Console.WriteLine($"X: {point.X}, Y: {point.Y}");
        }

        if (ContentToDisplay == ScatterGraphViewModel)
            ScatterGraphViewModel.UpdateGraph(GraphPointViewModel);
        else
            LineGraphViewModel.UpdateGraph(GraphPointViewModel);
    }

    public void ShowLineGraph()
    {
        ContentToDisplay = LineGraphViewModel;
        GenerateData();
    }

    public void ShowScatterGraph()
    {
        ContentToDisplay = ScatterGraphViewModel;
        GenerateData();
    }

    public void Randomize()
    {
        ScatterGraphViewModel.RandomizeGraph();
        LineGraphViewModel.RandomizeGraph();
    }

    public ReactiveCommand<Unit, Unit> RandomizeCommand { get; }
    public ReactiveCommand<Unit, Unit> GenerateDataCommand { get; }
    public GraphPointViewModel GraphPointViewModel { get; }
    public LineGraphViewModel LineGraphViewModel { get; }
    public ScatterGraphViewModel ScatterGraphViewModel { get; }
    private ViewModelBase _contentToDisplay;
    public ViewModelBase ContentToDisplay
    {
        get => _contentToDisplay;
        set => this.RaiseAndSetIfChanged(ref _contentToDisplay, value);
    }
}
