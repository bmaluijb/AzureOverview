using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AzureOverview.Models;
using AzureOverview.Data.Interfaces;
using AzureOverview.Data;

namespace AzureOverview.Controllers
{
    public class HomeController : Controller
    {
        private IServicesService _service;

        public HomeController(IServicesService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {    
            return View(_service.GetAllServices());
        }

        [HttpPost]
        public IActionResult Index(string status, string searchterm)
        {
            List<Service> services;

            if(!string.IsNullOrEmpty(status) || !string.IsNullOrEmpty(searchterm))
            {
                services = _service.SearchForServices(status, searchterm);

                if (!string.IsNullOrEmpty(status))
                {
                    ViewBag.Status = status;
                }

                if (!string.IsNullOrEmpty(searchterm))
                {
                    ViewBag.SearchTerm = searchterm;
                }
            }
            else
            {
                services = _service.GetAllServices();
            }

            return View(services);
        }

        public IActionResult Feedback()
        {
            return View();
        }

        public IActionResult Faq()
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
