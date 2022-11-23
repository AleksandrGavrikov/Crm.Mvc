using Microsoft.AspNetCore.Mvc;

namespace Crm.Mvc.Areas.Patient.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
