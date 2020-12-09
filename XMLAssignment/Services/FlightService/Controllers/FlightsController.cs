using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using FlightService.Models;
using System.Xml;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace FlightService.Controllers
{
    [Route("api/[controller]")]
    public class FlightsController : Controller
    {
        private IList<Flight> flights = new List<Flight>();
        private XmlDocument doc;
        private XmlNode root;
        private static string docPath = "flight.xml";

        public FlightsController()
        {
            doc = new XmlDocument();
            doc.Load(docPath);
            root = doc.DocumentElement;
            XmlNodeList flightList = root.ChildNodes;

            for (int index = 0; index < flightList.Count; index++)
            {
                flights.Add(new Flight()
                {
                    id = int.Parse(flightList[index].ChildNodes[0].InnerText),
                    airline = flightList[index].ChildNodes[1].InnerText,
                    departure_date = flightList[index].ChildNodes[2].InnerText,
                    departure_time = flightList[index].ChildNodes[3].InnerText,
                    origin = flightList[index].ChildNodes[4].InnerText,
                    destination = flightList[index].ChildNodes[5].InnerText,
                    price = int.Parse(flightList[index].ChildNodes[6].InnerText),
                    stop = flightList[index].ChildNodes[7].InnerText,
                    seats = int.Parse(flightList[index].ChildNodes[8].InnerText)
                });
            }
        }

        // GET api/flights/5
        [HttpGet("{date}")]
        public ActionResult<Flight> Get(string date)
        {
            IList<Flight> newFlightList = new List<Flight>();
            try
            {
                foreach (Flight flight in flights)
                {
                    if (flight.departure_date == date)
                    {
                        newFlightList.Add(flight);
                    }
                }
            }
            catch (Exception e)
            {
            }

            if (newFlightList.Count == 0)
            {
                return null;
            }
            return Ok(newFlightList);
        }

        // GET api/flights/byDate?date=16-07-2019&origin=Kuala%20Lumpur&destination=London
        [HttpGet("byDate")]
        public ActionResult<Flight> Get([FromQuery]string date, string origin, string destination)
        {
            IList<Flight> newFlightList = new List<Flight>();
            try
            {
                foreach (Flight flight in flights)
                {
                    if (flight.departure_date == date && flight.origin == origin && flight.destination == destination)
                    {
                        newFlightList.Add(flight);
                    }
                }
            }
            catch (Exception e)
            {
            }

            if (newFlightList.Count == 0)
            {
                return null;
            }
            return Ok(newFlightList);
        }

        // POST api/values/bookFlight?id=1&seats=2
        [HttpPut("bookFlight")]
        public ActionResult<Flight> Put([FromQuery]int id, int seats)
        {
            foreach (XmlNode node in doc.SelectNodes("/Flights/Flight"))
            {
                if (node["id"].InnerText == id.ToString()) {
                    int curSeats = int.Parse(node["seats"].InnerText);
                    int updatedSeats = curSeats - seats;
                    node["seats"].InnerText = updatedSeats.ToString();
                    doc.Save(docPath);
                    return Ok();
                }
            }
            return null;
        }
    }
}
