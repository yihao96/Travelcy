using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;
using HotelService.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HotelService.Controllers
{
    [Route("api/[controller]")]
    public class HotelsController : Controller
    {
        private IList<Hotel> hotels = new List<Hotel>();
        private XmlDocument doc;
        private XmlNode root;
        private static string docPath = "hotel.xml";

        public HotelsController()
        {
            doc = new XmlDocument();
            doc.Load(docPath);
            root = doc.DocumentElement;
            XmlNodeList hotelList = root.ChildNodes;

            for (int index = 0; index < hotelList.Count; index++)
            {
                hotels.Add(new Hotel()
                {
                    id = int.Parse(hotelList[index].ChildNodes[0].InnerText),
                    airline = hotelList[index].ChildNodes[1].InnerText,
                    departure_date = hotelList[index].ChildNodes[2].InnerText,
                    departure_time = hotelList[index].ChildNodes[3].InnerText,
                    origin = hotelList[index].ChildNodes[4].InnerText,
                    destination = hotelList[index].ChildNodes[5].InnerText,
                    price = int.Parse(hotelList[index].ChildNodes[6].InnerText),
                    stop = hotelList[index].ChildNodes[7].InnerText,
                    seats = int.Parse(hotelList[index].ChildNodes[8].InnerText)
                });
            }
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
