using Microsoft.AspNetCore.Mvc;

namespace ETicaret.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()=>View();
        public IActionResult Rol()=>View();
    }
}
