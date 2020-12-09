using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using XMLAssignment.Models;

namespace XMLAssignment.Controllers
{
    public class HomeController : Controller
    {
        private static string USER_SERVICE_API_BASE = Environment.GetEnvironmentVariable("USER_SERVICE_API_BASE");

        public HomeController()
        {
            if (USER_SERVICE_API_BASE == null)
            {
                USER_SERVICE_API_BASE = "https://localhost:5001/api";
            }
        }

        public async Task<IActionResult> Index()
        {
            var client = new HttpClient();

            var user = new User();
            HttpResponseMessage responseMessage = await client.GetAsync($"{USER_SERVICE_API_BASE}/users/2");

            if (responseMessage.IsSuccessStatusCode)
            {
                var result = responseMessage.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);
            }

            return View(user);
        }

        // GET: Users/Details/5
        //public async Task<IActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }
        //    var client = new HttpClient();
        //    HttpResponseMessage responseMessage = await client.GetAsync($"{USER_SERVICE_API_BASE}/users/");

        //    var user;
        //    if (responseMessage.IsSuccessStatusCode)
        //    {
        //        var result = responseMessage.Content.ReadAsStringAsync().Result;
        //        user = JsonConvert.DeserializeObject<User>(result);
        //    }

        //    return View(user);
        //}

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
