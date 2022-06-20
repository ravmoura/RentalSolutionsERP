﻿using Microsoft.AspNetCore.Mvc;
using RentalCar.Models;
using System.Diagnostics;

namespace RentalCar.Controllers
{
    public class HomeController : Controller
    {
        private readonly RentalCarContext context;

        public HomeController(RentalCarContext context)
        {
            this.context = context;
        }

        public IActionResult Index()
        {
            return View();
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