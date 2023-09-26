using System.Collections.Generic;
using Grapher.Data_Model;
using Grapher.Services;

namespace Grapher.ViewModels
{
    public class GraphPointViewModel : ViewModelBase
    {
        public List<GraphPoint> Points { get; }

        public GraphPointViewModel()
        {
            // Call the GraphPointService to populate the data
            var graphPointService = new GraphPointService();
            Points = graphPointService.InsertDefaultGraphPoints();
        }
    }
}