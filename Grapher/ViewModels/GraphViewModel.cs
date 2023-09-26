using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using DynamicData;
using LiveChartsCore;
using LiveChartsCore.Defaults;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.SkiaSharpView.Painting;
using SkiaSharp;

namespace Grapher.ViewModels;

public class GraphViewModel
{
    public ObservableCollection<ObservableValue> MainChartValues = new ObservableCollection<ObservableValue>();
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
    
    public void InitializeGraph()
    {
        MainChartValues.AddRange(Enumerable.Range(0, 120)
            .Select(_ => new ObservableValue(new Random().NextDouble())));
            
        Series = new ISeries[]
        {
            new LineSeries<ObservableValue>
            {
                Values = MainChartValues,
                Stroke = new SolidColorPaint(new SKColor(0,0,0)) { StrokeThickness = 2},
                Fill = null,
                GeometryFill = null, 
                GeometryStroke = null 
            }
        };
    }
}