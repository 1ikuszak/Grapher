using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Avalonia;
using DynamicData;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace Grapher.ViewModels
{
    public class LineGraphViewModel: ViewModelBase
    {
        private ObservableCollection<ObservablePoint> _mainChartValues = new ObservableCollection<ObservablePoint>();
        public ISeries[] Series { get; set; }

        public List<Axis> YAxis { get; set; } =
            new List<Axis>
            {
                new Axis
                {
                    MaxLimit = 0,
                    MinLimit = -60
                }
            };

        public List<Axis> XAxis { get; set; } =
            new List<Axis>
            {
                new Axis
                {
                    MaxLimit = 0,
                    MinLimit = -60
                }
            };

        
        public void RandomizeGraph()
        {
            _mainChartValues.Clear();

            var random = new Random();
            var chartValues = Enumerable.Range(0, 120)
                .Select(_ => new ObservablePoint(random.NextDouble(), random.NextDouble()))
                .OrderBy(point => point.X)
                .ToList();

            _mainChartValues.AddRange(chartValues);

            Series = new ISeries[]
            {
                new LineSeries<ObservablePoint>
                {
                    Values = _mainChartValues,
                    Stroke = new SolidColorPaint(new SKColor(0, 0, 0)) { StrokeThickness = 2 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null
                }
            };
        }

        public void UpdateGraph(GraphPointViewModel graphPointViewModel)
        {
            // Clear the MainChartValues before adding new values
            _mainChartValues.Clear();

            var chartValues = graphPointViewModel.Points
                .Select(point => new ObservablePoint(point.X, point.Y))
                .OrderBy(point => point.X)
                .ToList();

            _mainChartValues.AddRange(chartValues);

            Series = new ISeries[]
            {
                new LineSeries<ObservablePoint>
                {
                    Values = _mainChartValues,
                    Stroke = new SolidColorPaint(new SKColor(0, 0, 0)) { StrokeThickness = 2 },
                    Fill = null,
                    GeometryFill = null,
                    GeometryStroke = null
                }
            };
        }

        
    }
}
