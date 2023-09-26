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

        LineGraphViewModel.InitializeGraph();
        ScatterGraphViewModel.InitializeGraph();

        GenerateDataCommand = ReactiveCommand.Create(GenerateData);

        _contentToDisplay = LineGraphViewModel;
    }

    private ViewModelBase _contentToDisplay;
    public ViewModelBase ContentToDisplay
    {
        get => _contentToDisplay;
        set => this.RaiseAndSetIfChanged(ref _contentToDisplay, value);
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
        {
            LineGraphViewModel.UpdateGraph(GraphPointViewModel);
        }
    }

    public void ShowLineGraph()
    {
        ContentToDisplay = LineGraphViewModel;
        LineGraphViewModel.InitializeGraph();
        Console.WriteLine("Line");
    }

    public void ShowScatterGraph()
    {
        ContentToDisplay = ScatterGraphViewModel;
        ScatterGraphViewModel.InitializeGraph();
        Console.WriteLine("Scatter");
    }

    public ReactiveCommand<Unit, Unit> GenerateDataCommand { get; }
    public GraphPointViewModel GraphPointViewModel { get; }
    public LineGraphViewModel LineGraphViewModel { get; }
    public ScatterGraphViewModel ScatterGraphViewModel { get; }
}