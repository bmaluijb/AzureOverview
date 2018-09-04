using AzureOverview.Data.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AzureOverview.Controllers
{
    [Route("api/[controller]")]
    public class ServicesController : Controller
    {

        private IServicesService _service;

        public ServicesController(IServicesService service)
        {
            _service = service;
        }

        // GET: api/<controller>
        [HttpGet]
        public ActionResult<string[]> Get()
        {
            return _service.GetAllServices().Select(s => s.Name).OrderBy(Name => Name).ToArray();
        }
    }
}
