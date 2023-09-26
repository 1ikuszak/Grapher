using System;
using System.Reactive;
using ReactiveUI;

namespace Grapher.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            GraphPointViewModel = new GraphPointViewModel();
        }
        
        public GraphPointViewModel GraphPointViewModel { get; }
    }
}