using System.Collections.ObjectModel;
using System.Reactive;
using ReactiveUI;
using Grapher.Data_Model;
using Grapher.Services;

namespace Grapher.ViewModels;

public class GraphPointViewModel : ViewModelBase
{
    private readonly GraphPointService _graphPointService;
    public ObservableCollection<GraphPoint> Points { get; } = new ObservableCollection<GraphPoint>();

    public GraphPointViewModel(GraphPointService _graphPointService)
    {
        // Insert default data
        var defaultPoints = _graphPointService.InsertDefaultGraphPoints();
        foreach (var point in defaultPoints)
            Points.Add(point);
    }
}
