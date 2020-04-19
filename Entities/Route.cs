using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    class Route
    {
        public int id { get; set; }
        public Location location1 { get; set; }
        public Location location2 { get; set; }
        public double distance { get; set; }

        public Route(int _id, Location _location1, Location _location2, double _distance)
        {
            id = _id;
            location1 = _location1;
            location2 = _location2;
            distance = _distance;
        }
    }
}