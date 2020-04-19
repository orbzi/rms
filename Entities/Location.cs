using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Entities
{
    class Location
    {
        public int id { get; set; }
        public string StationName { get; set; }
        public Location(int _id, string _station)
        {
            id = _id;
            StationName = _station;
        }
    }
}