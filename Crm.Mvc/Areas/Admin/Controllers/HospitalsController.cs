using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Areas.Admin.Controllers
{
    public class HospitalsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
