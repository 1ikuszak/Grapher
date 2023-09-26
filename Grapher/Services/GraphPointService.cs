using System.Collections.Generic;
using Grapher.Data_Model;

namespace Grapher.Services
{
    public class GraphPointService
    {
        public List<GraphPoint> InsertDefaultGraphPoints()
        {
            return new List<GraphPoint>
            {
                new GraphPoint() { X = 1, Y = 1 },
                new GraphPoint() { X = 2, Y = 2 },
                new GraphPoint() { X = 3, Y = 3 },
                new GraphPoint() { X = 4, Y = 4 },
                new GraphPoint() { X = 5, Y = 5 }
            };
        }
    }
}