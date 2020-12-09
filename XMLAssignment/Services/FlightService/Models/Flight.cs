using System;
namespace FlightService.Models
{
    public class Flight
    {
        public Flight()
        {
        }

        public int id { get; set; }
        public string airline { get; set; }
        public string departure_date { get; set; }
        public string departure_time { get; set; }
        public string origin { get; set; }
        public string destination { get; set; }
        public int price { get; set; }
        public string stop { get; set; }
        public int seats { get; set; }
    }
}
