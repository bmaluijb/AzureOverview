using AzureOverview.Data;
using AzureOverview.Data.Interfaces;
using AzureOverview.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Diagnostics;

namespace AzureOverview.Controllers
{

    
    public class HomeController : Controller
    {
        private IServicesService _service;

        public HomeController(IServicesService service)
        {
            _service = service;
        }

        [ResponseCache(Duration = 86400)]
        public IActionResult Index()
        {
            return View(_service.GetAllServices());
        }

        [HttpPost]
        public IActionResult Index(string status, string searchterm)
        {
            List<Service> services;

            if (!string.IsNullOrEmpty(status) || !string.IsNullOrEmpty(searchterm))
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

        public IActionResult ChangeCulture(string cultureString)
        {
            try
            {
                Response.Cookies.Delete(CookieRequestCultureProvider.DefaultCookieName);
            }
            catch { }


            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName, 
                "c=" + cultureString + "|uic=" + cultureString);

            return Redirect(Request.Headers["Referer"].ToString());

        }

        public IActionResult ClearCache()
        {
            _service.ClearCache();

            return RedirectToAction("Index");
        }
    }
}
