using Microsoft.AspNetCore.Mvc;

namespace SistemaVendas.Controllers
{
    public class ErrorController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}