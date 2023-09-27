using System;
using Avalonia.Controls;
using Avalonia.Controls.Models.TreeDataGrid;
using System.Linq.Expressions;
using Grapher.Data_Model;

namespace Grapher.ViewModels
{
    public class GraphTableViewModel : ViewModelBase
    {
        public GraphTableViewModel(GraphPointViewModel graphPointViewModel)
        {
            Source = new FlatTreeDataGridSource<GraphPoint>(graphPointViewModel.Points)
            {
                Columns =
                {
                    new TextColumn<GraphPoint, int>("Row", CreateRowNumberExpression(graphPointViewModel)),
                    new TextColumn<GraphPoint, int>("X", x => x.X),
                    new TextColumn<GraphPoint, int>("Y", x => x.Y),
                },
            };
        }
        
        private Expression<Func<GraphPoint, int>> CreateRowNumberExpression(GraphPointViewModel graphPointViewModel)
        {
            return x => graphPointViewModel.Points.IndexOf(x) + 1;
        }
        
        public FlatTreeDataGridSource<GraphPoint> Source { get; }
    }
}