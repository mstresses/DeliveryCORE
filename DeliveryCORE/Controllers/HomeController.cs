﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DeliveryCORE.Models;
using MapIntegration.Models;

namespace DeliveryCORE.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Login()
        {
            return View();
        }


        public IActionResult Index()
        {
            LocationLists model = new LocationLists();
            var locations = new List<Locations>()
            {
                new Locations(1, "Bhubaneswar","Bhubaneswar, Odisha", 20.296059, 85.824539),
                new Locations(2, "Hyderabad","Hyderabad, Telengana", 17.387140, 78.491684),
                new Locations(3, "Bengaluru","Bengaluru, Karnataka", 12.972442, 77.580643)
            };
            model.LocationList = locations;
            return View(model);
        }

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
