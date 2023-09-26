using ReactiveUI;
namespace Grapher.Data_Model;

public class GraphPoint : ReactiveObject
{
    private int _x;
    public int X
    {
        get => _x;
        set => this.RaiseAndSetIfChanged(ref _x, value);
    }

    private int _y;
    public int Y
    {
        get => _y;
        set => this.RaiseAndSetIfChanged(ref _y, value);
    }
}
