using System;
namespace HotelService.Models
{
    public class Hotel
    {
        public Hotel()
        {
        }

        public int id { get; set; }
        public string hotelName { get; set; }
        public string address { get; set; }
        public string city { get; set; }
        public string state { get; set; }
        public string country { get; set; }
        public string priceRange { get; set; }
    }
}
