using Microsoft.AspNetCore.Mvc;

namespace Microservices.FrontEnd.Web.Controllers
{
    public class AuthsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
