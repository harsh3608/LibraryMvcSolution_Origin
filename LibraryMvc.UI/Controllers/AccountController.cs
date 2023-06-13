using Microsoft.AspNetCore.Mvc;

namespace LibraryMvc.UI.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
